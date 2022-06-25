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

        public Task Delete(int id);

        Task Edit(int id, CommentModel comment);

        Task<IQueryable<CommentModel>> GetAllComments(int movieId);

        Task<CommentModel> GetComment(int id);
    }
}
