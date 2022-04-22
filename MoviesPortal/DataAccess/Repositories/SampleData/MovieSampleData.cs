using DataAccess.Models;
using DataAccess.Models.Enums;
using DataAccess.Repositories.SampleData;

namespace DataAccess.Repositories
{
    public static class MovieSampleData
    {
        public static MovieModel sampleMovie = new MovieModel()
        {
            
            Id = 1,
            Title = "Rambo",
            ProductionYear = 1982,            
            Description = "John Rambo, były komandos, weteran wojny w Wietnamie, naraża się policjantom z pewnego miasteczka. Ci nie wiedzą, jak groźnym przeciwnikiem jest ten włóczęga.",
            IsForKids = false,
            
        };



    }


}

