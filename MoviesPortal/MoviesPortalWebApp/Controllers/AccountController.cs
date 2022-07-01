using AutoMapper;
using BusinessLogic.ApiHandler;
using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using DataAccess.DbContext;
using DataAccess.Models;
using DataAccess.Models.EntityAssigments;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesPortalWebApp.Models;
using System.Security.Claims;

namespace MoviesPortalWebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly MoviePortalContext _context;
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;
        private readonly ApiClient _client;
        private readonly INewsletterSender _newsletterSender;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            MoviePortalContext context,
            IMapper mapper,
            IMovieService movieService,
            ApiClient client,
            INewsletterSender newsletterSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _mapper = mapper;
            _movieService = movieService;
            _client = client;
            _newsletterSender = newsletterSender;

        }


        public async Task<IActionResult> Users()
        {
            var users = await _context.Users.ToListAsync();
            return View(users);
        }

        public async Task<IActionResult> Index(string id)
        {
            var moviesFromDb = from m in _context.UserFavoriteMovies.Include(x => x.Movie).ToList()
                               select m;
            moviesFromDb = moviesFromDb.Where(s => s.UserId == id);

            var moviesFromApi = _context.UserFavoriteApiMovies.Where(s => s.UserId == id);

            var moviesFromApiMapped = _mapper.Map<List<UserFavoriteMovies>>(moviesFromApi);

            var movies = moviesFromDb.Concat(moviesFromApiMapped).ToList();

            foreach (var movie in movies)
            {
                if (movie.Movie == null)
                {
                    var item = await _client.GetMovieDetails(movie.MovieId);
                    var itemMapped = _mapper.Map<MovieVM>(item);
                    var itemMapped2 = _mapper.Map<MovieModel>(itemMapped);
                    movie.Movie = itemMapped2;
                }
            }

            return View(movies);
        }

        public async Task<IActionResult> AddMovieToFavourities(MovieVM movieVM)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var fMovie = new UserFavoriteMovies();
            var apiMovie = new UserFavoriteApiMovies();

            if (movieVM.IsApiModel)
            {
                apiMovie.UserId = userId;
                apiMovie.MovieId = movieVM.Id;
                _context.UserFavoriteApiMovies.Add(apiMovie);
                await _context.SaveChangesAsync();
            }
            else
            {
                fMovie.UserId = userId;
                fMovie.MovieId = movieVM.Id;
                _context.UserFavoriteMovies.Add(fMovie);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("DetailsUser", "Movie", new { id = movieVM.Id });
        }

        public async Task<IActionResult> RemoveMovieToFavourities(MovieVM movieVM)
        {
            if (movieVM.IsApiModel)
            {
                var movie = _context.UserFavoriteApiMovies.FirstOrDefault(x => x.MovieId == movieVM.Id && x.UserId == User.FindFirst(ClaimTypes.NameIdentifier).Value);
                _context.UserFavoriteApiMovies.Remove(movie);
                await _context.SaveChangesAsync();
            }
            else
            {
                var movie = _context.UserFavoriteMovies.FirstOrDefault(x => x.MovieId == movieVM.Id && x.UserId == User.FindFirst(ClaimTypes.NameIdentifier).Value);
                _context.UserFavoriteMovies.Remove(movie);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("DetailsUser", "Movie", new { id = movieVM.Id });
        }


        public IActionResult Login() => View(new LoginVM());

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid) return View(loginVM);

            var user = await _userManager.FindByEmailAsync(loginVM.EmailAddress);
            if (user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);
                if (passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                TempData["Error"] = "Wrong credentials. Please, try again!";
                return View(loginVM);
            }

            TempData["Error"] = "Wrong credentials. Please, try again!";
            return View(loginVM);
        }


        public IActionResult Register() => View(new RegisterVM());

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid) return View(registerVM);

            var user = await _userManager.FindByEmailAsync(registerVM.EmailAddress);
            if (user != null)
            {
                TempData["Error"] = "This email address is already in use";
                return View(registerVM);
            }

            var newUser = new ApplicationUser()
            {
                FullName = registerVM.FullName,
                Email = registerVM.EmailAddress,
                UserName = registerVM.EmailAddress
            };

            string message = "You have registered in Cartel MoviePortal, Congratulations!";

            var newUserResponse = await _userManager.CreateAsync(newUser, registerVM.Password);

            if (newUserResponse.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, UserRole.User);

            }
            await _newsletterSender.SendNotyficationToSingleUser(registerVM.EmailAddress, registerVM.FullName, message);

            return View("RegisterCompleted");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied(string ReturnUrl)
        {
            return View();
        }

        public IActionResult AuthLayout() => View(new RegisterVM());

        public async Task<IActionResult> Admin(string id)
        {
            var movies = from m in _context.UserFavoriteMovies.Include(x => x.Movie)
                         select m;
            movies = movies.Where(s => s.UserId == id);

            return View(await movies.ToListAsync());
        }

        public async Task<IActionResult> AddComment(CommentVM comment)
        {
            comment.PublishedAt = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            var commmentDb = _mapper.Map<CommentModel>(comment);
            _context.Comments.Add(commmentDb);
            _context.SaveChanges();
            return RedirectToAction("DetailsUser", "Movie", new { id = comment.MovieId });
        }
    }
}
