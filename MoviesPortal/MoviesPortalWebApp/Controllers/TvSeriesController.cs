using AutoMapper;
using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using DataAccess.Models;
using DataAccess.Models.EntityAssigments;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MoviesPortalWebApp.Models;
using System.Collections;

namespace MoviesPortalWebApp.Controllers
{
    public class TvSeriesController : Controller
    {
        private readonly ITvSeriesService _tvSeriesService;
        private readonly ISeasonService _seasonService;
        private readonly IEpisodeService _episodeService;
        private readonly IMapper _mapper;
        private readonly MoviePortalContext _context;

        public TvSeriesController(ITvSeriesService tvSeriesService, IMapper mapper, IEpisodeService episodeService, ISeasonService seasonService, MoviePortalContext context)
        {
            _tvSeriesService = tvSeriesService;
            _mapper = mapper;
            _episodeService = episodeService;
            _seasonService = seasonService;
            _context = context;
        }

        // GET: TvSeriesController
        public async Task<ActionResult> Index()
        {
            var result = await _tvSeriesService.GetAll();            
            var tvSeries = _mapper.Map<List<TvSeriesVM>>(result);
            return View(tvSeries);
        }
        public async Task<ActionResult> IndexAdmin()
        {
            var result = await _tvSeriesService.GetAll();
            var tvSeries = _mapper.Map<List<TvSeriesVM>>(result);
            return View(tvSeries);
        }

        // GET: TvSeriesController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var result = await _tvSeriesService.GetById(id);
            var tvSeries = _mapper.Map<TvSeriesVM>(result);
            return View(tvSeries);
        }

        // GET: TvSeriesController/Create
        public async Task<ActionResult> Create()
        {
            TvSeriesVM model = new();
            List<int> genresIds = new List<int>();
            List<int> actorsIds = new List<int>();
            int numbersOfSeasons = 0;

            var series = new TvSeriesModel();
            model = _mapper.Map<TvSeriesVM>(series);
            model.selectedGenres = _context.Genres
                .Select(x => new SelectListItem { Text = x.Genre, Value = x.Id.ToString() }).ToList();
            model.selectedActors = _context.CreativePersons
               .Select(x => new SelectListItem { Text = string.Format("{0} {1}", x.Name, x.SurName), Value = x.Id.ToString() }).ToList();
            model.selectedDirectors = _context.CreativePersons
               .Select(x => new SelectListItem { Text = string.Format("{0} {1}", x.Name, x.SurName), Value = x.Id.ToString() }).ToList();
            model.NumberOfSeasons = numbersOfSeasons;
            return View(model);
        }

        // POST: TvSeriesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TvSeriesVM model)
        {
            TvSeriesModel series = new();
            List<TvSeriesGenre> tvSeriesGenres = new List<TvSeriesGenre>();
            List<TvSeries_CreativeP_Role> tvSeries_CreativeP_Role = new List<TvSeries_CreativeP_Role>();
            List<SeasonModel> seasons = new List<SeasonModel>();

            series.Title = model.Title;
            series.Description = model.Description;
            series.StartYear = model.StartYear;
            series.EndYear = model.EndYear;
            series.PosterPath = model.PosterPath;
            series.TrailerUrl = model.TrailerUrl;
            series.BackgroundPoster = model.BackgroundPoster;
            series.ImdbRatio = model.ImdbRatio; 
            

            if (model.GenresIds.Length > 0)
            {

                foreach (var genreId in model.GenresIds)
                {
                    tvSeriesGenres.Add(new TvSeriesGenre { GenreId = genreId, TvSeriesId = model.Id });
                }

                series.TvSeriesGenres = tvSeriesGenres;
            }

            if (model.ActorsIds.Length > 0)
            {
                foreach (var actorId in model.ActorsIds)
                {
                    tvSeries_CreativeP_Role.Add(new TvSeries_CreativeP_Role { CreativePersonId = actorId, TvSeriesId = model.Id, RoleId = 1 });
                }

                foreach (var drId in model.DirectorsIds)
                {
                    tvSeries_CreativeP_Role.Add(new TvSeries_CreativeP_Role { CreativePersonId = drId, TvSeriesId = model.Id, RoleId = 2 });
                }

                series.TvSeries_CreativeP_Role = tvSeries_CreativeP_Role;
            }
            if (model.NumberOfSeasons > 0)
            {
                for (int i = 1; i <= model.NumberOfSeasons; i++)
                {
                    seasons.Add(new SeasonModel { SeasonNumber = i });
                }
                series.Seasons = seasons;
            }


            _context.TvSeries.Add(series);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: TvSeriesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TvSeriesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TvSeriesController/Delete/5
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await _tvSeriesService.DeleteSeries(id);
            return RedirectToAction(nameof(Index));
        }

        

        public async Task<ActionResult> ListEpisodes(int id)
        {
            var season = await _seasonService.GetSeasonById(id);
            
            var episodes = season.Episodes.ToList();
            var episodesMapped = _mapper.Map<List<EpisodeVM>>(episodes);

            return View(episodesMapped);
        }
    }
}
