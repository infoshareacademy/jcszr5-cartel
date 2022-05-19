using DataAccess.Models.EntityAssigments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityConfigurations
{
    internal class MovieGenreEntityConfiguration : IEntityTypeConfiguration<MovieGenre>
    {
        public void Configure(EntityTypeBuilder<MovieGenre> builder)
        {
            builder.HasData(
                new MovieGenre
                {
                    Id = 1,
                    GenreId = 1,
                    MovieId = 1,

                },
                new MovieGenre
                {
                    Id = 2,
                    GenreId = 10,
                    MovieId = 1,
                },
                new MovieGenre
                {
                    Id = 3,
                    GenreId = 1,
                    MovieId = 2,
                },
                new MovieGenre
                {
                    Id = 4,
                    GenreId = 2,
                    MovieId = 2,
                },
                new MovieGenre
                {
                    Id = 5,
                    GenreId = 4,
                    MovieId = 2,
                },
                new MovieGenre
                {
                    Id = 6,
                    GenreId = 1,
                    MovieId = 3,
                },
                new MovieGenre
                {
                    Id = 7,
                    GenreId = 5,
                    MovieId = 3,
                },
                new MovieGenre
                {
                    Id = 8,
                    GenreId = 7,
                    MovieId = 3,
                },
                new MovieGenre
                {
                    Id = 9,
                    GenreId = 1,
                    MovieId = 4,
                },
                new MovieGenre
                {
                    Id = 10,
                    GenreId = 2,
                    MovieId = 4,
                },
                new MovieGenre
                {
                    Id = 11,
                    GenreId = 4,
                    MovieId = 4,
                },
                new MovieGenre
                {
                    Id = 12,
                    GenreId = 1,
                    MovieId = 5,
                },
                new MovieGenre
                {
                    Id = 13,
                    GenreId = 2,
                    MovieId = 5,
                },
                new MovieGenre
                {
                    Id = 14,
                    GenreId = 4,
                    MovieId = 5,
                },
                new MovieGenre
                {
                    Id = 15,
                    GenreId = 1,
                    MovieId = 6,
                },
                new MovieGenre
                {
                    Id = 16,
                    GenreId = 2,
                    MovieId = 6,
                },
                new MovieGenre
                {
                    Id = 17,
                    GenreId = 6,
                    MovieId = 6,
                },
                new MovieGenre
                {
                    Id = 18,
                    GenreId = 7,
                    MovieId = 6,
                },
                new MovieGenre
                {
                    Id = 19,
                    GenreId = 1,
                    MovieId = 7,
                },
                new MovieGenre
                {
                    Id = 20,
                    GenreId = 2,
                    MovieId = 7,
                },
                new MovieGenre
                {
                    Id = 21,
                    GenreId = 6,
                    MovieId = 7,
                },
                new MovieGenre
                {
                    Id = 22,
                    GenreId = 9,
                    MovieId = 7,
                },
                new MovieGenre
                {
                    Id = 23,
                    GenreId = 1,
                    MovieId = 8,
                },
                new MovieGenre
                {
                    Id = 24,
                    GenreId = 2,
                    MovieId = 8,
                },
                new MovieGenre
                {
                    Id = 25,
                    GenreId = 6,
                    MovieId = 8,
                },
                new MovieGenre
                {
                    Id = 26,
                    GenreId = 9,
                    MovieId = 8,
                },
                new MovieGenre
                {
                    Id = 27,
                    GenreId = 1,
                    MovieId = 9,
                },
                new MovieGenre
                {
                    Id = 28,
                    GenreId = 2,
                    MovieId = 9,
                },
                new MovieGenre
                {
                    Id = 29,
                    GenreId = 6,
                    MovieId = 9,
                },
                new MovieGenre
                {
                    Id = 30,
                    GenreId = 1,
                    MovieId = 10,
                },
                new MovieGenre
                {
                    Id = 31,
                    GenreId = 2,
                    MovieId = 10,
                },
                new MovieGenre
                {
                    Id = 32,
                    GenreId = 6,
                    MovieId = 10,
                },
                new MovieGenre
                {
                    Id = 33,
                    GenreId = 2,
                    MovieId = 11,
                },
                new MovieGenre
                {
                    Id = 34,
                    GenreId = 5,
                    MovieId = 11,
                },
                new MovieGenre
                {
                    Id = 35,
                    GenreId = 9,
                    MovieId = 11,
                },
                new MovieGenre
                {
                    Id = 36,
                    GenreId = 1,
                    MovieId = 12,
                },
                new MovieGenre
                {
                    Id = 37,
                    GenreId = 5,
                    MovieId = 12,
                },
                new MovieGenre
                {
                    Id = 38,
                    GenreId = 5,
                    MovieId = 13,
                },
                new MovieGenre
                {
                    Id = 39,
                    GenreId = 9,
                    MovieId = 13,
                },
                new MovieGenre
                {
                    Id = 40,
                    GenreId = 5,
                    MovieId = 14,
                },
                new MovieGenre
                {
                    Id = 41,
                    GenreId = 10,
                    MovieId = 14,
                },
                new MovieGenre
                {
                    Id = 42,
                    GenreId = 5,
                    MovieId = 15,
                },
                new MovieGenre
                {
                    Id = 43,
                    GenreId = 10,
                    MovieId = 15,
                },
                new MovieGenre
                {
                    Id = 44,
                    GenreId = 5,
                    MovieId = 16,
                },
                new MovieGenre
                {
                    Id = 45,
                    GenreId = 10,
                    MovieId = 16,
                },
                new MovieGenre
                {
                    Id = 46,
                    GenreId = 5,
                    MovieId = 17,
                },
                new MovieGenre
                {
                    Id = 47,
                    GenreId = 10,
                    MovieId = 17,
                },
                new MovieGenre
                {
                    Id = 48,
                    GenreId = 1,
                    MovieId = 18,
                },
                new MovieGenre
                {
                    Id = 50,
                    GenreId = 2,
                    MovieId = 18,
                },
                new MovieGenre
                {
                    Id = 51,
                    GenreId = 8,
                    MovieId = 18,
                });
        }
    }
}
