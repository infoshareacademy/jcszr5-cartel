using DataAccess.Models;
using DataAccess.Models.Enums;

namespace DataAccess.Repositories.SampleData
{
    public static class Actor
    {
        public static DbCreativePersonModel sampleActor = new DbCreativePersonModel()
        {
            Id = 1,
            Name = "Sylvester",
            SurName = "Stallone",
            Role = CreativeRole.Actor,            

        };
        public static DbCreativePersonModel sampleDirector = new DbCreativePersonModel()
        {
            Id = 2,
            Name = "Ted",
            SurName = "Kotcheff",
            Role = CreativeRole.Director,

        };
    }
}
