using DataAccess.EntityConfigurations;
using DataAccess.Models;
using DataAccess.Models.EntityAssigments;
using DataAccess.Repositories.EntityConfigurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace DataAccess.DbContext
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
        public DbSet<CommentModel> Comments { get; set; }
        public DbSet<SubscriptionModel> Subscriptions { get; set; }

        //Assigment tables 

        public DbSet<MovieGenre> Movie_Genre { get; set; }
        public DbSet<TvSeriesGenre> TvSeries_Genre { get; set; }
        public DbSet<Movie_CreativeP_Role> Role_CreativeP_Movie { get; set; }
        public DbSet<TvSeries_CreativeP_Role> TvSeries_CreativeP_Role { get; set; }
        public DbSet<UserFavoriteMovies> UserFavoriteMovies { get; set; }
        public DbSet<UserFavoriteTvSeries> UserFavoriteTvSeries { get; set; }
        public DbSet<UserFavoriteApiMovies> UserFavoriteApiMovies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=moviesportal.database.windows.net,1433;Initial Catalog=MoviesPortalDb;User ID=mateuszmiga;Password=<password>");
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

            new UserFavoriteMoviesEntityConfiguration().Configure(modelBuilder.Entity<UserFavoriteMovies>());

            new UserFavoriteTvSeriesEntityConfiguration().Configure(modelBuilder.Entity<UserFavoriteTvSeries>());

            new MovieGenreEntityConfiguration().Configure(modelBuilder.Entity<MovieGenre>());

            new RoleEntityConfiguration().Configure(modelBuilder.Entity<RoleModel>());

            new CommentEntityConfiguration().Configure(modelBuilder.Entity<CommentModel>());

            new UserFavoriteApiMoviesEntityConfiguration().Configure(modelBuilder.Entity<UserFavoriteApiMovies>());

            new SubcriptionConfiguration().Configure(modelBuilder.Entity<SubscriptionModel>());
        }

    }
}
