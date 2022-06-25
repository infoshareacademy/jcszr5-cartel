using BusinessLogic.Interfaces;
using DataAccess.Models;
using DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public Task AddComment(CommentModel comment)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task Edit(int id, CommentModel comment)
        {
            throw new NotImplementedException();
        }

        public async Task<IQueryable<CommentModel>> GetAllComments(int movieId)
        {
            var comments = await _commentRepository.GetAllComments(movieId);
            return comments;
        }

        public Task<CommentModel> GetComment(int id)
        {
            throw new NotImplementedException();
        }
    }
}
