using DataAccess.DbContext;
using DataAccess.Models;
using DataAccess.Models.EntityAssigments;

namespace BusinessLogic.AssignationServices
{
    public class TvSeriesAssignationService
    {
        private readonly MoviePortalContext _context;

        public TvSeriesAssignationService(MoviePortalContext context)
        {
            _context = context;
        }

        public async Task AssignGenre(TvSeriesModel tvSeries, int[] genreIds)
        {

            foreach (var genreId in genreIds)
            {
                var assignation = new TvSeriesGenre();
                assignation.TvSeriesId = tvSeries.Id;
                assignation.GenreId = genreId;
                await _context.TvSeries_Genre.AddAsync(assignation);
                await _context.SaveChangesAsync();
            }
        }
        //public async Task AssignCreativePerson(TvSeriesModel tvSeries, int[] personsIds)
        //{
        //    foreach (var personId in personsIds)
        //    {
        //        var assignation = new TvSeriesCreativePerson();
        //        assignation.TvSeriesId = tvSeries.Id;
        //        assignation.CreativePersonId = personId;
        //        await _context.TvSeries_CreativePerson.AddAsync(assignation);
        //        await _context.SaveChangesAsync();
        //    }
                
    }
}
