using AutoMapper;
using BusinessLogic.Services;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using MoviesPortalWebApp.Models;
using System.Diagnostics;

namespace MoviesPortalWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;

        private readonly MoviePortalContext _context;

        public HomeController(IMovieService movieService, IMapper mapper, MoviePortalContext context)
        {
            _movieService = movieService;
            _mapper = mapper;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _movieService.GetAllMoviesAsync();
            var movies = _mapper.Map<IList<MovieVM>>(model);
            return View(movies);
        }

        /*        public IActionResult Index()
                {

                    return View();
                }*/

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}