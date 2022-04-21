using DataAccess.Models;
using DataAccess.Models.EntityAssigments;
using FluentAssertions.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


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
        public DbSet<MovieCreativePerson> Movie_CreativePersons { get; set; }

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
            movieModel.HasMany(p => p.CreativePersons)
                .WithMany(p => p.Movies)
                .UsingEntity<MovieCreativePerson>(
                    j => j.HasOne(mc => mc.CreativePerson).WithMany(c => c.MovieCreativePersons).HasForeignKey("CreativePersonId"),
                    j => j.HasOne(mc => mc.Movie).WithMany(m => m.MovieCreativeRoles).HasForeignKey("MovieId"));
                    
            var creativePersonModel = modelBuilder.Entity<DbCreativePersonModel>();
            creativePersonModel.HasKey(x => x.Id);
            creativePersonModel.Property(x => x.Id).HasColumnName("Id")
                .HasDefaultValue(0);
            creativePersonModel.Property(p => p.DateOfBirth)
                .HasColumnType("date")
                .IsRequired(false);
            creativePersonModel.Property(p => p.Name)
                .HasColumnName("Name").HasMaxLength(20)
                .IsRequired();
            creativePersonModel.Property(p => p.SurName)
                .HasColumnName("Surname").HasMaxLength(20)
                .IsRequired();
            creativePersonModel.Property(p => p.Role).IsRequired();
            
                    






        }
    }
}
