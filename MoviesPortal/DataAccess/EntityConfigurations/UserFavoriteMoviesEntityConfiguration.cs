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
    internal class UserFavoriteMoviesEntityConfiguration : IEntityTypeConfiguration<UserFavoriteMovies>
    {
        public void Configure(EntityTypeBuilder<UserFavoriteMovies> builder)
        {
            builder.HasKey(k => k.Id);
            builder.HasOne(i => i.ApplicationUser).WithMany(i => i.UserFavoriteMovies).HasForeignKey(k => k.UserId).IsRequired();
            builder.HasOne(i => i.Movie).WithMany(i => i.UserFavoriteMovies).HasForeignKey(k => k.MovieId).IsRequired();
            
        }
    }
}
