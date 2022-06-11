using AutoMapper;
using BusinessLogic.Services;
using DataAccess.DbContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesPortalWebApp.Models;

namespace MoviesPortalWebApp.Controllers
{
    public class EpisodeController : Controller
    {
        
        private readonly ISeasonService _seasonService;
        private readonly IEpisodeService _episodeService;
        private readonly IMapper _mapper;
        private readonly MoviePortalContext _context;

        // GET: EpisodeController
        public async Task<ActionResult> IndexAdmin(int seasonId)
        {
            var season = await _seasonService.GetSeasonById(seasonId);

            var episodes = season.Episodes.ToList();
            var episodesMapped = _mapper.Map<List<EpisodeVM>>(episodes);

            return View(episodesMapped);
        }

        // GET: EpisodeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EpisodeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EpisodeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(IndexAdmin));
            }
            catch
            {
                return View();
            }
        }

        // GET: EpisodeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EpisodeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(IndexAdmin));
            }
            catch
            {
                return View();
            }
        }

        // GET: EpisodeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EpisodeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(IndexAdmin));
            }
            catch
            {
                return View();
            }
        }
    }
}
