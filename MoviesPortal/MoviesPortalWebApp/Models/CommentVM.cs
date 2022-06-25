using DataAccess.Models;

namespace MoviesPortalWebApp.Models
{
    public class CommentVM
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public int MovieId { get; set; }
        public string PublishedAt { get; set; }
        public ApplicationUser User { get; set; }
    }
}