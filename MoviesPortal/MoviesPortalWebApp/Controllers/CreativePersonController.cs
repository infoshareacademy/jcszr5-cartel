using AutoMapper;
using BusinessLogic.Services;
using DataAccess.Models;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using MoviesPortalWebApp.Models;

namespace MoviesPortalWebApp.Controllers
{
    public class CreativePersonController : Controller
    {
        private readonly ICreativePersonService _creativePersonService;
        private readonly IMapper _mapper;

        private readonly MoviePortalContext _context;

        public CreativePersonController(ICreativePersonService creativePersonService, IMapper mapper, MoviePortalContext context)
        {
            _creativePersonService = creativePersonService;
            _mapper = mapper;
            _context = context;
        }

        #region User
            #region User creative persons list
            public async Task<IActionResult> IndexUser()
            {
                var model = await _creativePersonService.GetAllCreativePersons();
                var persons = _mapper.Map<IList<CreativePersonVM>>(model);
                return View(persons);
            }
            #endregion

            #region User creative person details
            public async Task<IActionResult> DetailsUser(int id)
            {
                var model = await _creativePersonService.GetCreativePersonsById(id);
                var person = _mapper.Map<CreativePersonVM>(model);
                return View(person);
            }
            #endregion
        #endregion

        #region Admin

            #region Admin creative persons list
            public async Task<IActionResult> Index()
            {
                var model = await _creativePersonService.GetAllCreativePersons();
                var persons = _mapper.Map<IList<CreativePersonVM>>(model);
                return View(persons);
            }
            #endregion

            #region Admin creative person details
            public async Task<IActionResult> Details(int id)
            {
                var model = await _creativePersonService.GetCreativePersonsById(id);
                var person = _mapper.Map<CreativePersonVM>(model);
                return View(person);
            }
            #endregion

            #region Create
            // GET: CreatePersonController/Create
            public async Task<IActionResult> Create()
            {            
                return View();
            }

            // POST: CreatePersonController/Create
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create(CreativePersonVM creativePersonVM )
            {
                var list = await _creativePersonService.GetAllCreativePersons();

                foreach(var p in list)
                {
                    if (p.Name == creativePersonVM.Name && p.SurName == creativePersonVM.SurName && p.DateOfBirth == creativePersonVM.DateOfBirth)
                    {
                        ModelState.AddModelError("", "Current Creative Person with the same date of birth exist in database.");
                        return View(creativePersonVM);
                    }
                }

                var person = _mapper.Map<CreativePersonModel>(creativePersonVM);
                person.Id = _context.CreativePersons.Max(x => x.Id) + 1;
                await _creativePersonService.CreateAsync(person);
                return RedirectToAction(nameof(Index));
            }
        #endregion

            #region Edit

            // GET: CreativePersonController/Edit/5
            public async Task<IActionResult> Edit(int id)
            {
                var model = await _creativePersonService.GetCreativePersonsById(id);
                var person = _mapper.Map<CreativePersonVM>(model);
                return View(person);
            }

            // POST: CreativePersonController/Edit/5
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, CreativePersonVM creativePersonVM)
            {
                if (id != creativePersonVM.Id)
                {
                    return NotFound();
                }

                var person = _mapper.Map<CreativePersonModel>(creativePersonVM);
                await _creativePersonService.EditAsync(id, person);
                return RedirectToAction(nameof(Index));
            }

        #endregion

        #region Delete
        // GET: CreativePersonController/Delete/5
        public async Task<IActionResult> Delete(int id)
                {
                    if (id == null)
                    {
                        return NotFound();
                    }

                    var model = await _creativePersonService.GetCreativePersonsById(id);
                    var person = _mapper.Map<CreativePersonVM>(model);

                    if (person == null)
                    {
                        return NotFound();
                    }

                    return View(person);
                }

                // POST: CreativePersonController/Delete/5
                [HttpPost, ActionName("Delete")]
                [ValidateAntiForgeryToken]
                public async Task<IActionResult> DeleteConfirmed(int id)
                {
                    await _creativePersonService.DeleteCreativePersonByIdAsync(id);
                    return RedirectToAction(nameof(Index));
                }
                #endregion


        #endregion


    }
}