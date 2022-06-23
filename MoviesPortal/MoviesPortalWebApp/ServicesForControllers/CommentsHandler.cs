using AutoMapper;
using BusinessLogic.Interfaces;
using MoviesPortalWebApp.Models;

namespace MoviesPortalWebApp.ServicesForControllers
{
    public class CommentsHandler
    {
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;

        public CommentsHandler(ICommentService commentService, IMapper mapper)
        {
            _commentService = commentService;
            _mapper = mapper;
        }

        public CommentsHandler()
        {
        }
        public async Task<List<CommentVM>> ShowAllComments(int movieId)
        {
            var comments =await _commentService.GetAllComments(movieId);
            var mappedComments = _mapper.Map<List<CommentVM>>(comments);
            return mappedComments;
        }
    }
}
