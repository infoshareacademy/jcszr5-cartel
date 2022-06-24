using AutoMapper;
using BusinessLogic.ApiHandler;
using Microsoft.AspNetCore.Mvc;
using MoviesPortalWebApp.Models;

namespace MoviesPortalWebApp.Controllers
{
    public class SearchController : Controller
    {
        private readonly ApiClient _client;
        private readonly IMapper _mapper;

        public SearchController(ApiClient client, IMapper mapper)
        {
            _client = client;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SearchAsync(string queryString)
        {
            var persons =await _client.FindPersonsByName(queryString, 1);
            var movies =await _client.FindMoviesByTitle(queryString, 1, false);
            var MoviesRelatedWithPersons = persons
                .SelectMany(m => m.Known_For)
                .Where(t => t.Title != null);


            movies.AddRange(MoviesRelatedWithPersons);
            var newMovies = movies
                .Where(t => String.IsNullOrEmpty(t.Release_Date) == false && t.Release_Date.Length > 4)
                .ToList();
            

            var mappedPersons = _mapper.Map<List<CreativePersonVM>>(persons);
            var mappedMovies = _mapper.Map<List<MovieVM>>(newMovies);

            SearchResultVM searchResult = new SearchResultVM() { Creatives = mappedPersons, Movies = mappedMovies};
            
            return View(searchResult);
        }
    }
}
