using AutoMapper;
using BusinessLogic.Interfaces;
using DataAccess.DbContext;
using DataAccess.Models;
using Microsoft.AspNetCore.Identity;
using MoviesPortalWebApp.Models;

namespace MoviesPortalWebApp.ServicesForControllers
{
    public class CommentsPicker
    {
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;
        
        private readonly UserManager<ApplicationUser> _userManager;

        public CommentsPicker()
        {

        }

        public CommentsPicker(ICommentService commentService, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _commentService = commentService;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<List<CommentVM>> GetCommentsAsync(int movieId)
        {
            var com = await _commentService.GetAllComments(movieId);
            var comments = _mapper.Map<List<CommentVM>>(com.ToList());

            foreach (var comment in comments)
            {
                var applicationUser =await _userManager.FindByIdAsync(comment.UserId);
                comment.UserName = applicationUser.FullName;                
            }

            return comments;
        }


    }
}
