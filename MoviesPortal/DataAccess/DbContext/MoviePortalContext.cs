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

            new SeasonEntityConfiguration().Configure(modelBuilder.Entity<SeasonModel>());
            new EpisodeEntityConfiguration().Configure(modelBuilder.Entity<EpisodeModel>());
            new TvSeriesEntityConfiguration().Configure(modelBuilder.Entity<TvSeriesModel>());

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
            userFavourities.HasKey(k => k.Id);
            userFavourities.HasOne(i => i.ApplicationUser).WithMany(i => i.UserFavourities).HasForeignKey(k => k.UserId).IsRequired();
            userFavourities.HasOne(i => i.Movie).WithMany(i => i.UserFavourities).HasForeignKey(k => k.MovieId).IsRequired(false);
            userFavourities.HasOne(i => i.TvSeries).WithMany(i => i.UserFavourities).HasForeignKey(k => k.TvSeriesId).IsRequired(false);


            var movieModel = modelBuilder.Entity<MovieModel>();

            movieModel.HasKey(x => x.Id);
            movieModel.Property(x => x.Id).HasColumnName("Id")
                .IsRequired();
            movieModel.Property(p => p.Title).IsRequired()
                .HasMaxLength(50);
            movieModel.Property(p => p.Description).IsRequired()
                .HasMaxLength(int.MaxValue)
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
                    CreativePersonId = 9,
                    MovieId = 2,

                },
                new RoleCreativeMovie
                {
                    Id = 5,
                    RoleId = 1,
                    CreativePersonId = 8,
                    MovieId = 2,

                },
                new RoleCreativeMovie
                {
                    Id = 6,
                    RoleId = 1,
                    CreativePersonId = 10,
                    MovieId = 2,

                },
                new RoleCreativeMovie
                {
                    Id = 7,
                    RoleId = 1,
                    CreativePersonId = 5,
                    MovieId = 2,

                },
                new RoleCreativeMovie
                {
                    Id = 8,
                    RoleId = 2,
                    CreativePersonId = 5,
                    MovieId = 2,

                },
                new RoleCreativeMovie
                {
                    Id = 9,
                    RoleId = 1,
                    CreativePersonId = 2,
                    MovieId = 3,

                },
                new RoleCreativeMovie
                {
                    Id = 10,
                    RoleId = 1,
                    CreativePersonId = 4,
                    MovieId = 3,

                },
                new RoleCreativeMovie
                {
                    Id = 11,
                    RoleId = 2,
                    CreativePersonId = 7,
                    MovieId = 3,

                },
                new RoleCreativeMovie
                {
                    Id = 12,
                    RoleId = 1,
                    CreativePersonId = 3,
                    MovieId = 4,

                },
                new RoleCreativeMovie
                {
                    Id = 13,
                    RoleId = 1,
                    CreativePersonId = 9,
                    MovieId = 4,

                },
                new RoleCreativeMovie
                {
                    Id = 14,
                    RoleId = 1,
                    CreativePersonId = 10,
                    MovieId = 4,

                },
                new RoleCreativeMovie
                {
                    Id = 15,
                    RoleId = 1,
                    CreativePersonId = 11,
                    MovieId = 4,

                },
                new RoleCreativeMovie
                {
                    Id = 16,
                    RoleId = 1,
                    CreativePersonId = 14,
                    MovieId = 4,

                },
                new RoleCreativeMovie
                {
                    Id = 17,
                    RoleId = 1,
                    CreativePersonId = 15,
                    MovieId = 4,

                },
                new RoleCreativeMovie
                {
                    Id = 18,
                    RoleId = 1,
                    CreativePersonId = 16,
                    MovieId = 4,

                },
                new RoleCreativeMovie
                {
                    Id = 19,
                    RoleId = 1,
                    CreativePersonId = 17,
                    MovieId = 4,

                },
                new RoleCreativeMovie
                {
                    Id = 20,
                    RoleId = 1,
                    CreativePersonId = 18,
                    MovieId = 4,

                },
                new RoleCreativeMovie
                {
                    Id = 21,
                    RoleId = 1,
                    CreativePersonId = 19,
                    MovieId = 4,

                },
                new RoleCreativeMovie
                {
                    Id = 22,
                    RoleId = 2,
                    CreativePersonId = 13,
                    MovieId = 4,

                },
                new RoleCreativeMovie
                {
                    Id = 23,
                    RoleId = 2,
                    CreativePersonId = 12,
                    MovieId = 4,

                },
                new RoleCreativeMovie
                {
                    Id = 24,
                    RoleId = 1,
                    CreativePersonId = 11,
                    MovieId = 5,

                },
                new RoleCreativeMovie
                {
                    Id = 25,
                    RoleId = 1,
                    CreativePersonId = 14,
                    MovieId = 5,

                },
                new RoleCreativeMovie
                {
                    Id = 26,
                    RoleId = 1,
                    CreativePersonId = 15,
                    MovieId = 5,

                },
                new RoleCreativeMovie
                {
                    Id = 27,
                    RoleId = 1,
                    CreativePersonId = 16,
                    MovieId = 5,

                },
                new RoleCreativeMovie
                {
                    Id = 28,
                    RoleId = 1,
                    CreativePersonId = 18,
                    MovieId = 5,

                },
                new RoleCreativeMovie
                {
                    Id = 29,
                    RoleId = 1,
                    CreativePersonId = 19,
                    MovieId = 5,

                },
                new RoleCreativeMovie
                {
                    Id = 30,
                    RoleId = 2,
                    CreativePersonId = 12,
                    MovieId = 5,

                },
                new RoleCreativeMovie
                {
                    Id = 31,
                    RoleId = 2,
                    CreativePersonId = 13,
                    MovieId = 5,

                },
                new RoleCreativeMovie
                {
                    Id = 32,
                    RoleId = 1,
                    CreativePersonId = 28,
                    MovieId = 6,

                },
                new RoleCreativeMovie
                {
                    Id = 33,
                    RoleId = 1,
                    CreativePersonId = 29,
                    MovieId = 6,

                },
                new RoleCreativeMovie
                {
                    Id = 34,
                    RoleId = 1,
                    CreativePersonId = 30,
                    MovieId = 6,

                },
                new RoleCreativeMovie
                {
                    Id = 35,
                    RoleId = 1,
                    CreativePersonId = 31,
                    MovieId = 6,

                },
                new RoleCreativeMovie
                {
                    Id = 36,
                    RoleId = 1,
                    CreativePersonId = 32,
                    MovieId = 6,

                },
                new RoleCreativeMovie
                {
                    Id = 37,
                    RoleId = 2,
                    CreativePersonId = 33,
                    MovieId = 6,

                },
                new RoleCreativeMovie
                {
                    Id = 38,
                    RoleId = 1,
                    CreativePersonId = 28,
                    MovieId = 7,

                },
                new RoleCreativeMovie
                {
                    Id = 39,
                    RoleId = 1,
                    CreativePersonId = 29,
                    MovieId = 7,

                },
                new RoleCreativeMovie
                {
                    Id = 40,
                    RoleId = 1,
                    CreativePersonId = 30,
                    MovieId = 7,

                },
                new RoleCreativeMovie
                {
                    Id = 41,
                    RoleId = 1,
                    CreativePersonId = 31,
                    MovieId = 7,

                },
                new RoleCreativeMovie
                {
                    Id = 42,
                    RoleId = 1,
                    CreativePersonId = 32,
                    MovieId = 7,

                },
                new RoleCreativeMovie
                {
                    Id = 43,
                    RoleId = 2,
                    CreativePersonId = 34,
                    MovieId = 7,

                },
                new RoleCreativeMovie
                {
                    Id = 44,
                    RoleId = 1,
                    CreativePersonId = 28,
                    MovieId = 8,

                },
                new RoleCreativeMovie
                {
                    Id = 45,
                    RoleId = 1,
                    CreativePersonId = 29,
                    MovieId = 8,

                },
                new RoleCreativeMovie
                {
                    Id = 46,
                    RoleId = 1,
                    CreativePersonId = 30,
                    MovieId = 8,

                },
                new RoleCreativeMovie
                {
                    Id = 47,
                    RoleId = 1,
                    CreativePersonId = 31,
                    MovieId = 8,

                },
                new RoleCreativeMovie
                {
                    Id = 48,
                    RoleId = 1,
                    CreativePersonId = 32,
                    MovieId = 8,

                },
                new RoleCreativeMovie
                {
                    Id = 49,
                    RoleId = 2,
                    CreativePersonId = 35,
                    MovieId = 8,

                },
                new RoleCreativeMovie
                {
                    Id = 50,
                    RoleId = 1,
                    CreativePersonId = 28,
                    MovieId = 9,

                },
                new RoleCreativeMovie
                {
                    Id = 51,
                    RoleId = 1,
                    CreativePersonId = 37,
                    MovieId = 9,

                },
                new RoleCreativeMovie
                {
                    Id = 52,
                    RoleId = 1,
                    CreativePersonId = 38,
                    MovieId = 9,

                },
                new RoleCreativeMovie
                {
                    Id = 53,
                    RoleId = 2,
                    CreativePersonId = 36,
                    MovieId = 9,

                },
                new RoleCreativeMovie
                {
                    Id = 54,
                    RoleId = 1,
                    CreativePersonId = 28,
                    MovieId = 10,

                },
                new RoleCreativeMovie
                {
                    Id = 55,
                    RoleId = 1,
                    CreativePersonId = 38,
                    MovieId = 10,

                },
                new RoleCreativeMovie
                {
                    Id = 56,
                    RoleId = 1,
                    CreativePersonId = 39,
                    MovieId = 10,

                },
                new RoleCreativeMovie
                {
                    Id = 57,
                    RoleId = 2,
                    CreativePersonId = 36,
                    MovieId = 10,

                },
                new RoleCreativeMovie
                {
                    Id = 58,
                    RoleId = 1,
                    CreativePersonId = 25,
                    MovieId = 11,

                },
                new RoleCreativeMovie
                {
                    Id = 59,
                    RoleId = 1,
                    CreativePersonId = 26,
                    MovieId = 11,

                },
                new RoleCreativeMovie
                {
                    Id = 60,
                    RoleId = 1,
                    CreativePersonId = 27,
                    MovieId = 11,

                },
                new RoleCreativeMovie
                {
                    Id = 61,
                    RoleId = 2,
                    CreativePersonId = 7,
                    MovieId = 11,

                },
                new RoleCreativeMovie
                {
                    Id = 62,
                    RoleId =1 ,
                    CreativePersonId = 4,
                    MovieId = 12,

                },
                new RoleCreativeMovie
                {
                    Id = 63,
                    RoleId = 1,
                    CreativePersonId = 23,
                    MovieId = 12,

                },
                new RoleCreativeMovie
                {
                    Id = 64,
                    RoleId = 1,
                    CreativePersonId = 24,
                    MovieId = 12,

                },
                new RoleCreativeMovie
                {
                    Id = 65,
                    RoleId = 2,
                    CreativePersonId = 7,
                    MovieId = 12,

                },
                new RoleCreativeMovie
                {
                    Id = 66,
                    RoleId = 1,
                    CreativePersonId = 14,
                    MovieId = 13,

                },
                new RoleCreativeMovie
                {
                    Id = 67,
                    RoleId = 1,
                    CreativePersonId = 21,
                    MovieId = 13,

                },
                new RoleCreativeMovie
                {
                    Id = 68,
                    RoleId = 1,
                    CreativePersonId = 22,
                    MovieId = 13,

                },
                new RoleCreativeMovie
                {
                    Id = 69,
                    RoleId = 2,
                    CreativePersonId = 20,
                    MovieId = 13,

                },
                new RoleCreativeMovie
                {
                    Id = 70,
                    RoleId = 1,
                    CreativePersonId = 41,
                    MovieId = 14,

                },
                new RoleCreativeMovie
                {
                    Id = 71,
                    RoleId = 1,
                    CreativePersonId = 42,
                    MovieId = 14,

                },
                new RoleCreativeMovie
                {
                    Id = 72,
                    RoleId = 2,
                    CreativePersonId = 40,
                    MovieId = 14,

                },
                new RoleCreativeMovie
                {
                    Id = 73,
                    RoleId = 1,
                    CreativePersonId = 44,
                    MovieId = 15,

                },
                new RoleCreativeMovie
                {
                    Id = 74,
                    RoleId = 1,
                    CreativePersonId = 43,
                    MovieId = 15,

                },
                new RoleCreativeMovie
                {
                    Id = 75,
                    RoleId = 1,
                    CreativePersonId = 41,
                    MovieId = 15,

                },
                new RoleCreativeMovie
                {
                    Id = 76,
                    RoleId = 2,
                    CreativePersonId = 40,
                    MovieId = 15,

                },
                new RoleCreativeMovie
                {
                    Id = 77,
                    RoleId = 1,
                    CreativePersonId = 45,
                    MovieId = 16,

                },
                new RoleCreativeMovie
                {
                    Id = 78,
                    RoleId = 1,
                    CreativePersonId = 46,
                    MovieId = 16,

                },
                new RoleCreativeMovie
                {
                    Id = 79,
                    RoleId = 2,
                    CreativePersonId = 40,
                    MovieId = 16,

                },
                new RoleCreativeMovie
                {
                    Id = 80,
                    RoleId = 1,
                    CreativePersonId = 48,
                    MovieId = 17,

                },
                new RoleCreativeMovie
                {
                    Id = 81,
                    RoleId = 1,
                    CreativePersonId = 11,
                    MovieId = 17,

                },
                new RoleCreativeMovie
                {
                    Id = 82,
                    RoleId = 1,
                    CreativePersonId = 47,
                    MovieId = 17,

                },
                new RoleCreativeMovie
                {
                    Id = 83,
                    RoleId = 2,
                    CreativePersonId = 40,
                    MovieId = 17,

                },
                new RoleCreativeMovie
                {
                    Id = 84,
                    RoleId = 1,
                    CreativePersonId = 17,
                    MovieId = 18,

                },
                new RoleCreativeMovie
                {
                    Id = 85,
                    RoleId = 1,
                    CreativePersonId = 19,
                    MovieId = 18,

                },
                new RoleCreativeMovie
                {
                    Id = 86,
                    RoleId = 2,
                    CreativePersonId = 49,
                    MovieId = 18,

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
                    GenreId = 10,
                    MovieId = 1,
                },
                new MovieGenre
                {
                    Id = 3,
                    GenreId = 1,
                    MovieId = 2,
                },
                new MovieGenre
                {
                    Id = 4,
                    GenreId = 2,
                    MovieId = 2,
                },
                new MovieGenre
                {
                    Id = 5,
                    GenreId = 4,
                    MovieId = 2,
                },
                new MovieGenre
                {
                    Id = 6,
                    GenreId = 1,
                    MovieId = 3,
                },
                new MovieGenre
                {
                    Id = 7,
                    GenreId = 5,
                    MovieId = 3,
                },
                new MovieGenre
                {
                    Id = 8,
                    GenreId = 7,
                    MovieId = 3,
                },
                new MovieGenre
                {
                    Id = 9,
                    GenreId = 1,
                    MovieId = 4,
                },
                new MovieGenre
                {
                    Id = 10,
                    GenreId = 2,
                    MovieId = 4,
                },
                new MovieGenre
                {
                    Id = 11,
                    GenreId = 4,
                    MovieId = 4,
                },
                new MovieGenre
                {
                    Id = 12,
                    GenreId = 1,
                    MovieId = 5,
                },
                new MovieGenre
                {
                    Id = 13,
                    GenreId = 2,
                    MovieId = 5,
                },
                new MovieGenre
                {
                    Id = 14,
                    GenreId = 4,
                    MovieId = 5,
                },
                new MovieGenre
                {
                    Id = 15,
                    GenreId = 1,
                    MovieId = 6,
                },
                new MovieGenre
                {
                    Id = 16,
                    GenreId = 2,
                    MovieId = 6,
                },
                new MovieGenre
                {
                    Id = 17,
                    GenreId = 6,
                    MovieId = 6,
                },
                new MovieGenre
                {
                    Id = 18,
                    GenreId = 7,
                    MovieId = 6,
                },
                new MovieGenre
                {
                    Id = 19,
                    GenreId = 1,
                    MovieId = 7,
                },
                new MovieGenre
                {
                    Id = 20,
                    GenreId = 2,
                    MovieId = 7,
                },
                new MovieGenre
                {
                    Id = 21,
                    GenreId = 6,
                    MovieId = 7,
                },
                new MovieGenre
                {
                    Id = 22,
                    GenreId = 9,
                    MovieId = 7,
                },
                new MovieGenre
                {
                    Id = 23,
                    GenreId = 1,
                    MovieId = 8,
                },
                new MovieGenre
                {
                    Id = 24,
                    GenreId = 2,
                    MovieId = 8,
                },
                new MovieGenre
                {
                    Id = 25,
                    GenreId = 6,
                    MovieId = 8,
                },
                new MovieGenre
                {
                    Id = 26,
                    GenreId = 9,
                    MovieId = 8,
                },
                new MovieGenre
                {
                    Id = 27,
                    GenreId = 1,
                    MovieId = 9,
                },
                new MovieGenre
                {
                    Id = 28,
                    GenreId = 2,
                    MovieId = 9,
                },
                new MovieGenre
                {
                    Id = 29,
                    GenreId = 6,
                    MovieId = 9,
                },
                new MovieGenre
                {
                    Id = 30,
                    GenreId = 1,
                    MovieId = 10,
                },
                new MovieGenre
                {
                    Id = 31,
                    GenreId = 2,
                    MovieId = 10,
                },
                new MovieGenre
                {
                    Id = 32,
                    GenreId = 6,
                    MovieId = 10,
                },
                new MovieGenre
                {
                    Id = 33,
                    GenreId = 2,
                    MovieId = 11,
                },
                new MovieGenre
                {
                    Id = 34,
                    GenreId = 5,
                    MovieId = 11,
                },
                new MovieGenre
                {
                    Id = 35,
                    GenreId = 9,
                    MovieId = 11,
                },
                new MovieGenre
                {
                    Id = 36,
                    GenreId = 1,
                    MovieId = 12,
                },
                new MovieGenre
                {
                    Id = 37,
                    GenreId = 5,
                    MovieId = 12,
                },
                new MovieGenre
                {
                    Id = 38,
                    GenreId = 5,
                    MovieId = 13,
                },
                new MovieGenre
                {
                    Id = 39,
                    GenreId = 9,
                    MovieId = 13,
                },
                new MovieGenre
                {
                    Id = 40,
                    GenreId = 5,
                    MovieId = 14,
                },
                new MovieGenre
                {
                    Id = 41,
                    GenreId = 10,
                    MovieId = 14,
                },
                new MovieGenre
                {
                    Id = 42,
                    GenreId = 5,
                    MovieId = 15,
                },
                new MovieGenre
                {
                    Id = 43,
                    GenreId = 10,
                    MovieId = 15,
                },
                new MovieGenre
                {
                    Id = 44,
                    GenreId = 5,
                    MovieId = 16,
                },
                new MovieGenre
                {
                    Id = 45,
                    GenreId = 10,
                    MovieId = 16,
                },
                new MovieGenre
                {
                    Id = 46,
                    GenreId = 5,
                    MovieId = 17,
                },
                new MovieGenre
                {
                    Id = 47,
                    GenreId = 10,
                    MovieId = 17,
                },
                new MovieGenre
                {
                    Id = 48,
                    GenreId = 1,
                    MovieId = 18,
                },
                new MovieGenre
                {
                    Id =50,
                    GenreId = 2,
                    MovieId = 18,
                },
                new MovieGenre
                {
                    Id = 51,
                    GenreId = 8,
                    MovieId = 18,
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