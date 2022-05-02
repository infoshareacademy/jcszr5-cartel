using DataAccess.Models;
using DataAccess.Models.Enums;

namespace DataAccess.Repositories.SampleData
{
    public static class ActorSampleData
    {
        public static IList<CreativePersonModel> sampleActors = new List<CreativePersonModel>()
        {
            new CreativePersonModel
            {
                Id = 1,
                Name = "Sylvester",
                SurName = "Stallone",
                PhotographyPath = "https://i.pinimg.com/originals/be/8f/3d/be8f3dfb132eb1b867379235d75a37b1.jpg",
                DateOfBirth = new DateTime(1946, 7, 6)
            },
            new CreativePersonModel
            {
                Id = 2,
                Name = "Tom",
                SurName = "Hardy",
                PhotographyPath = "https://i.pinimg.com/originals/9d/73/d6/9d73d68e972ef3fd416f38c780e901ff.jpg",
                DateOfBirth = new DateTime(1977, 9, 15)
            },
            new CreativePersonModel
            {
                Id = 3,
                Name = "Chris",
                SurName = "Hemsworth",
                PhotographyPath = "https://i.pinimg.com/originals/13/62/b3/1362b30b97ed513559b4f28a5a3823f2.png",
                DateOfBirth = new DateTime(1983, 8, 11)
            },
            new CreativePersonModel
            {
                Id = 4,
                Name = "Cillian",
                SurName = "Murphy",
                PhotographyPath = "https://i.pinimg.com/originals/01/aa/d4/01aad42f699f2bc8d0225047e7b23e03.jpg",
                DateOfBirth = new DateTime(1976, 5, 25)
            },
            new CreativePersonModel
            {
                Id = 5,
                Name = "Taika",
                SurName = "Waititi",
                PhotographyPath = "https://i.pinimg.com/originals/74/e4/a5/74e4a59cb0e2a110166fd2eef714ad37.jpg",
                DateOfBirth = new DateTime(1975, 8, 16)
            },
            new CreativePersonModel
            {
                Id = 6,
                Name = "Ted",
                SurName = "Kotcheff",
                PhotographyPath = "https://tce-live2.s3.amazonaws.com/media/media/74b70c1f-c4c4-4b77-9c6f-114cb1d62fdb.jpg",
                DateOfBirth = new DateTime(1931, 4, 7)
            },
            new CreativePersonModel
            {
                Id = 7,
                Name = "Christopher",
                SurName = "Nolan",
                PhotographyPath = "https://i.pinimg.com/originals/6e/76/07/6e76076e9b218373ff054e57e6c307db.jpg",
                DateOfBirth = new DateTime(1970, 7, 30)
            },
            new CreativePersonModel
            {
                Id = 8,
                Name = "Cate",
                SurName = "Blanchett",
                PhotographyPath = "https://i.pinimg.com/originals/d5/23/75/d52375bb559b121f8221877db8b653a8.jpg",
                DateOfBirth = new DateTime(1969, 4, 14)
            }
        };
        //public static CreativePersonModel sampleDirector = new CreativePersonModel()
        //{
        //    Id = 2,
        //    Name = "Ted",
        //    SurName = "Kotcheff",
            

        //};
    }
}
