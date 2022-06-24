using AutoMapper;
using BusinessLogic.Interfaces;
using DataAccess.DbContext;
using MoviesPortalWebApp.Models;

namespace MoviesPortalWebApp.ServicesForControllers
{
    public class CommentsPicker
    {
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;
        private readonly MoviePortalContext _context;

        public CommentsPicker()
        {

        }

        public CommentsPicker(ICommentService commentService, IMapper mapper, MoviePortalContext context)
        {
            _commentService = commentService;
            _mapper = mapper;
            _context = context;
        }

        public async Task<List<CommentVM>> GetCommentsAsync(int movieId)
        {
            var com = await _commentService.GetAllComments(movieId);
            var comments = _mapper.Map<List<CommentVM>>(com.ToList());
            

            return comments;
        }


    }
}
