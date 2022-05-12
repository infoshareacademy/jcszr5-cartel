using DataAccess.Models;
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
    internal class TvSeriesEntityConfiguration : IEntityTypeConfiguration<TvSeriesModel>
    {
        public void Configure(EntityTypeBuilder<TvSeriesModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id").IsRequired();
            builder.Property(p => p.Title).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(1000).HasDefaultValue("Nie dodano jeszcze żadnego opisu.");
            builder.Property(p => p.StartYear).HasColumnName("Start_Year");
            builder.Property(p => p.EndYear).HasColumnName("End_Year");
            builder.HasMany(p => p.Genres)
                .WithMany(p => p.TvSeries)
                .UsingEntity<TvSeriesGenre>(
                    j => j.HasOne(mg => mg.Genre).WithMany(g => g.TvSeriesGenres).HasForeignKey("GenreId"),
                    j => j.HasOne(mg => mg.TvSeries).WithMany(g => g.TvSeriesGenres).HasForeignKey("TvSeriesId"));
            builder.HasMany(x => x.Seasons).WithOne(x => x.TvSeries);
        }
    }
}
