using DataAccess.Models;
using DataAccess.Models.EntityAssigments;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityConfigurations
{
    internal class MovieEntityConfiguration : IEntityTypeConfiguration<MovieModel>
    {
        public void Configure(EntityTypeBuilder<MovieModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id")
                .IsRequired();
            builder.Property(p => p.Title).IsRequired()
                .HasMaxLength(50);
            builder.Property(p => p.Description).IsRequired()
                .HasMaxLength(int.MaxValue)
                .HasDefaultValue("Nie dodano jeszcze żadnego opisu.");
            builder.Property(p => p.ProductionYear).HasColumnName("Release Date")
                .HasMaxLength(DateTime.Now.Year);
            builder.HasMany(p => p.Genres)
                .WithMany(p => p.Movies)
                .UsingEntity<MovieGenre>(
                    j => j.HasOne(mg => mg.Genre).WithMany(mg => mg.MovieGenres).HasForeignKey("GenreId"),
                    j => j.HasOne(mg => mg.Movie).WithMany(mg => mg.MovieGenres).HasForeignKey("MovieId"));

            builder.HasData(MovieSampleData.sampleMovies);
        }
    }
}
