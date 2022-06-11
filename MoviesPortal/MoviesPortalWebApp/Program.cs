using BusinessLogic.ApiHandler;
using BusinessLogic.ApiHandler.ApiModels.ContentProvidersClasses;
using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using BusinessLogic.Validation;
using DataAccess.DbContext;
using DataAccess.Models;
using DataAccess.Models.EntityAssigments;
using DataAccess.Repositories;
using DataAccess.Repositories.Interfaces;
using DataAccess.Repositories.SampleData;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MoviesPortalWebApp.ServicesForControllers;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MoviePortalContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));
builder.Services.AddTransient</*ITvSeriesRepository,*/ TvSeriesRepository>();
builder.Services.AddTransient<IEpisodeRepository, EpisodeRepository>();
builder.Services.AddTransient<IEpisodeService, EpisodeService>();
builder.Services.AddTransient<ISeasonRepository, SeasonRepository>();
builder.Services.AddTransient<ISeasonService, SeasonService>();
builder.Services.AddTransient<ICreativePersonRepository, CreativePersonRepository>();
builder.Services.AddTransient<IMovieRepository, MovieRepository>();
builder.Services.AddTransient<ITvSeriesService, TvSeriesService>();
builder.Services.AddTransient<IMovieService, MovieService>();
builder.Services.AddTransient<ICreativePersonService, CreativePersonService>();
builder.Services.AddTransient<ICreativePersonValidator, CreativePersonValidator>();
builder.Services.AddTransient<IGenreService, GenreService>();
builder.Services.AddTransient<IGenreRepository, GenreRepository>();
builder.Services.AddScoped<ApiClient>();
builder.Services.AddScoped<PersonsAgregator>();

builder.Services.AddAutoMapper(typeof(Program));

//Authentication and authorization
builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<MoviePortalContext>();
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
    pattern: "{controller=Home}/{action=Index}/{id?}");

AppDbInitializer.SeedUsersAndRoleAsync(app).Wait();

using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetService<MoviePortalContext>();
var tvSeries = dbContext.TvSeries.ToList();

var series1 = new TvSeriesModel()
{
    Title = "Chernobyl",
    Description = "On April 26, 1986, the Chernobyl Nuclear Power Plant in the Soviet Union suffered a massive explosion. This gripping five-part miniseries tells the powerful and visceral story of the worst man-made accident in history, following the tragedy from the moment of the early-morning explosion through the chaos and loss of life in the ensuing days, weeks and months.",
    Genres = new List<GenreModel>()
        {
            dbContext.Genres.FirstOrDefault(g => g.Genre=="drama"),
            dbContext.Genres.FirstOrDefault(g => g.Genre=="historical")
        },
    StartYear = 2019,
    EndYear = 2019,
    PosterPath = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fwww.themoviedb.org%2Ft%2Fp%2Foriginal%2FbdDmqTO82N536K9YsjO6U2gIpSI.jpg",
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
var series2 = new TvSeriesModel()
{
    Title = "Sherlock",
    Description = "In this modernized version of the Conan Doyle characters, using his detective plots, Sherlock Holmes lives in early 21st century London and acts more cocky towards Scotland Yard's detective inspector Lestrade because he's actually less confident. Doctor Watson is now a fairly young veteran of the Afghan war, less adoring and more active.",
    Genres = new List<GenreModel>()
        {
            dbContext.Genres.FirstOrDefault(g => g.Genre == "drama"),
            new GenreModel() { Genre = "crime"},
            new GenreModel() { Genre = "mystery"}
        },
    StartYear = 2010,
    EndYear = 2017,
    PosterPath = "https://static.posters.cz/image/1300/plakaty/sherlock-series-4-iconic-i33910.jpg",
    TrailerUrl = "https://www.youtube.com/watch?v=IrBKwzL3K7s",
    ImdbRatio = "9,1",
    Seasons = new List<SeasonModel>() {
        new SeasonModel()
        {
            SeasonNumber = 1,
            Episodes = new List<EpisodeModel>()
            {
                new EpisodeModel()
                {
                    Title = "Unaired Pilot",
                    Description="Invalided home from the war in Afghanistan, Dr. John Watson becomes roommates with the world's only consulting detective, Sherlock Holmes. Within a day their friendship is forged and several murders are solved."
                },
                new EpisodeModel()
                {
                    Title = "A Study in Pink",
                    Description="War vet Dr. John Watson returns to London in need of a place to stay. He meets Sherlock Holmes, a consulting detective, and the two soon find themselves digging into a string of serial \"suicides.\""
                },
                new EpisodeModel()
                {
                    Title = "The Blind Banker",
                    Description="Mysterious symbols and murders are showing up all over London, leading Sherlock and John to a secret Chinese crime syndicate called Black Lotus."
                },
                new EpisodeModel()
                {
                    Title = "The Great Game",
                    Description="Mycroft needs Sherlock's help, but a remorseless criminal mastermind puts Sherlock on a distracting crime-solving spree via a series of hostage human bombs through which he speaks."
                },

            }

        },
        new SeasonModel()
        {
            SeasonNumber = 2,
            Episodes = new List<EpisodeModel>()
            {
                new EpisodeModel()
                {
                    Title = "A Scandal in Belgravia",
                    Description="Sherlock must confiscate something of importance from a mysterious woman named Irene Adler."
                },
                new EpisodeModel()
                {
                    Title = "The Hounds of Baskerville",
                    Description="Sherlock and John investigate the ghosts of a young man who has been seeing monstrous hounds out in the woods where his father died."
                },
                new EpisodeModel()
                {
                    Title = "The Reichenbach Fall",
                    Description="Jim Moriarty hatches a mad scheme to turn the whole city against Sherlock."
                },
            }

        },
        new SeasonModel()
        {
            SeasonNumber = 3,
            Episodes = new List<EpisodeModel>()
            {
                new EpisodeModel()
                {
                    Title = "Many Happy Returns",
                    Description="John and Lestrade try to move on with their lives after Sherlock's apparent death. However, Anderson believes he is still alive."
                },
                new EpisodeModel()
                {
                    Title = "The Empty Hearse",
                    Description="Mycroft calls Sherlock back to London to investigate an underground terrorist organization."
                },
                new EpisodeModel()
                {
                    Title = "The Sign of Three",
                    Description="Sherlock tries to give the perfect best man speech at John's wedding when he suddenly realizes a murder is about to take place."
                },
                new EpisodeModel()
                {
                    Title = "His Last Vow",
                    Description="Sherlock goes up against Charles Augustus Magnussen, media tycoon and a notorious blackmailer."
                },

            }

        },
        new SeasonModel()
        {
            SeasonNumber = 4,
            Episodes = new List<EpisodeModel>()
            {
                new EpisodeModel()
                {
                    Title = "The Abominable Bride",
                    Description="Sherlock Holmes and Dr. Watson find themselves in 1890s London in this Christmas special."
                },
                new EpisodeModel()
                {
                    Title = "The Six Thatchers",
                    Description="Sherlock takes on the case of finding out who is going around and smashing six unique head statues of late Prime Minister Margaret Thatcher."
                },
                new EpisodeModel()
                {
                    Title = "The Lying Detective",
                    Description="Sherlock goes up against the powerful and seemingly unassailable Culverton Smith - a man with a very dark secret indeed."
                },
                new EpisodeModel()
                {
                    Title = "The Final Problem",
                    Description="A dark secret in the Holmes family rears its head with a vengeance, putting Sherlock and friends through a series of sick, manipulative psychological and potentially fatal games."
                },

            }

        }
    },
};
var creativesForSeries = new List<TvSeries_CreativeP_Role>()
    {
        new TvSeries_CreativeP_Role()
        {
            TvSeries = series1,
            CreativePerson = new CreativePersonModel()
            {
                Name = "Craig",
                SurName = "Mazin",
                PhotographyPath ="https://static.kino.de/wp-content/uploads/1997/12/Craig-Mazin-GettyImages-1128326044.jpg",
                DateOfBirth =new DateTime(1971, 4, 8)

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
                PhotographyPath ="https://i0.wp.com/www.theglassmagazine.com/wp/wp-content/uploads/2015/10/IMG_3310.jpg",
                DateOfBirth = new DateTime(1989, 12, 28)
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
                PhotographyPath ="https://cdn.gracza.pl/galeria/mdb/o/364564687.jpg",
                DateOfBirth =new DateTime(1961, 8, 24)

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
                PhotographyPath ="https://static.wikia.nocookie.net/exorcist9990/images/b/b2/StellanSkarsg%C3%A5rd.jpg",
                DateOfBirth =new DateTime(1951, 6, 13)

            },
            RoleId = 1
        },
        new TvSeries_CreativeP_Role()
        {
            TvSeries = series2,
            CreativePerson = new CreativePersonModel()
            {
                Name = "Mark",
                SurName = "Gatiss",
                PhotographyPath ="https://static.wikia.nocookie.net/bakerstreet/images/0/07/Mark-gatiss.jpg",
                DateOfBirth =new DateTime(1966, 10, 17)

            },
            RoleId = 2
        },
        new TvSeries_CreativeP_Role()
        {
            TvSeries = series2,
            CreativePerson = new CreativePersonModel()
            {
                Name = "Steven",
                SurName = "Moffat",
                PhotographyPath ="https://static.tvtropes.org/pmwiki/pub/images/doctor_who_steven_moffat_839121.jpg",
                DateOfBirth =new DateTime(1961, 11, 18)

            },
            RoleId = 2
        },
        new TvSeries_CreativeP_Role()
        {
            TvSeries = series2,
            CreativePerson = new CreativePersonModel()
            {
                Name = "Benedict",
                SurName = "Cumberbatch",
                PhotographyPath ="https://media.gq-magazine.co.uk/photos/5d1396f69a22c2dbd2947f2e/master/w_1600%2Cc_limit/Benedict-Cumberbatch-GQ-29Sep14_b.jpg",
                DateOfBirth =new DateTime(1951, 6, 13)

            },
            RoleId = 1
        },
        new TvSeries_CreativeP_Role()
        {
            TvSeries = series2,
            CreativePerson = new CreativePersonModel()
            {
                Name = "Una",
                SurName = "Stubbs",
                PhotographyPath ="https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fi.pinimg.com%2Foriginals%2F63%2F78%2Fa8%2F6378a8f13a03ca0ae8bce55c25879a2f.jpg",
                DateOfBirth =new DateTime(1937, 5, 1)

            },
            RoleId = 1
        },
        new TvSeries_CreativeP_Role()
        {
            TvSeries = series2,
            CreativePerson = new CreativePersonModel()
            {
                Name = "Martin",
                SurName = "Freeman",
                PhotographyPath ="https://i.pinimg.com/474x/ff/91/7e/ff917e24a9507c9633a5912c714eb6ca.jpg",
                DateOfBirth =new DateTime(1971, 9, 8)

            },
            RoleId = 1
        },
    };

var listOfTvSeries = new List<TvSeriesModel>() { series1, series2 };

if (!dbContext.TvSeries.Any())
{
    dbContext.TvSeries.AddRange(listOfTvSeries);
    dbContext.TvSeries_CreativeP_Role.AddRange(creativesForSeries);
    dbContext.SaveChanges();
}

ApiClient client = new();
var result = await client.GetPersons(284053);
app.Run();
