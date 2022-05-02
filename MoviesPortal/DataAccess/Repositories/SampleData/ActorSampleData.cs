using DataAccess.Models;
using DataAccess.Models.Enums;

namespace DataAccess.Repositories.SampleData
{
    public static class ActorSampleData
    {
        public static CreativePersonModel sampleActor = new CreativePersonModel()
        {
            Id = 1,
            Name = "Sylvester",
            SurName = "Stallone",
                        

        };
        public static CreativePersonModel sampleDirector = new CreativePersonModel()
        {
            Id = 2,
            Name = "Ted",
            SurName = "Kotcheff",
            

        };
    }
}
