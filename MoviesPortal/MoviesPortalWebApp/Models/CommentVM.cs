namespace MoviesPortalWebApp.Models
{
    public class CommentVM
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int MovieId { get; set; }
        public string CommentContent { get; set; }
        public DateTime PublishedAt { get; set; }
        public string UserLogin { get; set; }
    }
}
