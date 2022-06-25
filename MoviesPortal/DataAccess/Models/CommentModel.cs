using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class CommentModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int MovieId { get; set; }
        public string CommentContent { get; set; }
        public DateTime PublishedAt { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
