using AutoMapper;
using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesPortalWebApp.Models;
using System.Collections;

namespace MoviesPortalWebApp.Controllers
{
    public class TvSeriesController : Controller
    {
        private readonly ITvSeriesService _tvSeriesService;
        private readonly IMapper _mapper;

        public TvSeriesController(ITvSeriesService tvSeriesService, IMapper mapper)
        {
            _tvSeriesService = tvSeriesService;
            _mapper = mapper;
        }

        // GET: TvSeriesController
        public async Task<ActionResult> Index()
        {
            var result = await _tvSeriesService.GetAll();            
            var tvSeries = _mapper.Map<List<TvSeriesVM>>(result);
            return View(tvSeries);
        }

        // GET: TvSeriesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TvSeriesController/Create
        public async Task<ActionResult> Create()
        {
            return View();

        }

        // POST: TvSeriesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TvSeriesVM tvSeries)
        {
            if (ModelState.IsValid)
            {
                var result = _mapper.Map<TvSeriesModel>(tvSeries);
                await _tvSeriesService.CreateNewSeries(result);
                return RedirectToAction(nameof(Index));
            }
            return View(await Index());
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
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TvSeriesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
    }
}
