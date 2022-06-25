using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Interfaces
{
    public interface ICommentRepository
    {
        public Task Create(CommentModel comment);

        public Task Delete(int id);
        
        Task Edit(int id, CommentModel comment);
        
        Task<IQueryable<CommentModel>> GetAllComments(int movieId);
        
        Task<CommentModel> GetComment(int id);
    }
}
