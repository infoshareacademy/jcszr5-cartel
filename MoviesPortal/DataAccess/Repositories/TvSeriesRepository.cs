using DataAccess.DbContext;
using DataAccess.Models;
using DataAccess.Models.EntityAssigments;
using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class TvSeriesRepository //: ITvSeriesRepository
    {
        private readonly MoviePortalContext _context;

        public TvSeriesRepository(MoviePortalContext context)
        {
            _context = context;
        }

        public async Task Create(TvSeriesModel tvSeriesModel)
        {
            _context.TvSeries.Add(tvSeriesModel);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var series = _context.TvSeries.FirstOrDefault(x => x.Id == id);
            _context.TvSeries.Remove(series);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(int id, TvSeriesModel tvSeriesModel)
        {
            var series = _context.TvSeries.FirstOrDefault(x => x.Id == id);
            if (series != null)
            {
                series.Title = tvSeriesModel.Title;
                series.StartYear = tvSeriesModel.StartYear;
                series.EndYear = tvSeriesModel.EndYear;
                series.Description = tvSeriesModel.Description;
                series.Genres = tvSeriesModel.Genres;
                
                series.PosterPath = tvSeriesModel.PosterPath;
                series.TrailerUrl = tvSeriesModel.TrailerUrl;
            }
            await _context.SaveChangesAsync();
        }

        public IQueryable<TvSeriesModel> GetAll() => _context.TvSeries
            .Include(g => g.Genres)
            .Include(s => s.Seasons);


        public async Task<TvSeriesModel> GetById(int id)
        {
            var tvSeries = await _context.TvSeries
                .Include(g => g.Genres)
                .Include(c => c.TvSeries_CreativeP_Role).ThenInclude(c => c.CreativePerson)
                .Include(r => r.TvSeries_CreativeP_Role).ThenInclude(r => r.Role)
                .Include(s => s.Seasons).ThenInclude(s => s.Episodes)
                .FirstOrDefaultAsync(x => x.Id == id);
            return tvSeries;
        }
        
    }
}
