using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.SampleData
{
    public static class GenreSampleData
    {
        public static List<GenreModel> sampleGenres = new List<GenreModel>()
        {
            new GenreModel()
            {
                Id = 1,
                Genre = "Action"                
            },
            new GenreModel()
            {
                Id = 2,
                Genre = "adventure"
            },
            new GenreModel()
            {
                Id = 3,
                Genre = "animated"
            },
            new GenreModel()
            {
                Id = 4,
                Genre = "comedy"
            },
            new GenreModel()
            {
                Id = 5,
                Genre = "drama"
            },
            new GenreModel()
            {
                Id = 6,
                Genre = "fantasy"
            },
            new GenreModel()
            {
                Id = 7,
                Genre = "historical"
            },
            new GenreModel()
            {
                Id = 8,
                Genre = "horror"
            },
            new GenreModel()
            {
                Id = 9,
                Genre = "sciFi"
            },
            new GenreModel()
            {
                Id = 10,
                Genre = "thriller"
            },
            new GenreModel()
            {
                Id = 11,
                Genre = "western"
            }
        };
    }
}
