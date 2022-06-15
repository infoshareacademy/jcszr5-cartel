using DataAccess.DbContext;
using DataAccess.Models;
using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly MoviePortalContext _context;

        public CommentRepository(MoviePortalContext context)
        {
            _context = context;
        }

        public async Task Create(CommentModel comment)
        {
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var comment =await GetComment(id);
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(int id, CommentModel comment)
        {
            var oldComment = await GetComment(id);
            oldComment.MovieId = comment.MovieId;
            oldComment.CommentContent = comment.CommentContent;
            oldComment.UserId = comment.UserId;
            oldComment.Id = comment.Id;
            oldComment.PublishedAt = comment.PublishedAt;

            await _context.SaveChangesAsync();
        }

        public async Task<IQueryable<CommentModel>> GetAllComments()
        {
            var comments = _context.Comments.Include(u => u.ApplicationUser);
            return comments;
        }

        public async Task<CommentModel> GetComment(int id)
        {
            return await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
