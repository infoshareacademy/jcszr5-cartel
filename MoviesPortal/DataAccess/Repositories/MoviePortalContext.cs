using DataAccess.Models;
using DataAccess.Models.EntityAssigments;
using DataAccess.Repositories.SampleData;
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
        public DbSet<MovieModel> Movies { get; set; }
        public DbSet<CreativePersonModel> CreativePersons { get; set; }
        public DbSet<TvSeriesModel> TvSeries { get; set; }
        public DbSet<SeasonModel> Seasons { get; set; }
        public DbSet<EpisodeModel> Episodes { get; set; }
        public DbSet<GenreModel> Genres { get; set; }

        //Assigment tables (for many-to-many relations)
        public DbSet<MovieCreativePerson> Movie_CreativePerson { get; set; }
        public DbSet<MovieGenre> Movie_Genre { get; set; }
        public DbSet<TvSeriesCreativePerson> TvSeries_CreativePerson { get; set; }
        public DbSet<TvSeriesGenre> TvSeries_Genre { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=localhost;Database=MoviePortalDb;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var movieModel = modelBuilder.Entity<MovieModel>();

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
                    j => j.HasOne(mc => mc.Movie).WithMany(m => m.MovieCreativePersons).HasForeignKey("MovieId"));
            movieModel.HasMany(p => p.Genres)
                .WithMany(p => p.Movies)
                .UsingEntity<MovieGenre>(
                    j => j.HasOne(mg => mg.Genre).WithMany(g => g.MovieGenres).HasForeignKey("GenreId"),
                    j => j.HasOne(mg => mg.Movie).WithMany(g => g.MovieGenres).HasForeignKey("MovieId"));


            var creativePersonModel = modelBuilder.Entity<CreativePersonModel>();
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


            var genreModel = modelBuilder.Entity<GenreModel>();
            genreModel.HasKey(x => x.Id);
            genreModel.Property(x => x.Id).HasColumnName("Id");
            genreModel.Property(x => x.Genre).HasMaxLength(20);


            var episodeModel = modelBuilder.Entity<EpisodeModel>();
            episodeModel.HasKey(x => x.Id);
            episodeModel.Property(x => x.Id).HasColumnName("Id");
            episodeModel.Property(x => x.Title).HasColumnName("Title").HasMaxLength(50);
            episodeModel.Property(x => x.Description).HasColumnName("Description").HasMaxLength(200);

            var seasonModel = modelBuilder.Entity<SeasonModel>();
            seasonModel.HasKey(x => x.Id);
            seasonModel.Property(x => x.Id).HasColumnName("Id");
            seasonModel.HasMany(x => x.Episodes).WithOne(x => x.Season);

            var tvSeriesModel = modelBuilder.Entity<TvSeriesModel>();
            tvSeriesModel.HasKey(x => x.Id);
            tvSeriesModel.Property(x => x.Id).HasColumnName("Id").IsRequired();
            tvSeriesModel.Property(p => p.Title).IsRequired().HasMaxLength(50);
            tvSeriesModel.Property(p => p.Description).IsRequired().HasMaxLength(200).HasDefaultValue("Nie dodano jeszcze żadnego opisu.");
            tvSeriesModel.Property(p => p.StartYear).HasColumnName("Start_Year");
            tvSeriesModel.Property(p => p.EndYear).HasColumnName("End_Year");
            tvSeriesModel.HasMany(p => p.CreativePersons)
                .WithMany(p => p.TvSeries)
                .UsingEntity<TvSeriesCreativePerson>(
                    j => j.HasOne(mc => mc.CreativePerson).WithMany(c => c.TvSeriesCreativePersons).HasForeignKey("CreativePersonId"),
                    j => j.HasOne(mc => mc.TvSeries).WithMany(m => m.TvSeriesCreativePersons).HasForeignKey("TvSeriesId"));
            tvSeriesModel.HasMany(p => p.Genres)
                .WithMany(p => p.TvSeries)
                .UsingEntity<TvSeriesGenre>(
                    j => j.HasOne(mg => mg.Genre).WithMany(g => g.TvSeriesGenres).HasForeignKey("GenreId"),
                    j => j.HasOne(mg => mg.TvSeries).WithMany(g => g.TvSeriesGenres).HasForeignKey("TvSeriesId"));
            tvSeriesModel.HasMany(x => x.Seasons).WithOne(x => x.TvSeries);


            //Seeding some data

            var movie_CreativePersons = modelBuilder.Entity<MovieCreativePerson>();

            movieModel.HasData(MovieSampleData.sampleMovie);
            creativePersonModel.HasData(ActorSampleData.sampleActor, ActorSampleData.sampleDirector);
            
            
            //Relations
            movie_CreativePersons.HasData(
                new MovieCreativePerson
                {
                    MovieId = 1,
                    CreativePersonId = 1
                },
                new MovieCreativePerson
                {
                    MovieId= 1,
                    CreativePersonId=2                
                });
            genreModel.HasData(GenreSampleData.sampleGenres);
        }

    }
}
