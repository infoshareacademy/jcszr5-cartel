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
                PosterPath = "https://i.pinimg.com/originals/17/5c/e9/175ce930a9e1e42c4c0315d4933fc2d1.jpg",
                TrailerUrl = "https://www.youtube.com/watch?v=F-eMt3SrfFU",
                BackgroundPoster = "https://images7.alphacoders.com/855/thumb-1920-855790.jpg",
                ImdbRatio = "7.8",
                IsForKids = false,
            },
            new MovieModel
            {  
                Id = 4,
                Title = "American Sniper",
                ProductionYear = 2014,
                Description = "Navy S.E.A.L. sniper Chris Kyle's pinpoint accuracy saves countless lives on the battlefield and turns him into a legend. Back home with his family after four tours of duty, however, Chris finds that it is the war he can't leave behind.",
                PosterPath = "https://drive.google.com/file/d/1ubmorpefQEGcsXbJy97LK107JfYkCZeN/view?usp=sharing",
                TrailerUrl = "https://www.youtube.com/watch?v=99k3u9ay1gs",
                BackgroundPoster = "",
                ImdbRatio = "7.3",
                IsForKids = false,
            },
            new MovieModel
            {
                Id = 5,
                Title = "Forrest Gump",
                ProductionYear = 1994,
                Description = "The presidencies of Kennedy and Johnson, the Vietnam War, the Watergate scandal and other historical events unfold from the perspective of an Alabama man with an IQ of 75, whose only desire is to be reunited with his childhood sweetheart.",
                PosterPath = "https://drive.google.com/file/d/1xwe8zw0aFAqgsaQxi_NQeUTxYLKxFGs2/view?usp=sharing",
                TrailerUrl = "https://www.youtube.com/watch?v=bLvqoHBptjg",
                BackgroundPoster = "",
                ImdbRatio = "8.8",
                IsForKids = false,
            },
            new MovieModel
            {
                Id = 6,
                Title = "Fury",
                ProductionYear = 2014,
                Description = "A grizzled tank commander makes tough decisions as he and his crew fight their way across Germany in April, 1945.",
                PosterPath = "https://drive.google.com/file/d/12wUK79utIGpLTOtnL3l-rMoj-C_Nv1nh/view?usp=sharing",
                TrailerUrl = "https://www.imdb.com/video/vi1850190873?playlistId=tt2713180&ref_=tt_ov_vi",
                BackgroundPoster = "",
                ImdbRatio = "7.5",
                IsForKids = false,
            },
            new MovieModel
            {
                Id = 7,
                Title = "Gladiator",
                ProductionYear = 2000,
                Description = "A former Roman General sets out to exact vengeance against the corrupt emperor who murdered his family and sent him into slavery.",
                PosterPath = "https://drive.google.com/file/d/1UMAYGciJObSaELHnDNCkYsDPLTJJyosp/view?usp=sharing",
                TrailerUrl = "https://www.imdb.com/video/vi2628367897?playlistId=tt0172495&ref_=tt_pr_ov_vi",
                BackgroundPoster = "",
                ImdbRatio = "8.5",
                IsForKids = false,
            },
            new MovieModel
            {
                Id = 8,
                Title = "The Bourne Identity",
                ProductionYear = 2002,
                Description = "A man is picked up by a fishing boat, bullet-riddled and suffering from amnesia, before racing to elude assassins and attempting to regain his memory.",
                PosterPath = "https://drive.google.com/file/d/1SoQC_cnFOZhMFg_u3H2HBEh3pISVBAYb/view?usp=sharing",
                TrailerUrl = "https://youtu.be/FpKaB5dvQ4g",
                BackgroundPoster = "",
                ImdbRatio = "7.9",
                IsForKids = false,
            },
            new MovieModel
            {
                Id = 9,
                Title = "The Bourne Supremacy",
                ProductionYear = 2017,
                Description = "When Jason Bourne is framed for a CIA operation gone awry, he is forced to resume his former life as a trained assassin to survive.",
                PosterPath = "https://drive.google.com/file/d/1xvFGpVTZ8y4RTBbEIJ_CZWwSp3FbhPPS/view?usp=sharing",
                TrailerUrl = "https://www.youtube.com/watch?v=Y-HqyyfBbSo",
                BackgroundPoster = "",
                ImdbRatio = "7.7",
                IsForKids = false,
            },
            new MovieModel
            {
                Id = 10,
                Title = "The Bourne Ultimatum",
                ProductionYear = 2007,
                Description = "Jason Bourne dodges a ruthless C.I.A. official and his Agents from a new assassination program while searching for the origins of his life as a trained killer.",
                PosterPath = "https://drive.google.com/file/d/1MVVlgzhCRPDAnNsLRXYy46nlHrxbh1pY/view?usp=sharing",
                TrailerUrl = "https://youtu.be/ZT2ZxjUjSo0",
                BackgroundPoster = "",
                ImdbRatio = "8.0",
                IsForKids = false,
            },
            new MovieModel
            {
                Id = 11,
                Title = "Jason Bourne",
                ProductionYear = 2016,
                Description = "The CIA's most dangerous former operative is drawn out of hiding to uncover more explosive truths about his past.",
                PosterPath = "https://drive.google.com/file/d/1sZ_4GFUctmq_VxM63zMImW2LdWTL6k4t/view?usp=sharing",
                TrailerUrl = "https://www.imdb.com/video/vi1805498137?playlistId=tt4196776&ref_=tt_ov_vi",
                BackgroundPoster = "",
                ImdbRatio = "7.8",
                IsForKids = false,
            },
            new MovieModel
            {
                Id = 12,
                Title = "Lara Croft Tomb Raider",
                ProductionYear = 2001,
                Description = "Video game adventurer Lara Croft comes to life in a movie where she races against time and villains to recover powerful ancient artifacts.",
                PosterPath = "https://drive.google.com/file/d/1sgLLKO7Glnr9U9enAn7HjdrTAvzNFu9j/view?usp=sharing",
                TrailerUrl = "https://youtu.be/VlCylyAKpGA",
                BackgroundPoster = "",
                ImdbRatio = "5.7",
                IsForKids = false,
            },
            new MovieModel
            {
                Id = 13,
                Title = "Tomb Raider The Cradle of Life",
                ProductionYear = 2003,
                Description = "Adventurer Lara Croft goes on a quest to save the mythical Pandora's Box, before an evil scientist finds it, and recruits a former Marine turned mercenary to assist her.",
                PosterPath = "https://drive.google.com/file/d/1BUuXI7WmOuoY67y-y_7Aqwmv5hU0nzP0/view?usp=sharing",
                TrailerUrl = "https://youtu.be/G4bhBabn-wU",
                BackgroundPoster = "",
                ImdbRatio = "5.5",
                IsForKids = false,
            },
            new MovieModel
            {
                Id = 14,
                Title = "Tomb Raider",
                ProductionYear = 2018,
                Description = "Lara Croft (Alicia Vikander), the fiercely independent daughter of a missing adventurer, must push herself beyond her limits when she discovers the island where her father, Lord Richard Croft (Dominic West) disappeared.",
                PosterPath = "https://drive.google.com/file/d/1SQcvZrL7kjA7MLGfDBZl2pWaNt92I8fY/view?usp=sharing",
                TrailerUrl = "https://youtu.be/8ndhidEmUbI",
                BackgroundPoster = "",
                ImdbRatio = "6.3",
                IsForKids = false,
            },
            new MovieModel
            {
                Id = 15,
                Title = "The Matrix",
                ProductionYear = 1999,
                Description = "When a beautiful stranger leads computer hacker Neo to a forbidding underworld, he discovers the shocking truth--the life he knows is the elaborate deception of an evil cyber-intelligence.",
                PosterPath = "https://drive.google.com/file/d/17XIWkf4cwp7LI3Tt8qY2cUp68cymFjqj/view?usp=sharing",
                TrailerUrl = "https://youtu.be/vKQi3bBA1y8",
                BackgroundPoster = "",
                ImdbRatio = "8.7",
                IsForKids = false,
            },
            new MovieModel
            {
                Id = 16,
                Title = "The Matrix Reloaded",
                ProductionYear = 2003,
                Description = "Freedom fighters Neo, Trinity and Morpheus continue to lead the revolt against the Machine Army, unleashing their arsenal of extraordinary skills and weaponry against the systematic forces of repression and exploitation.",
                PosterPath = "https://drive.google.com/file/d/1ojvVyQAwChj5d8aMH6mZ67rxlAR8uTb3/view?usp=sharing",
                TrailerUrl = "https://youtu.be/zmYE3tg26Qc",
                BackgroundPoster = "",
                ImdbRatio = "7.2",
                IsForKids = false,
            },
            new MovieModel
            {
                Id = 17,
                Title = "The Matrix Revolutions",
                ProductionYear = 2003,
                Description = "The human city of Zion defends itself against the massive invasion of the machines as Neo fights to end the war at another front while also opposing the rogue Agent Smith.",
                PosterPath = "https://drive.google.com/file/d/1d1jCZlxMP-XLHM7qAYIUkMITnz8B5SbU/view?usp=sharing",
                TrailerUrl = "https://youtu.be/hMbexEPAOQI",
                BackgroundPoster = "",
                ImdbRatio = "6.7",
                IsForKids = false,
            },
            new MovieModel
            {
                Id = 18,
                Title = "The Matrix Resurrections",
                ProductionYear = 2021,
                Description = "Return to a world of two realities: one, everyday life; the other, what lies behind it. To find out if his reality is a construct, to truly know himself, Mr. Anderson will have to choose to follow the white rabbit once more.",
                PosterPath = "https://drive.google.com/file/d/1RsRaza_JC5w4_6aPl4vM3QuD-ENk4jUZ/view?usp=sharing",
                TrailerUrl = "https://youtu.be/9ix7TUGVYIo",
                BackgroundPoster = "",
                ImdbRatio = "5.7",
                IsForKids = false,
            },
            new MovieModel
            {
                Id = 19,
                Title = "Mr & Mrs Smith",
                ProductionYear = 2005,
                Description = "A bored married couple is surprised to learn that they are both assassins hired by competing agencies to kill each other.",
                PosterPath = "https://drive.google.com/file/d/1ZvEDxYPRWweYP2VQGucS1I_TJ-i_HPgn/view?usp=sharing",
                TrailerUrl = "https://youtu.be/CZ0B22z22pI",
                BackgroundPoster = "",
                ImdbRatio = "6.5",
                IsForKids = false,
            },
            new MovieModel
            {
                Id = 20,
                Title = "Ocean's Eleven",
                ProductionYear = 2001,
                Description = "Danny Ocean and his ten accomplices plan to rob three Las Vegas casinos simultaneously.",
                PosterPath = "https://drive.google.com/file/d/1FW02lDizH6K5Waer9n0EDe_J8bgTIEOO/view?usp=sharing",
                TrailerUrl = "https://youtu.be/imm6OR605UI",
                BackgroundPoster = "",
                ImdbRatio = "7.7",
                IsForKids = false,
            },
            new MovieModel
            {
                Id = 21,
                Title = "Ocean's Twelve",
                ProductionYear = 2004,
                Description = "Daniel Ocean recruits one more team member so he can pull off three major European heists in this sequel to Ocean's Eleven (2001).",
                PosterPath = "https://drive.google.com/file/d/1RiCgEjwWMsggk2FCuRC2hTZn1h48B_gT/view?usp=sharing",
                TrailerUrl = "https://youtu.be/k9uhRSLMORw",
                BackgroundPoster = "",
                ImdbRatio = "6.4",
                IsForKids = false,
            },
            new MovieModel
            {
                Id = 22,
                Title = "Ocean's Thirteen",
                ProductionYear = 2007,
                Description = "Danny Ocean rounds up the boys for a third heist after casino owner Willy Bank double-crosses one of the original eleven, Reuben Tishkoff.",
                PosterPath = "https://drive.google.com/file/d/1Zh3OFLHAh4JXMtfwmaQQQzpm9-L5-S_X/view?usp=sharing",
                TrailerUrl = "https://youtu.be/so9Eh-Guci8",
                BackgroundPoster = "",
                ImdbRatio = "6.9",
                IsForKids = false,
            },
            new MovieModel
            {
                Id = 23,
                Title = "Rambo II",
                ProductionYear = 1985,
                Description = "Rambo returns to the jungles of Vietnam on a mission to infiltrate an enemy base-camp and rescue the American POWs still held captive there.",
                PosterPath = "https://drive.google.com/file/d/1L-vC9i6dU_ADNykO-OOkWKwKPNc3WuCj/view?usp=sharing",
                TrailerUrl = "https://youtu.be/WQGJAIYtWD4",
                BackgroundPoster = "",
                ImdbRatio = "6.5",
                IsForKids = false,
            },
            new MovieModel
            {
                Id = 24,
                Title = "Rambo III",
                ProductionYear = 1988,
                Description = "Rambo mounts a one-man mission to rescue his friend Colonel Trautman from the clutches of the formidable invading Soviet forces in Afghanistan.",
                PosterPath = "https://drive.google.com/file/d/1RrKOIRkqW6klpOQ1G5F-kXonXJip9v00/view?usp=sharing",
                TrailerUrl = "https://youtu.be/IQt9bDOGTgg",
                BackgroundPoster = "",
                ImdbRatio = "5.8",
                IsForKids = false,
            },
            new MovieModel
            {
                Id = 25,
                Title = "The Green Mile",
                ProductionYear = 1999,
                Description = "The lives of guards on Death Row are affected by one of their charges: a black man accused of child murder and rape, yet who has a mysterious gift.",
                PosterPath = "https://drive.google.com/file/d/1ixqYqYP1cJ8WePqcvEc46uku-dbbwrzp/view?usp=sharing",
                TrailerUrl = "https://youtu.be/Ki4haFrqSrw",
                BackgroundPoster = "",
                ImdbRatio = "8.6",
                IsForKids = false,
            }
            //new MovieModel
            //{
            //    Id = 26,
            //    Title = "",
            //    ProductionYear = 2017,
            //    Description = "",
            //    PosterPath = "",
            //    TrailerUrl = "",
            //    BackgroundPoster = "",
            //    ImdbRatio = "7.8",
            //    IsForKids = false,
            //},
            //new MovieModel
            //{
            //    Id = 27,
            //    Title = "",
            //    ProductionYear = 2017,
            //    Description = "",
            //    PosterPath = "",
            //    TrailerUrl = "",
            //    BackgroundPoster = "",
            //    ImdbRatio = "7.8",
            //    IsForKids = false,
            //},
            
         };
    }
}
