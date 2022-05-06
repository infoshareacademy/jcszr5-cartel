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
                Title = "Rambo: First Blood",
                ProductionYear = 1982,
                Description = "A veteran Green Beret is forced by a cruel Sheriff and his deputies to flee into the mountains and wage an escalating one-man war against his pursuers.",
                PosterPath = "https://alternativemovieposters.com/wp-content/uploads/2015/03/gabz_firstblood700.jpg",
                TrailerUrl = "https://www.youtube.com/watch?v=IAqLKlxY3Eo",
                BackgroundPoster = "https://c4.wallpaperflare.com/wallpaper/1012/513/237/action-adventure-drama-film-wallpaper-preview.jpg",
                ImdbRatio = "7.7",
                IsForKids = false,
            },
            new MovieModel
            {  
                Id = 2,
                Title = "Thor: Ragnarok",
                ProductionYear = 2017,
                Description = "Imprisoned on the planet Sakaar, Thor must race against time to return to Asgard and stop Ragnarök, the destruction of his world, at the hands of the powerful and ruthless villain Hela.",
                PosterPath = "https://alternativemovieposters.com/wp-content/uploads/2020/06/Juan-Ramos_thorragnarok.jpg",
                TrailerUrl = "https://www.youtube.com/watch?v=ue80QwXMRHg",
                BackgroundPoster = "https://images.hdqwalls.com/wallpapers/art-thor-ragnarok-we.jpg",
                ImdbRatio = "7.9",
                IsForKids = true,
            },
            new MovieModel
            {  
                Id = 3,
                Title = "Dunkirk",
                ProductionYear = 2017,
                Description = "Allied soldiers from Belgium, the British Commonwealth and Empire, and France are surrounded by the German Army and evacuated during a fierce battle in World War II.",
                PosterPath = "https://alternativemovieposters.com/wp-content/uploads/2019/10/duperray_dunkirk.jpg",
                TrailerUrl = "https://www.youtube.com/watch?v=F-eMt3SrfFU",
                BackgroundPoster = "https://wallpaperaccess.com/full/3528110.jpg",
                ImdbRatio = "7.8",
                IsForKids = false,
            },
            new MovieModel
            {
                Id = 4,
                Title = "Avengers: Infinity War",
                ProductionYear = 2018,
                Description = "The Avengers and their allies must be willing to sacrifice all in an attempt to defeat the powerful Thanos before his blitz of devastation and ruin puts an end to the universe.",
                PosterPath = "https://alternativemovieposters.com/wp-content/uploads/2018/05/bergeron_infinity.jpg",
                TrailerUrl = "https://www.youtube.com/watch?v=6ZfuNTqbHE8",
                BackgroundPoster = "https://cdnb.artstation.com/p/assets/images/images/010/440/503/large/lee-j-p-1.jpg?1524459988",
                ImdbRatio = "8.4",
                IsForKids = true,
            },
            new MovieModel
            {
                Id = 5,
                Title = "Captain America: Civil War",
                ProductionYear = 2016,
                Description = "Political involvement in the Avengers' affairs causes a rift between Captain America and Iron Man.",
                PosterPath = "https://alternativemovieposters.com/wp-content/uploads/2016/06/walker_civilwar.jpg",
                TrailerUrl = "https://www.youtube.com/watch?v=dKrVegVI0Us",
                BackgroundPoster = "https://s2.best-wallpaper.net/wallpaper/2880x1800/1805/Captain-America-Civil-War-art-picture_2880x1800.jpg",
                ImdbRatio = "7.8",
                IsForKids = true,
            },
            new MovieModel
            {
                Id = 6,
                Title = "Star Wars: Episode IV - New Hope",
                ProductionYear = 1977,
                Description = "Luke Skywalker joins forces with a Jedi Knight, a cocky pilot, a Wookiee and two droids to save the galaxy from the Empire's world-destroying battle station, while also attempting to rescue Princess Leia from the mysterious Darth Vader.",
                PosterPath = "https://alternativemovieposters.com/wp-content/uploads/2021/12/AlexHovey_NewHope.jpg",
                TrailerUrl = "https://www.youtube.com/watch?v=vZ734NWnAHA",
                BackgroundPoster = "https://images2.alphacoders.com/523/thumb-1920-523274.jpg",
                ImdbRatio = "8.6",
                IsForKids = true,
            },
            new MovieModel
            {
                Id = 7,
                Title = "Star Wars: Episode V - The Empire Strikes Back",
                ProductionYear = 1980,
                Description = "After the Rebels are brutally overpowered by the Empire on the ice planet Hoth, Luke Skywalker begins Jedi training with Yoda, while his friends are pursued across the galaxy by Darth Vader and bounty hunter Boba Fett.",
                PosterPath = "https://alternativemovieposters.com/wp-content/uploads/2021/12/AlexHovey_Empire.jpg",
                TrailerUrl = "https://www.youtube.com/watch?v=JNwNXF9Y6kY",
                BackgroundPoster = "https://wallpaperaccess.com/full/1602841.jpg",
                ImdbRatio = "8.7",
                IsForKids = true,
            },   
            new MovieModel
            {
                Id = 8,
                Title = "Star Wars: Episode VI - Return of the Jedi",
                ProductionYear = 1983,
                Description = "After a daring mission to rescue Han Solo from Jabba the Hutt, the Rebels dispatch to Endor to destroy the second Death Star. Meanwhile, Luke struggles to help Darth Vader back from the dark side without falling into the Emperor's trap.",
                PosterPath = "https://alternativemovieposters.com/wp-content/uploads/2021/12/AlexHovey_Jedi.jpg",
                TrailerUrl = "https://www.youtube.com/watch?v=5UfA_aKBGMc",
                BackgroundPoster = "https://images5.alphacoders.com/339/thumb-1920-339210.jpg",
                ImdbRatio = "8.3",
                IsForKids = true,
            },
            new MovieModel
            {
                Id = 9,
                Title = "Raiders of the Lost Ark",
                ProductionYear = 1981,
                Description = "In 1936, archaeologist and adventurer Indiana Jones is hired by the U.S. government to find the Ark of the Covenant before Adolf Hitler's Nazis can obtain its awesome powers.",
                PosterPath = "https://cdn.shopify.com/s/files/1/1057/4964/products/Raiders-of-the-Lost-Ark-Vintage-Movie-Poster-Original-1-Sheet-27x41-7665.jpg?v=1643864480",
                TrailerUrl = "https://www.youtube.com/watch?v=0xQSIdSRlAk",
                BackgroundPoster = "https://www.deviantart.com/spirit--of-adventure/art/Raiders-of-the-Lost-Ark-Wallpaper-852520409",
                ImdbRatio = "8.4",
                IsForKids = true,
            },
            new MovieModel
            {
                Id = 10,
                Title = "Indiana Jones and the Last Crusade",
                ProductionYear = 1989,
                Description = "In 1938, after his father Professor Henry Jones, Sr. goes missing while pursuing the Holy Grail, Professor Henry 'Indiana' Jones, Jr. finds himself up against Adolf Hitler's Nazis again to stop them from obtaining its powers.",
                PosterPath = "https://m.media-amazon.com/images/I/91uXYJym1dL._AC_SL1500_.jpg",
                TrailerUrl = "https://www.youtube.com/watch?v=DKg36LBVgfg",
                BackgroundPoster = "https://www.deviantart.com/spirit--of-adventure/art/The-Last-Crusade-Wallpaper-852714249",
                ImdbRatio = "8.2",
                IsForKids = true,
            },
            new MovieModel
            {
                Id = 11,
                Title = "Interstellar",
                ProductionYear = 2014,
                Description = "A team of explorers travel through a wormhole in space in an attempt to ensure humanity's survival.",
                PosterPath = "https://alternativemovieposters.com/wp-content/uploads/2020/05/daus_interstellar.jpg",
                TrailerUrl = "https://www.youtube.com/watch?v=zSWdZVtXT7E",
                BackgroundPoster = "https://images5.alphacoders.com/585/thumb-1920-585645.png",
                ImdbRatio = "8.6",
                IsForKids = true,
            },
            new MovieModel
            {
                Id = 12,
                Title = "The Dark Knight",
                ProductionYear = 2008,
                Description = "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice.",
                PosterPath = "https://cdn.shopify.com/s/files/1/0071/5192/products/Screen_Shot_2017-12-06_at_17.45.00_1024x1024.png?v=1512583353",
                TrailerUrl = "https://www.youtube.com/watch?v=EXeTwQWrcwY",
                BackgroundPoster = "https://c4.wallpaperflare.com/wallpaper/475/754/518/joker-street-the-dark-knight-clown-mask-wallpaper-preview.jpg",
                ImdbRatio = "9.0",
                IsForKids = false,
            },
            new MovieModel
            {
                Id = 13,
                Title = "Her",
                ProductionYear = 2013,
                Description = "In a near future, a lonely writer develops an unlikely relationship with an operating system designed to meet his every need.",
                PosterPath = "https://alternativemovieposters.com/wp-content/uploads/2018/05/AMP_Her.png",
                TrailerUrl = "https://www.youtube.com/watch?v=ne6p6MfLBxc",
                BackgroundPoster = "https://images4.alphacoders.com/645/thumb-1920-645704.jpeg",
                ImdbRatio = "8.0",
                IsForKids = false,
            }
         };
    }
}
