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
    internal class UserFavoriteTvSeriesEntityConfiguration : IEntityTypeConfiguration<UserFavoriteTvSeries>
    {
        
        public void Configure(EntityTypeBuilder<UserFavoriteTvSeries> builder)
        {
            builder.HasKey(k => k.Id);
            builder.HasOne(i => i.ApplicationUser).WithMany(i => i.UserFavoriteTvSeries).HasForeignKey(k => k.UserId).IsRequired();
            builder.HasOne(i => i.TvSeries).WithMany(i => i.UserFavoriteTvSeries).HasForeignKey(k => k.TvSeriesId).IsRequired();
        }
    }
}
