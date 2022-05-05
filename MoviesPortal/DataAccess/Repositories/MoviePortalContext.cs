using DataAccess.Models;
using DataAccess.Models.EntityAssigments;
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
        public DbSet<RoleCreativeMovie> Role_CreativeP_Movie { get; set; }
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

            var role_CreativeP_Movie = modelBuilder.Entity<RoleCreativeMovie>();
            role_CreativeP_Movie.HasKey(k => new { k.Id });            
            role_CreativeP_Movie.HasOne(i => i.Movie).WithMany(i => i.RoleCreativeMovie).HasForeignKey(i => i.MovieId).IsRequired();
            role_CreativeP_Movie.HasOne(i => i.CreativePerson).WithMany(i => i.RoleCreativeMovie).HasForeignKey(i => i.CreativePersonId).IsRequired();
            role_CreativeP_Movie.HasOne(i => i.Role).WithMany(i => i.RoleCreativeMovie).HasForeignKey(i => i.RoleId).IsRequired();

            var tvSeries_CreativeP_Role = modelBuilder.Entity<TvSeries_CreativeP_Role>();
            tvSeries_CreativeP_Role.HasKey(k => new { k.TvSeriesId, k.CreativePersonId, k.RoleId });
            tvSeries_CreativeP_Role.HasOne(i => i.TvSeries).WithMany(i => i.TvSeries_CreativeP_Role).HasForeignKey(i => i.TvSeriesId).IsRequired();
            tvSeries_CreativeP_Role.HasOne(i => i.CreativePerson).WithMany(i => i.TvSeries_CreativeP_Role).HasForeignKey(i => i.CreativePersonId).IsRequired();
            tvSeries_CreativeP_Role.HasOne(i => i.Role).WithMany(i => i.TvSeries_CreativeP_Role).HasForeignKey(i => i.RoleId).IsRequired();

            var userFavourities = modelBuilder.Entity<UserFavourities>();
            userFavourities.HasKey(k => new { k.UserId, k.MovieId, k.TvSeriesId});
            userFavourities.HasOne(i => i.Identity).WithMany().HasForeignKey(k => k.UserId).IsRequired();
            userFavourities.HasOne(i => i.Movie).WithMany(i => i.UserFavourities).HasForeignKey(k => k.MovieId).IsRequired();
            userFavourities.HasOne(i => i.TvSeries).WithMany(i => i.UserFavourities).HasForeignKey(k => k.TvSeriesId).IsRequired();

            var movieModel = modelBuilder.Entity<MovieModel>();

            movieModel.HasKey(x => x.Id);
            movieModel.Property(x => x.Id).HasColumnName("Id")
                .IsRequired();
            movieModel.Property(p => p.Title).IsRequired()
                .HasMaxLength(50);
            movieModel.Property(p => p.Description).IsRequired()
                .HasMaxLength(200)
                .HasDefaultValue("Nie dodano jeszcze żadnego opisu.");
            movieModel.Property(p => p.ProductionYear).HasColumnName("Release Date")
                .HasMaxLength(DateTime.Now.Year);            
            movieModel.HasMany(p => p.Genres)
                .WithMany(p => p.Movies)
                .UsingEntity<MovieGenre>(
                    j => j.HasOne(mg => mg.Genre).WithMany(g => g.MovieGenres).HasForeignKey("GenreId"),
                    j => j.HasOne(mg => mg.Movie).WithMany(g => g.MovieGenres).HasForeignKey("MovieId"));
            



            var creativePersonModel = modelBuilder.Entity<CreativePersonModel>();
            creativePersonModel.HasKey(x => x.Id);
            creativePersonModel.Property(x => x.Id).HasColumnName("Id");

            creativePersonModel.Property(p => p.DateOfBirth)
                .HasColumnType("date")
                .IsRequired(false);
            creativePersonModel.Property(p => p.Name)
                .HasColumnName("Name").HasMaxLength(20)
                .IsRequired();
            creativePersonModel.Property(p => p.SurName)
                .HasColumnName("Surname").HasMaxLength(20)
                .IsRequired();
            



            var genreModel = modelBuilder.Entity<GenreModel>();
            genreModel.HasKey(x => x.Id);
            genreModel.Property(x => x.Id).HasColumnName("Id");
            genreModel.Property(x => x.Genre).HasMaxLength(20);


            var episodeModel = modelBuilder.Entity<EpisodeModel>();
            episodeModel.HasKey(x => x.Id);
            episodeModel.Property(x => x.Id).HasColumnName("Id");
            episodeModel.Property(x => x.Title).HasColumnName("Title").HasMaxLength(50);
            episodeModel.Property(x => x.Description).HasColumnName("Description").HasMaxLength(1000);

            var seasonModel = modelBuilder.Entity<SeasonModel>();
            seasonModel.HasKey(x => x.Id);
            seasonModel.Property(x => x.Id).HasColumnName("Id");
            seasonModel.HasMany(x => x.Episodes).WithOne(x => x.Season);

            var tvSeriesModel = modelBuilder.Entity<TvSeriesModel>();
            tvSeriesModel.HasKey(x => x.Id);
            tvSeriesModel.Property(x => x.Id).HasColumnName("Id").IsRequired();
            tvSeriesModel.Property(p => p.Title).IsRequired().HasMaxLength(50);
            tvSeriesModel.Property(p => p.Description).IsRequired().HasMaxLength(1000).HasDefaultValue("Nie dodano jeszcze żadnego opisu.");
            tvSeriesModel.Property(p => p.StartYear).HasColumnName("Start_Year");
            tvSeriesModel.Property(p => p.EndYear).HasColumnName("End_Year");            
            tvSeriesModel.HasMany(p => p.Genres)
                .WithMany(p => p.TvSeries)
                .UsingEntity<TvSeriesGenre>(
                    j => j.HasOne(mg => mg.Genre).WithMany(g => g.TvSeriesGenres).HasForeignKey("GenreId"),
                    j => j.HasOne(mg => mg.TvSeries).WithMany(g => g.TvSeriesGenres).HasForeignKey("TvSeriesId"));
            tvSeriesModel.HasMany(x => x.Seasons).WithOne(x => x.TvSeries);



            //Seeding some data

            var movie_CreativePersons_role = modelBuilder.Entity<RoleCreativeMovie>();
            
            var movieGenre = modelBuilder.Entity<MovieGenre>();

            movieModel.HasData(MovieSampleData.sampleMovies);
            creativePersonModel.HasData(ActorSampleData.sampleActors/*, ActorSampleData.sampleDirector*/);


            //Relations
            movie_CreativePersons_role.HasData(
                new RoleCreativeMovie
                {
                    Id = 1,
                    RoleId = 1,
                    CreativePersonId = 1,
                    MovieId = 1,

                },
                new RoleCreativeMovie
                {
                    Id = 2,
                    RoleId = 2,
                    CreativePersonId = 6,
                    MovieId = 1,
                },
                new RoleCreativeMovie
                {
                    Id = 3,
                    RoleId = 1,
                    CreativePersonId = 3,
                    MovieId = 2,
                },
                new RoleCreativeMovie
                {
                    Id = 4,
                    RoleId = 1,
                    CreativePersonId = 5,
                    MovieId = 2,
                },
                new RoleCreativeMovie
                {
                    Id = 5,
                    RoleId = 2,
                    CreativePersonId = 5,
                    MovieId = 2,
                },
                new RoleCreativeMovie
                {
                    Id = 6,
                    RoleId = 1,
                    CreativePersonId = 8,
                    MovieId = 2,
                },
                new RoleCreativeMovie
                {
                    Id = 7,
                    RoleId = 1,
                    CreativePersonId = 2,
                    MovieId = 3,
                },
                new RoleCreativeMovie
                {
                    Id = 8,
                    RoleId = 1,
                    CreativePersonId = 4,
                    MovieId = 3,
                },
                new RoleCreativeMovie
                {
                    Id = 9,
                    RoleId = 2,
                    CreativePersonId = 7,
                    MovieId = 3,
                }
             );


            

            //Relations
            movieGenre.HasData(
                new MovieGenre
                {
                    Id = 1,
                    GenreId = 1,
                    MovieId = 1,

                },
                new MovieGenre
                {
                    Id = 2,
                    GenreId = 5,
                    MovieId = 1,
                },
                new MovieGenre
                {
                    Id = 3,
                    GenreId = 2,
                    MovieId = 2,
                },
                new MovieGenre
                {
                    Id = 4,
                    GenreId = 4,
                    MovieId = 2,
                },
                new MovieGenre
                {
                    Id = 5,
                    GenreId = 9,
                    MovieId = 2,
                },
                new MovieGenre
                {
                    Id = 6,
                    GenreId = 7,
                    MovieId = 3,
                },
                new MovieGenre
                {
                    Id = 7,
                    GenreId = 5,
                    MovieId = 3,
                });


            var Roles = modelBuilder.Entity<RoleModel>();
            Roles.HasData(
                new RoleModel
                {
                    RoleId = 1,
                    RoleName = "Actor"
                },
                new RoleModel
                {
                    RoleId = 2,
                    RoleName = "Director"
                });

            genreModel.HasData(GenreSampleData.sampleGenres);


        }

    }
}