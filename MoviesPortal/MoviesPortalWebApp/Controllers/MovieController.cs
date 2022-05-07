using AutoMapper;
using BusinessLogic.Services;
using DataAccess.Models;
using DataAccess.Models.EntityAssigments;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MoviesPortalWebApp.Models;

namespace MoviesPortalWebApp.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;

        private readonly MoviePortalContext _context;

        public MovieController(IMovieService movieService, IMapper mapper, MoviePortalContext context)
        {
            _movieService = movieService;
            _mapper = mapper;
            _context = context;
        }

        #region User

        #region User movies list
        public async Task<IActionResult> IndexUser(string searchString)
        {
            //var model = await _movieService.GetAllMoviesAsync();
            var model = from m in _context.Movies select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                model = model.Where(s => s.Title.Contains(searchString));
            }

            var movies = _mapper.Map<IList<MovieVM>>(model);
            return View(movies);
        }
        #endregion

        #region User movie details
        public async Task<IActionResult> DetailsUser(int? id)
        {
            var model = await _movieService.GetMovieIdByAsync(id);
            var movie = _mapper.Map<MovieVM>(model);
            return View(movie);
        }
        #endregion

        #endregion

        #region Admin

        #region Admin movies list
        public async Task<IActionResult> Index()
        {
            var model = await _movieService.GetAllMoviesAsync();
            var movies = _mapper.Map<IList<MovieVM>>(model);
            return View(movies);
        }
        #endregion

        #region Admin movie details
        public async Task<IActionResult> Details(int? id)
        {
            var model = await _movieService.GetMovieIdByAsync(id);
            var movie = _mapper.Map<MovieVM>(model);
            return View(movie);
        }
        #endregion

        #region Create
        public async Task<IActionResult> Create(int? Id)
        {
            MovieVM model = new MovieVM();
            List<int> genresIds = new List<int>();
            List<int> actorsIds = new List<int>();

            var movie = new MovieModel();
            model = _mapper.Map<MovieVM>(movie);
            model.selectedGenres = _context.Genres
                .Select(x => new SelectListItem { Text = x.Genre, Value = x.Id.ToString() }).ToList();
            model.selectedActors = _context.CreativePersons
               .Select(x => new SelectListItem { Text = string.Format("{0} {1}", x.Name, x.SurName), Value = x.Id.ToString() }).ToList();
            model.selectedDirectors = _context.CreativePersons
               .Select(x => new SelectListItem { Text = string.Format("{0} {1}", x.Name, x.SurName), Value = x.Id.ToString() }).ToList();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(MovieVM model)
        {
            MovieModel movie = new MovieModel();
            List<MovieGenre> movieGenres = new List<MovieGenre>();
            List<RoleCreativeMovie> movieActorsRole = new List<RoleCreativeMovie>();

            movie.Title = model.Title;
            movie.Description = model.Description;
            movie.ProductionYear = model.ProductionYear;
            movie.PosterPath = model.PosterPath;
            movie.TrailerUrl = model.TrailerUrl;
            movie.BackgroundPoster = model.BackgroundPoster;
            movie.ImdbRatio = model.ImdbRatio;
            movie.IsForKids = model.IsForKids;

            if (model.GenresIds.Length > 0)
            {

                foreach (var genreId in model.GenresIds)
                {
                    movieGenres.Add(new MovieGenre { GenreId = genreId, MovieId = model.Id });
                }

                movie.MovieGenres = movieGenres;
            }

            if (model.ActorsIds.Length > 0)
            {
                foreach (var actorId in model.ActorsIds)
                {
                    movieActorsRole.Add(new RoleCreativeMovie { CreativePersonId = actorId, MovieId = model.Id, RoleId = 1 });
                }

                foreach (var drId in model.DirectorsIds)
                {
                    movieActorsRole.Add(new RoleCreativeMovie { CreativePersonId = drId, MovieId = model.Id, RoleId = 2 });
                }

                movie.RoleCreativeMovie = movieActorsRole;
            }


            _context.Movies.Add(movie);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        #endregion

        #region Edit
        public async Task<IActionResult> Edit(int? Id)
        {
            MovieVM model = new MovieVM();
            List<int> genresIds = new List<int>();
            List<int> actorsIds = new List<int>();
            List<int> directorsIds = new List<int>();

            if (Id.HasValue)
            {
                // get movie              
                var movie = await _movieService.GetMovieIdByAsync(Id);

                // get movie genres and add each genresIds into genresIds list
                movie.Genres.ToList().ForEach(x => genresIds.Add(x.Id));
                movie.RoleCreativeMovie.Where(d => d.Role.RoleName == "Actor").ToList().ForEach(x => actorsIds.Add(x.CreativePersonId));
                movie.RoleCreativeMovie.Where(d => d.Role.RoleName == "Director").ToList().ForEach(x => directorsIds.Add(x.CreativePersonId));

                var vm = _mapper.Map<MovieVM>(movie);

                //bind model 
                model.selectedGenres = _context.Genres
                        .Select(x => new SelectListItem { Text = x.Genre, Value = x.Id.ToString() }).ToList();

                model.selectedActors = _context.CreativePersons
                        .Select(x => new SelectListItem { Text = string.Format("{0} {1}", x.Name, x.SurName), Value = x.Id.ToString() }).ToList();

                model.selectedDirectors = _context.CreativePersons
                        .Select(x => new SelectListItem { Text = string.Format("{0} {1}", x.Name, x.SurName), Value = x.Id.ToString() }).ToList();


                model.Id = vm.Id;
                model.Title = vm.Title;
                model.Description = vm.Description;
                model.ProductionYear = vm.ProductionYear;
                model.PosterPath = vm.PosterPath;
                model.TrailerUrl = vm.TrailerUrl;
                model.IsForKids = vm.IsForKids;
                model.GenresIds = genresIds.ToArray();
                model.ActorsIds = actorsIds.ToArray();
                model.DirectorsIds = directorsIds.ToArray();

            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(MovieVM model)
        {
            MovieModel newMovie = new MovieModel();
            List<MovieGenre> movieGenres = new List<MovieGenre>();
            List<RoleCreativeMovie> movieCP = new List<RoleCreativeMovie>();
            List<RoleCreativeMovie> movieD = new List<RoleCreativeMovie>();


            if (model.Id > 0)
            {
                newMovie = await _movieService.GetMovieIdByAsync(model.Id);

                newMovie.MovieGenres.ToList().ForEach(result => movieGenres.Add(result));
                newMovie.RoleCreativeMovie.Where(x => x.Role.RoleName == "Actor").ToList().ForEach(result => movieCP.Add(result));
                newMovie.RoleCreativeMovie.Where(x => x.Role.RoleName == "Director").ToList().ForEach(result => movieD.Add(result));

                _context.Movie_Genre.RemoveRange(movieGenres);
                _context.Role_CreativeP_Movie.RemoveRange(movieCP);
                _context.Role_CreativeP_Movie.RemoveRange(movieD);
                _context.SaveChanges();

                newMovie.Title = model.Title;
                newMovie.Id = model.Id;
                newMovie.Description = model.Description;
                newMovie.ProductionYear = model.ProductionYear;
                newMovie.PosterPath = model.PosterPath;
                newMovie.TrailerUrl = model.TrailerUrl;
                newMovie.IsForKids = model.IsForKids;

                if (model.GenresIds.Length > 0)
                {

                    movieGenres = new List<MovieGenre>();

                    foreach (var genreId in model.GenresIds)
                    {
                        movieGenres.Add(new MovieGenre { GenreId = genreId, MovieId = model.Id });
                    }

                    newMovie.MovieGenres = movieGenres;
                }

                if (model.ActorsIds.Length > 0)
                {

                    movieCP = new List<RoleCreativeMovie>();

                    foreach (var actId in model.ActorsIds)
                    {
                        movieCP.Add(new RoleCreativeMovie { CreativePersonId = actId, MovieId = model.Id, RoleId = 1 });
                    }

                    foreach (var drId in model.DirectorsIds)
                    {
                        movieCP.Add(new RoleCreativeMovie { CreativePersonId = drId, MovieId = model.Id, RoleId = 2 });
                    }

                    newMovie.RoleCreativeMovie = movieCP;

                }
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        #endregion

        #region Delete
        // GET: MovieController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _movieService.GetMovieIdByAsync(id);
            var movie = _mapper.Map<MovieVM>(model);

            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: MovieController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _movieService.DeleteMovieByIdAsync(id);
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #endregion

    }
}
