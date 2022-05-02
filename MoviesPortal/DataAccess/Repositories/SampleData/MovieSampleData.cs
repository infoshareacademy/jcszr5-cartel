using DataAccess.Models;
using DataAccess.Models.Enums;
using DataAccess.Repositories.SampleData;

namespace DataAccess.Repositories
{
    public static class MovieSampleData
    {
        public static IList<MovieModel> sampleMovies = new List<MovieModel>()
        {
            new MovieModel
            {  
                Id = 1,
                Title = "Rambo",
                ProductionYear = 1982,
                Description = "John Rambo, były komandos, weteran wojny w Wietnamie, naraża się policjantom z pewnego miasteczka. Ci nie wiedzą, jak groźnym przeciwnikiem jest ten włóczęga.",
                PosterPath = "https://i.ebayimg.com/images/g/GB4AAOSwd1tdqF8D/s-l400.jpg",
                TrailerUrl = "https://www.youtube.com/watch?v=IAqLKlxY3Eo",
                BackgroundPoster = "https://i.ytimg.com/vi/IAqLKlxY3Eo/maxresdefault.jpg",
                ImdbRatio = "7.7",
                IsForKids = false,
            },
            new MovieModel
            {  
                Id = 2,
                Title = "Thor: Ragnarok",
                ProductionYear = 2017,
                Description = "Imprisoned on the planet Sakaar, Thor must race against time to return to Asgard and stop Ragnarök, the destruction of his world, at the hands of the powerful and ruthless villain Hela.",
                PosterPath = "https://preview.redd.it/hz8qlbfo4gr11.jpg?auto=webp&s=04d74ee2edec633bb566bb4801392f29fa5db299",
                TrailerUrl = "https://www.youtube.com/watch?v=v7MGUNV8MxU",
                BackgroundPoster = "https://c4.wallpaperflare.com/wallpaper/21/588/836/thor-ragnarok-4k-download-hd-for-desktop-wallpaper-preview.jpg",
                ImdbRatio = "7.9",
                IsForKids = true,
            },
            new MovieModel
            {  
                Id = 3,
                Title = "Dunkirk",
                ProductionYear = 2017,
                Description = "Allied soldiers from Belgium, the British Commonwealth and Empire, and France are surrounded by the German Army and evacuated during a fierce battle in World War II.",
                PosterPath = "https://cdn.inprnt.com/thumbs/31/86/31865375aaa94c92ffef48c96dbd9024.jpg?response-cache-control=max-age=2628000",
                TrailerUrl = "https://www.youtube.com/watch?v=F-eMt3SrfFU",
                BackgroundPoster = "https://images7.alphacoders.com/855/thumb-1920-855790.jpg",
                ImdbRatio = "7.8",
                IsForKids = false,
            }
         };
    }
}
