using DataAccess.EntityConfigurations;
using DataAccess.Models;
using DataAccess.Models.EntityAssigments;
using DataAccess.Repositories.EntityConfigurations;
using DataAccess.Repositories.SampleData;
using FluentAssertions.Common;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace DataAccess.Repositories
{
    public class MoviePortalContext : IdentityDbContext<ApplicationUser>
    {

        public MoviePortalContext()
        {

        }
        public MoviePortalContext(DbContextOptions<MoviePortalContext> options) : base(options)
        {
        }
        public DbSet<MovieModel> Movies { get; set; }
        public DbSet<CreativePersonModel> CreativePersons { get; set; }
        public DbSet<TvSeriesModel> TvSeries { get; set; }
        public DbSet<SeasonModel> Seasons { get; set; }
        public DbSet<EpisodeModel> Episodes { get; set; }
        public DbSet<GenreModel> Genres { get; set; }
        public DbSet<RoleModel> Roles { get; set; }

        //Assigment tables (for many-to-many relations)
        
        public DbSet<MovieGenre> Movie_Genre { get; set; }
        
        public DbSet<TvSeriesGenre> TvSeries_Genre { get; set; }
        public DbSet<Movie_CreativeP_Role> Role_CreativeP_Movie { get; set; }
        public DbSet<TvSeries_CreativeP_Role> TvSeries_CreativeP_Role { get; set; }
        public DbSet<UserFavourities> UserFavourities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=localhost;Database=MoviePortalDb;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new SeasonEntityConfiguration().Configure(modelBuilder.Entity<SeasonModel>());

            new EpisodeEntityConfiguration().Configure(modelBuilder.Entity<EpisodeModel>());

            new TvSeriesEntityConfiguration().Configure(modelBuilder.Entity<TvSeriesModel>());

            new MovieEntityConfiguration().Configure(modelBuilder.Entity<MovieModel>());

            new Movie_CreativeP_RoleEntityConfiguration().Configure(modelBuilder.Entity<Movie_CreativeP_Role>());

            new TvSeries_CreativeP_RoleEntityConfiguration().Configure(modelBuilder.Entity<TvSeries_CreativeP_Role>());

            new GenreEntityConfiguration().Configure(modelBuilder.Entity<GenreModel>());

            new CreativePersonEntityConfiguration().Configure(modelBuilder.Entity<CreativePersonModel>());

            new UserFavouritiesEntityConfiguration().Configure(modelBuilder.Entity<UserFavourities>());

            new MovieGenreEntityConfiguration().Configure(modelBuilder.Entity<MovieGenre>());

            new RoleEntityConfiguration().Configure(modelBuilder.Entity<RoleModel>());

        }

    }
}