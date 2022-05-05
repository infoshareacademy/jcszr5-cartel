using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using DataAccess.Models;
using DataAccess.Models.EntityAssigments;
using DataAccess.Repositories;
using DataAccess.Repositories.Interfaces;
using DataAccess.Repositories.SampleData;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MoviePortalContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));
builder.Services.AddTransient<ITvSeriesRepository, TvSeriesRepository>();
builder.Services.AddTransient<IEpisodeRepository, EpisodeRepository>();
builder.Services.AddTransient<ISeasonRepository, SeasonRepository>();
builder.Services.AddTransient<ICreativePersonRepository, CreativePersonRepository>();
builder.Services.AddTransient<IMovieRepository, MovieRepository>();
builder.Services.AddTransient<ITvSeriesService, TvSeriesService>();
builder.Services.AddTransient<IMovieService, MovieService>();
builder.Services.AddTransient<ICreativePersonService, CreativePersonService>();

builder.Services.AddAutoMapper(typeof(Program));

//Authentication and authorization
builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<DataAccess.Repositories.MoviePortalContext>();
builder.Services.AddMemoryCache();
builder.Services.AddSession();
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
});


var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Movie}/{action=IndexUser}/{id?}");

AppDbInitializer.SeedUsersAndRoleAsync(app).Wait();

using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetService<MoviePortalContext>();
var tvSeries = dbContext.TvSeries.ToList();
if (!tvSeries.Any())
{
    var series1 = new TvSeriesModel()
    {
        Title = "Chernobyl",
        Description = "On April 26, 1986, the Chernobyl Nuclear Power Plant in the Soviet Union suffered a massive explosion. This gripping five-part miniseries tells the powerful and visceral story of the worst man-made accident in history, following the tragedy from the moment of the early-morning explosion through the chaos and loss of life in the ensuing days, weeks and months.",
        Genres = new List<GenreModel>()
        {
            new GenreModel() { Genre = "drama" },
            new GenreModel() { Genre = "historical"}
        },
        StartYear = 2019,
        EndYear = 2019,
        PosterPath = "https://www.imdb.com/title/tt7366338/mediaviewer/rm1017111809/",
        TrailerUrl = "https://www.youtube.com/watch?v=s9APLXM9Ei8",
        ImdbRatio = "9,4",
        Seasons = new List<SeasonModel>() { new SeasonModel()
        {
            SeasonNumber = 1,
            Episodes = new List<EpisodeModel>()
            {
                new EpisodeModel()
                {
                    Title = "1:23:45",
                    Description="Plant workers and firefighters put their lives on the line to control a catastrophic April 1986 explosion at a Soviet nuclear power plant."
                },
                new EpisodeModel()
                {
                    Title = "Please Remain Calm",
                    Description="With untold millions at risk, Ulana makes a desperate attempt to reach Valery and warn him about the threat of a second explosion."
                },
                new EpisodeModel()
                {
                    Title = "Open Wide, O Earth",
                    Description="Valery creates a detailed plan to decontaminate Chernobyl; Lyudmilla ignores warnings about her firefighter husband's contamination."
                },
                new EpisodeModel()
                {
                    Title = "The Happiness of All Mankind",
                    Description="Valery and Boris attempt to find solutions to removing the radioactive debris; Ulana attempts to find out the cause of the explosion."
                },
                new EpisodeModel()
                {
                    Title = "Vichnaya Pamyat",
                    Description="Valery, Boris and Ulana risk their lives and reputations to expose the truth about Chernobyl."
                }
            }

        } },

    };
    var creativesForSeries1 = new List<TvSeries_CreativeP_Role>()
    {
        new TvSeries_CreativeP_Role()
        {
            TvSeries = series1,
            CreativePerson = new CreativePersonModel()
            {
                Name = "Craig",
                SurName = "Mazin",
                PhotographyPath ="https://www.imdb.com/name/nm0563301/mediaviewer/rm3352585984/",

            },
            RoleId = 2
        },
        new TvSeries_CreativeP_Role()
        {
            TvSeries = series1,
            CreativePerson = new CreativePersonModel()
            {
                Name = "Jessie",
                SurName = "Buckley",
                PhotographyPath ="https://www.imdb.com/name/nm2976580/mediaviewer/rm3908089857/",
            },
            RoleId = 1
        },
        new TvSeries_CreativeP_Role()
        {
            TvSeries = series1,
            CreativePerson = new CreativePersonModel()
            {
                Name = "Jared",
                SurName = "Harris",
                PhotographyPath ="https://www.imdb.com/name/nm0364813/mediaviewer/rm3066069249/"

            },
            RoleId = 1
        },
        new TvSeries_CreativeP_Role()
        {
            TvSeries = series1,
            CreativePerson = new CreativePersonModel()
            {
                Name = "Stellan",
                SurName = "Skarsgard",
                PhotographyPath ="https://www.imdb.com/name/nm0001745/mediaviewer/rm1537180929/",

            },
            RoleId = 1
        },
    };


    dbContext.TvSeries.Add(series1);
    dbContext.TvSeries_CreativeP_Role.AddRange(creativesForSeries1);
    dbContext.SaveChanges();
}

app.Run();
