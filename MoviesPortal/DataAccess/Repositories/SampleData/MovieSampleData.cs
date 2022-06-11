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
                BackgroundPoster = "https://blog.hdwallsource.com/wp-content/uploads/2018/05/avengers-infinity-war-thanos-wallpaper-63589-65679-hd-wallpapers.jpg",
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
                BackgroundPoster = "https://images7.alphacoders.com/100/1004126.png",
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
                PosterPath = "https://i.pinimg.com/originals/f2/87/36/f28736d093de503e783c4bf247230cb3.jpg",
                TrailerUrl = "https://www.youtube.com/watch?v=0xQSIdSRlAk",
                BackgroundPoster = "https://images2.alphacoders.com/865/thumb-1920-86520.jpg",
                ImdbRatio = "8.4",
                IsForKids = true,
            },
            new MovieModel
            {
                Id = 10,
                Title = "Indiana Jones and the Last Crusade",
                ProductionYear = 1989,
                Description = "In 1938, after his father Professor Henry Jones, Sr. goes missing while pursuing the Holy Grail, Professor Henry 'Indiana' Jones, Jr. finds himself up against Adolf Hitler's Nazis again to stop them from obtaining its powers.",
                PosterPath = "https://static.squarespace.com/static/51b3dc8ee4b051b96ceb10de/51ce6099e4b0d911b4489b79/51ce61e9e4b0d911b44a5773/1328897573177/1000w/temple-of-doom-minimalist-print.jpg",
                TrailerUrl = "https://www.youtube.com/watch?v=DKg36LBVgfg",
                BackgroundPoster = "https://wallpapercave.com/wp/wp4119239.jpg",
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
                BackgroundPoster = "https://images.hdqwalls.com/wallpapers/the-dark-knight-aftermath-4k-yk.jpg",
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
            },
            new MovieModel
            {
                Id = 14,
                Title = "Fight Club",
                ProductionYear = 1999,
                Description = "An insomniac office worker and a devil-may-care soap maker form an underground fight club that evolves into much more.",
                PosterPath = "https://i.pinimg.com/736x/2e/0c/ee/2e0ceec2f8bc16b562a8cec2d4d1b86f.jpg",
                TrailerUrl = "https://www.youtube.com/watch?v=O1nDozs-LxI",
                BackgroundPoster = "https://images.alphacoders.com/204/thumb-1920-204781.jpg",
                ImdbRatio = "8.8",
                IsForKids = false,
            },
            new MovieModel
            {
                Id = 15,
                Title = "Se7en",
                ProductionYear = 1995,
                Description = "Two detectives, a rookie and a veteran, hunt a serial killer who uses the seven deadly sins as his motives.",
                PosterPath = "https://i.pinimg.com/originals/9a/6b/92/9a6b929842b8affe801112608266087b.jpg",
                TrailerUrl = "https://www.youtube.com/watch?v=znmZoVkCjpI",
                BackgroundPoster = "https://c4.wallpaperflare.com/wallpaper/580/168/4/movie-se7en-brad-pitt-wallpaper-preview.jpg",
                ImdbRatio = "8.6",
                IsForKids = false,
            },
            new MovieModel
            {
                Id = 16,
                Title = "The Social Network",
                ProductionYear = 2010,
                Description = "As Harvard student Mark Zuckerberg creates the social networking site that would become known as Facebook, he is sued by the twins who claimed he stole their idea, and by the co-founder who was later squeezed out of the business.",
                PosterPath = "https://i.pinimg.com/originals/df/1b/a2/df1ba2a4e5d4f8a99a323261df3be7ee.jpg",
                TrailerUrl = "https://www.youtube.com/watch?v=lB95KLmpLR4",
                BackgroundPoster = "https://www.axn.pl/sites/pl.fern.axn/files/ct_movie_f_primary_image/socialnetwork.jpg",
                ImdbRatio = "7.8",
                IsForKids = false,
            },
            new MovieModel
            {
                Id = 17,
                Title = "Zodiac",
                ProductionYear = 2007,
                Description = "Between 1968 and 1983, a San Francisco cartoonist becomes an amateur detective obsessed with tracking down the Zodiac Killer, an unidentified individual who terrorizes Northern California with a killing spree.",
                PosterPath = "https://64.media.tumblr.com/0d4d9f32780322b9c0fe71857904d6cf/11a1f8baccb49d40-8b/s540x810/2b46dc8aaa865250e899a5fb42eedf47de4d6823.jpg",
                TrailerUrl = "https://www.youtube.com/watch?v=yNncHPl1UXg",
                BackgroundPoster = "https://www.highonfilms.com/wp-content/uploads/2017/10/zodiac-downey-gyllenhaal.jpg",
                ImdbRatio = "7.7",
                IsForKids = false,
            },
            new MovieModel
            {
                Id = 18,
                Title = "Doctor Strange in the Multiverse of Madness",
                ProductionYear = 2022,
                Description = "Dr. Stephen Strange casts a forbidden spell that opens the doorway to the multiverse, including alternate versions of himself, whose threat to humanity is too great for the combined forces of Strange, Wong, and Wanda Maximoff.",
                PosterPath = "https://alternativemovieposters.com/wp-content/uploads/2019/09/knotek_drstrange.jpg",
                TrailerUrl = "https://www.youtube.com/watch?v=aWzlQ2N6qqg",
                BackgroundPoster = "https://images.squarespace-cdn.com/content/v1/51b3dc8ee4b051b96ceb10de/911c7616-5036-4b64-9039-77ce53af8f52/limited-edition-poster-art-for-doctor-strange-in-the-multiverse-of-madness-from-artist-matt-ferguson.jpg",
                ImdbRatio = "7.6",
                IsForKids = true,
            }
         };
    }
}
