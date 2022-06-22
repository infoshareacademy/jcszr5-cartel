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

        public CommentService(ICommentRepository commentService)
        {
            _commentRepository = commentService;
        }

        public async Task AddComment(CommentModel comment)
        {
            await _commentRepository.Create(comment);
        }

        public async Task DeleteComment(int id)
        {
            await _commentRepository.Delete(id);
        }

        public async Task<List<CommentModel>> GetAllComments()
        {
            var comments = await _commentRepository.GetAllComments();
            return comments.ToList();
        }

        public async Task<CommentModel> GetComment(int id)
        {
            return await _commentRepository.GetComment(id);
        }

        public async Task UpdateComment(int id, CommentModel comment)
        {
            await _commentRepository.Edit(id, comment);
        }
    }

    
}
