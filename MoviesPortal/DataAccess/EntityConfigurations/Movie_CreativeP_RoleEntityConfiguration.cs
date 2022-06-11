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
    internal class Movie_CreativeP_RoleEntityConfiguration : IEntityTypeConfiguration<Movie_CreativeP_Role>
    {
        public void Configure(EntityTypeBuilder<Movie_CreativeP_Role> builder)
        {
            
            builder.HasKey(k => new { k.Id });
            builder.HasOne(i => i.Movie).WithMany(i => i.RoleCreativeMovie).HasForeignKey(i => i.MovieId).IsRequired();
            builder.HasOne(i => i.CreativePerson).WithMany(i => i.RoleCreativeMovie).HasForeignKey(i => i.CreativePersonId).IsRequired();
            builder.HasOne(i => i.Role).WithMany(i => i.RoleCreativeMovie).HasForeignKey(i => i.RoleId).IsRequired();

            builder.HasData(
                new Movie_CreativeP_Role
                {
                    Id = 1,
                    RoleId = 1,
                    CreativePersonId = 1,
                    MovieId = 1,

                },
                new Movie_CreativeP_Role
                {
                    Id = 2,
                    RoleId = 2,
                    CreativePersonId = 6,
                    MovieId = 1,

                },
                new Movie_CreativeP_Role
                {
                    Id = 3,
                    RoleId = 1,
                    CreativePersonId = 3,
                    MovieId = 2,

                },
                new Movie_CreativeP_Role
                {
                    Id = 4,
                    RoleId = 1,
                    CreativePersonId = 9,
                    MovieId = 2,

                },
                new Movie_CreativeP_Role
                {
                    Id = 5,
                    RoleId = 1,
                    CreativePersonId = 8,
                    MovieId = 2,

                },
                new Movie_CreativeP_Role
                {
                    Id = 6,
                    RoleId = 1,
                    CreativePersonId = 10,
                    MovieId = 2,

                },
                new Movie_CreativeP_Role
                {
                    Id = 7,
                    RoleId = 1,
                    CreativePersonId = 5,
                    MovieId = 2,

                },
                new Movie_CreativeP_Role
                {
                    Id = 8,
                    RoleId = 2,
                    CreativePersonId = 5,
                    MovieId = 2,

                },
                new Movie_CreativeP_Role
                {
                    Id = 9,
                    RoleId = 1,
                    CreativePersonId = 2,
                    MovieId = 3,

                },
                new Movie_CreativeP_Role
                {
                    Id = 10,
                    RoleId = 1,
                    CreativePersonId = 4,
                    MovieId = 3,

                },
                new Movie_CreativeP_Role
                {
                    Id = 11,
                    RoleId = 2,
                    CreativePersonId = 7,
                    MovieId = 3,

                },
                new Movie_CreativeP_Role
                {
                    Id = 12,
                    RoleId = 1,
                    CreativePersonId = 3,
                    MovieId = 4,

                },
                new Movie_CreativeP_Role
                {
                    Id = 13,
                    RoleId = 1,
                    CreativePersonId = 9,
                    MovieId = 4,

                },
                new Movie_CreativeP_Role
                {
                    Id = 14,
                    RoleId = 1,
                    CreativePersonId = 10,
                    MovieId = 4,

                },
                new Movie_CreativeP_Role
                {
                    Id = 15,
                    RoleId = 1,
                    CreativePersonId = 11,
                    MovieId = 4,

                },
                new Movie_CreativeP_Role
                {
                    Id = 16,
                    RoleId = 1,
                    CreativePersonId = 14,
                    MovieId = 4,

                },
                new Movie_CreativeP_Role
                {
                    Id = 17,
                    RoleId = 1,
                    CreativePersonId = 15,
                    MovieId = 4,

                },
                new Movie_CreativeP_Role
                {
                    Id = 18,
                    RoleId = 1,
                    CreativePersonId = 16,
                    MovieId = 4,

                },
                new Movie_CreativeP_Role
                {
                    Id = 19,
                    RoleId = 1,
                    CreativePersonId = 17,
                    MovieId = 4,

                },
                new Movie_CreativeP_Role
                {
                    Id = 20,
                    RoleId = 1,
                    CreativePersonId = 18,
                    MovieId = 4,

                },
                new Movie_CreativeP_Role
                {
                    Id = 21,
                    RoleId = 1,
                    CreativePersonId = 19,
                    MovieId = 4,

                },
                new Movie_CreativeP_Role
                {
                    Id = 22,
                    RoleId = 2,
                    CreativePersonId = 13,
                    MovieId = 4,

                },
                new Movie_CreativeP_Role
                {
                    Id = 23,
                    RoleId = 2,
                    CreativePersonId = 12,
                    MovieId = 4,

                },
                new Movie_CreativeP_Role
                {
                    Id = 24,
                    RoleId = 1,
                    CreativePersonId = 11,
                    MovieId = 5,

                },
                new Movie_CreativeP_Role
                {
                    Id = 25,
                    RoleId = 1,
                    CreativePersonId = 14,
                    MovieId = 5,

                },
                new Movie_CreativeP_Role
                {
                    Id = 26,
                    RoleId = 1,
                    CreativePersonId = 15,
                    MovieId = 5,

                },
                new Movie_CreativeP_Role
                {
                    Id = 27,
                    RoleId = 1,
                    CreativePersonId = 16,
                    MovieId = 5,

                },
                new Movie_CreativeP_Role
                {
                    Id = 28,
                    RoleId = 1,
                    CreativePersonId = 18,
                    MovieId = 5,

                },
                new Movie_CreativeP_Role
                {
                    Id = 29,
                    RoleId = 1,
                    CreativePersonId = 19,
                    MovieId = 5,

                },
                new Movie_CreativeP_Role
                {
                    Id = 30,
                    RoleId = 2,
                    CreativePersonId = 12,
                    MovieId = 5,

                },
                new Movie_CreativeP_Role
                {
                    Id = 31,
                    RoleId = 2,
                    CreativePersonId = 13,
                    MovieId = 5,

                },
                new Movie_CreativeP_Role
                {
                    Id = 32,
                    RoleId = 1,
                    CreativePersonId = 28,
                    MovieId = 6,

                },
                new Movie_CreativeP_Role
                {
                    Id = 33,
                    RoleId = 1,
                    CreativePersonId = 29,
                    MovieId = 6,

                },
                new Movie_CreativeP_Role
                {
                    Id = 34,
                    RoleId = 1,
                    CreativePersonId = 30,
                    MovieId = 6,

                },
                new Movie_CreativeP_Role
                {
                    Id = 35,
                    RoleId = 1,
                    CreativePersonId = 31,
                    MovieId = 6,

                },
                new Movie_CreativeP_Role
                {
                    Id = 36,
                    RoleId = 1,
                    CreativePersonId = 32,
                    MovieId = 6,

                },
                new Movie_CreativeP_Role
                {
                    Id = 37,
                    RoleId = 2,
                    CreativePersonId = 33,
                    MovieId = 6,

                },
                new Movie_CreativeP_Role
                {
                    Id = 38,
                    RoleId = 1,
                    CreativePersonId = 28,
                    MovieId = 7,

                },
                new Movie_CreativeP_Role
                {
                    Id = 39,
                    RoleId = 1,
                    CreativePersonId = 29,
                    MovieId = 7,

                },
                new Movie_CreativeP_Role
                {
                    Id = 40,
                    RoleId = 1,
                    CreativePersonId = 30,
                    MovieId = 7,

                },
                new Movie_CreativeP_Role
                {
                    Id = 41,
                    RoleId = 1,
                    CreativePersonId = 31,
                    MovieId = 7,

                },
                new Movie_CreativeP_Role
                {
                    Id = 42,
                    RoleId = 1,
                    CreativePersonId = 32,
                    MovieId = 7,

                },
                new Movie_CreativeP_Role
                {
                    Id = 43,
                    RoleId = 2,
                    CreativePersonId = 34,
                    MovieId = 7,

                },
                new Movie_CreativeP_Role
                {
                    Id = 44,
                    RoleId = 1,
                    CreativePersonId = 28,
                    MovieId = 8,

                },
                new Movie_CreativeP_Role
                {
                    Id = 45,
                    RoleId = 1,
                    CreativePersonId = 29,
                    MovieId = 8,

                },
                new Movie_CreativeP_Role
                {
                    Id = 46,
                    RoleId = 1,
                    CreativePersonId = 30,
                    MovieId = 8,

                },
                new Movie_CreativeP_Role
                {
                    Id = 47,
                    RoleId = 1,
                    CreativePersonId = 31,
                    MovieId = 8,

                },
                new Movie_CreativeP_Role
                {
                    Id = 48,
                    RoleId = 1,
                    CreativePersonId = 32,
                    MovieId = 8,

                },
                new Movie_CreativeP_Role
                {
                    Id = 49,
                    RoleId = 2,
                    CreativePersonId = 35,
                    MovieId = 8,

                },
                new Movie_CreativeP_Role
                {
                    Id = 50,
                    RoleId = 1,
                    CreativePersonId = 28,
                    MovieId = 9,

                },
                new Movie_CreativeP_Role
                {
                    Id = 51,
                    RoleId = 1,
                    CreativePersonId = 37,
                    MovieId = 9,

                },
                new Movie_CreativeP_Role
                {
                    Id = 52,
                    RoleId = 1,
                    CreativePersonId = 38,
                    MovieId = 9,

                },
                new Movie_CreativeP_Role
                {
                    Id = 53,
                    RoleId = 2,
                    CreativePersonId = 36,
                    MovieId = 9,

                },
                new Movie_CreativeP_Role
                {
                    Id = 54,
                    RoleId = 1,
                    CreativePersonId = 28,
                    MovieId = 10,

                },
                new Movie_CreativeP_Role
                {
                    Id = 55,
                    RoleId = 1,
                    CreativePersonId = 38,
                    MovieId = 10,

                },
                new Movie_CreativeP_Role
                {
                    Id = 56,
                    RoleId = 1,
                    CreativePersonId = 39,
                    MovieId = 10,

                },
                new Movie_CreativeP_Role
                {
                    Id = 57,
                    RoleId = 2,
                    CreativePersonId = 36,
                    MovieId = 10,

                },
                new Movie_CreativeP_Role
                {
                    Id = 58,
                    RoleId = 1,
                    CreativePersonId = 25,
                    MovieId = 11,

                },
                new Movie_CreativeP_Role
                {
                    Id = 59,
                    RoleId = 1,
                    CreativePersonId = 26,
                    MovieId = 11,

                },
                new Movie_CreativeP_Role
                {
                    Id = 60,
                    RoleId = 1,
                    CreativePersonId = 27,
                    MovieId = 11,

                },
                new Movie_CreativeP_Role
                {
                    Id = 61,
                    RoleId = 2,
                    CreativePersonId = 7,
                    MovieId = 11,

                },
                new Movie_CreativeP_Role
                {
                    Id = 62,
                    RoleId = 1,
                    CreativePersonId = 4,
                    MovieId = 12,

                },
                new Movie_CreativeP_Role
                {
                    Id = 63,
                    RoleId = 1,
                    CreativePersonId = 23,
                    MovieId = 12,

                },
                new Movie_CreativeP_Role
                {
                    Id = 64,
                    RoleId = 1,
                    CreativePersonId = 24,
                    MovieId = 12,

                },
                new Movie_CreativeP_Role
                {
                    Id = 65,
                    RoleId = 2,
                    CreativePersonId = 7,
                    MovieId = 12,

                },
                new Movie_CreativeP_Role
                {
                    Id = 66,
                    RoleId = 1,
                    CreativePersonId = 14,
                    MovieId = 13,

                },
                new Movie_CreativeP_Role
                {
                    Id = 67,
                    RoleId = 1,
                    CreativePersonId = 21,
                    MovieId = 13,

                },
                new Movie_CreativeP_Role
                {
                    Id = 68,
                    RoleId = 1,
                    CreativePersonId = 22,
                    MovieId = 13,

                },
                new Movie_CreativeP_Role
                {
                    Id = 69,
                    RoleId = 2,
                    CreativePersonId = 20,
                    MovieId = 13,

                },
                new Movie_CreativeP_Role
                {
                    Id = 70,
                    RoleId = 1,
                    CreativePersonId = 41,
                    MovieId = 14,

                },
                new Movie_CreativeP_Role
                {
                    Id = 71,
                    RoleId = 1,
                    CreativePersonId = 42,
                    MovieId = 14,

                },
                new Movie_CreativeP_Role
                {
                    Id = 72,
                    RoleId = 2,
                    CreativePersonId = 40,
                    MovieId = 14,

                },
                new Movie_CreativeP_Role
                {
                    Id = 73,
                    RoleId = 1,
                    CreativePersonId = 44,
                    MovieId = 15,

                },
                new Movie_CreativeP_Role
                {
                    Id = 74,
                    RoleId = 1,
                    CreativePersonId = 43,
                    MovieId = 15,

                },
                new Movie_CreativeP_Role
                {
                    Id = 75,
                    RoleId = 1,
                    CreativePersonId = 41,
                    MovieId = 15,

                },
                new Movie_CreativeP_Role
                {
                    Id = 76,
                    RoleId = 2,
                    CreativePersonId = 40,
                    MovieId = 15,

                },
                new Movie_CreativeP_Role
                {
                    Id = 77,
                    RoleId = 1,
                    CreativePersonId = 45,
                    MovieId = 16,

                },
                new Movie_CreativeP_Role
                {
                    Id = 78,
                    RoleId = 1,
                    CreativePersonId = 46,
                    MovieId = 16,

                },
                new Movie_CreativeP_Role
                {
                    Id = 79,
                    RoleId = 2,
                    CreativePersonId = 40,
                    MovieId = 16,

                },
                new Movie_CreativeP_Role
                {
                    Id = 80,
                    RoleId = 1,
                    CreativePersonId = 48,
                    MovieId = 17,

                },
                new Movie_CreativeP_Role
                {
                    Id = 81,
                    RoleId = 1,
                    CreativePersonId = 11,
                    MovieId = 17,

                },
                new Movie_CreativeP_Role
                {
                    Id = 82,
                    RoleId = 1,
                    CreativePersonId = 47,
                    MovieId = 17,

                },
                new Movie_CreativeP_Role
                {
                    Id = 83,
                    RoleId = 2,
                    CreativePersonId = 40,
                    MovieId = 17,

                },
                new Movie_CreativeP_Role
                {
                    Id = 84,
                    RoleId = 1,
                    CreativePersonId = 17,
                    MovieId = 18,

                },
                new Movie_CreativeP_Role
                {
                    Id = 85,
                    RoleId = 1,
                    CreativePersonId = 19,
                    MovieId = 18,

                },
                new Movie_CreativeP_Role
                {
                    Id = 86,
                    RoleId = 2,
                    CreativePersonId = 49,
                    MovieId = 18,

                }
            );
        }
    }
}
