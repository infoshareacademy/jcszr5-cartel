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
    internal class UserFavoriteApiMoviesEntityConfiguration : IEntityTypeConfiguration<UserFavoriteApiMovies>
    {
        public void Configure(EntityTypeBuilder<UserFavoriteApiMovies> builder)
        {
            builder.HasKey(k => k.Id);
            builder.HasOne(i => i.ApplicationUser).WithMany(i => i.UserFavoriteApiMovies).HasForeignKey(k => k.UserId).IsRequired();
            builder.Property(i => i.MovieId).IsRequired();
        }
    }
}
