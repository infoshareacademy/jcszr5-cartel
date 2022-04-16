using DataAccess.Models;
using FluentAssertions.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;

namespace DataAccess.Repositories
{
    public class MoviePortalContext : DbContext
    {

        public MoviePortalContext()
        {

        }
        public MoviePortalContext(DbContextOptions<MoviePortalContext> options) : base(options)
        {
        }
        public DbSet<DbMovieModel> Movies { get; set; }
        public DbSet<DbCreativePersonModel> CreativePersons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=localhost;Database=MoviePortalDb;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var movieModel = modelBuilder.Entity<DbMovieModel>();

            movieModel.HasKey(x => x.Id);
            movieModel.Property(x => x.Id).HasColumnName("Id")
                .HasDefaultValue(0)
                .IsRequired();
            movieModel.Property(p => p.Title).IsRequired()
                .HasMaxLength(50);
            movieModel.Property(p => p.Description).IsRequired()
                .HasMaxLength(200)
                .HasDefaultValue("Nie dodano jeszcze żadnego opisu.");
            movieModel.Property(p => p.ProductionYear).HasColumnName("Release Date")                
                .HasMaxLength(DateTime.Now.Year);
            //todo other properties

                
        }
    }
}
