using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface ICommentService
    {
        public Task AddComment(CommentModel comment);
        public Task DeleteComment(int id);
        public Task UpdateComment(int id, CommentModel comment);
        public Task<List<CommentModel>> GetAllComments(int movieId);
        public Task<CommentModel> GetComment(int id);

    }
}
