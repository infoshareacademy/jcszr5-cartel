using AutoMapper;
using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using DataAccess.Models;
using DataAccess.Models.EntityAssigments;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MoviesPortalWebApp.Models;
using System.Data.Entity;

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

            #region Index
            public async Task<IActionResult> Index()
            {
                var model = await _movieService.GetAllMoviesAsync();
                var movies = _mapper.Map<IList<Movie>>(model);
                return View(movies);
            }
            #endregion

            #region Details
            public async Task<IActionResult> Details(int? id)
            {
                var model = await _movieService.GetMovieIdByAsync(id);
                var movie = _mapper.Map<Movie>(model);
                return View(movie);
            }
            #endregion

        #endregion

        #region Admin

            #region Edit/Add
            public async Task<IActionResult> Edit(int? Id)
            {
                EditMovie model = new EditMovie();
                List<int> genresIds = new List<int>();
                List<int> personsIds = new List<int>();

                if (Id.HasValue)
                {
                    // get movie              
                    var movie = await _movieService.GetMovieIdByAsync(Id);
                    // get movie genres and add each genresIds into genresIds list
                    movie.Genres.ToList().ForEach(x => genresIds.Add(x.Id));
                    movie.CreativePersons.ToList().ForEach(x => personsIds.Add(x.Id));
                    // mapping
                    var vm = _mapper.Map<EditMovie>(movie);
                    //bind model 
                    model.selectedGenres = _context.Genres
                        .Select(x => new SelectListItem { Text = x.Genre, Value = x.Id.ToString() }).ToList();
                    model.selectedPersons = _context.CreativePersons
                        .Select(x => new SelectListItem { Text = string.Format("{0} {1} ({2})", x.Name, x.SurName), Value = x.Id.ToString() }).ToList();
                    model.Id = vm.Id;
                    model.Title = vm.Title;
                    model.Description = vm.Description;
                    model.ProductionYear = vm.ProductionYear;
                    model.PosterPath = vm.PosterPath;
                    model.TrailerUrl = vm.TrailerUrl;
                    model.IsForKids = vm.IsForKids;
                    model.GenresIds = genresIds.ToArray(); ;
                    model.PersonsIds = personsIds.ToArray(); ;
                }
                else
                {
                    var movie = new MovieModel();
                    model = _mapper.Map<EditMovie>(movie);
                    model.selectedGenres = _context.Genres
                        .Select(x => new SelectListItem { Text = x.Genre, Value = x.Id.ToString() }).ToList();
                    model.selectedPersons = _context.CreativePersons
                        .Select(x => new SelectListItem { Text = string.Format("{0} {1} ({2})", x.Name, x.SurName), Value = x.Id.ToString() }).ToList();
            }
                return View(model);
            }

            [HttpPost]
            public async Task<IActionResult> Edit(EditMovie model)
            {
                MovieModel newMovie = new MovieModel();
                List<MovieGenre> movieGenres = new List<MovieGenre>();
                List<MovieCreativePerson> movieCreativePersons = new List<MovieCreativePerson>();

            if (model.Id > 0)
                {
                    newMovie = await _movieService.GetMovieIdByAsync(model.Id);

                    newMovie.MovieGenres.ToList().ForEach(result => movieGenres.Add(result));
                    newMovie.MovieCreativePersons.ToList().ForEach(result => movieCreativePersons.Add(result));

                    _context.Movie_Genre.RemoveRange(movieGenres);
                    _context.Movie_CreativePerson.RemoveRange(movieCreativePersons);
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

                    if (model.PersonsIds.Length > 0)
                    {
                        movieCreativePersons = new List<MovieCreativePerson>();

                        foreach (var personId in model.PersonsIds)
                        {
                            movieCreativePersons.Add(new MovieCreativePerson { CreativePersonId = personId, MovieId = model.Id });
                        }

                        newMovie.MovieCreativePersons = movieCreativePersons;
                    }

                    _context.SaveChanges();
                }
                else
                {
                    // przypisanie tytułu nowego filmu z pola tytuł
                    newMovie.Title = model.Title;
                    newMovie.Id = _context.Movies.Max(x => x.Id) + 1;
                    newMovie.Description = model.Description;
                    newMovie.ProductionYear = model.ProductionYear;
                    newMovie.PosterPath = model.PosterPath;
                    newMovie.TrailerUrl = model.TrailerUrl;
                    newMovie.IsForKids = model.IsForKids;

                    // jeżeli wybrano przynajmniej jeden gatunek to wtedy: ??
                    if (model.GenresIds.Length > 0)
                    {

                        foreach (var genreId in model.GenresIds)
                        {
                            movieGenres.Add(new MovieGenre { GenreId = genreId, MovieId = model.Id });
                        }

                        newMovie.MovieGenres = movieGenres;
                    }

                    if (model.PersonsIds.Length > 0)
                    {
                        movieCreativePersons = new List<MovieCreativePerson>();

                        foreach (var personId in model.PersonsIds)
                        {
                            movieCreativePersons.Add(new MovieCreativePerson { CreativePersonId = personId, MovieId = model.Id });
                        }

                        newMovie.MovieCreativePersons = movieCreativePersons;
                    }

                    _context.Movies.Add(newMovie);
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
                var movie = _mapper.Map<Movie>(model);

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
