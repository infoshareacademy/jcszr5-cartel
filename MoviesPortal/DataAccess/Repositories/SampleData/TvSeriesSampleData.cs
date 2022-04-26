using DataAccess.Models;

namespace DataAccess.Repositories.SampleData
{
    public static class TvSeriesSampleData
    {

        public static TvSeriesModel sampleSeries = new()
        {

            Id = 1,
            Title = "Mr. Robot",
            Genres = new List<GenreModel> { new GenreModel() { Id = 5, Genre = "drama"} },
            StartYear = 2015,
            EndYear = 2019,
            PosterPath = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Ftse1.mm.bing.net%2Fth%3Fid%3DOIP.FOw2q2V6dbpwXdxDisylwQHaKj%26pid%3DApi&f=1",
            TrailerUrl = "https://www.youtube.com/watch?v=U94litUpZuc",
            Description = "Elliot (Rami Malek) to cierpiący na fobię społeczną, niewyróżniający się z tłumu, skryty w sobie programista. Jest specjalistą od cyberbezpieczeństwa w dużej korporacji AllSafe. Pewnego dnia spotyka tajemniczego anarchistę i hakera, tytułowego Mr. Robota.",
            Seasons = new List<SeasonModel> { new SeasonModel() { Id = 1, SeasonNumber =1, }, new SeasonModel() { Id = 1, SeasonNumber = 1 }, new SeasonModel() { Id = 2, SeasonNumber = 2 }, new SeasonModel() { Id = 3, SeasonNumber = 3 }, new SeasonModel() { Id = 4, SeasonNumber = 4 } },
            CreativePersons = new List<CreativePersonModel> { new CreativePersonModel() { Name = "Rami", SurName = "Malek", DateOfBirth = DateTime.Now.Date.AddYears(-31), Role = 0,  }, }
        };




    }
}
