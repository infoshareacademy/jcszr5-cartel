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
    internal class UserFavouritiesEntityConfiguration : IEntityTypeConfiguration<UserFavourities>
    {
        public void Configure(EntityTypeBuilder<UserFavourities> builder)
        {
            builder.HasKey(k => k.Id);
            builder.HasOne(i => i.ApplicationUser).WithMany(i => i.UserFavourities).HasForeignKey(k => k.UserId).IsRequired();
            builder.HasOne(i => i.Movie).WithMany(i => i.UserFavourities).HasForeignKey(k => k.MovieId).IsRequired(false);
            builder.HasOne(i => i.TvSeries).WithMany(i => i.UserFavourities).HasForeignKey(k => k.TvSeriesId).IsRequired(false);
        }
    }
}
