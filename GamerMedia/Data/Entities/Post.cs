using System;
using System.Collections.Generic;

namespace GamerMedia.Data.Entities
{
    public partial class Post
    {
        public Post()
        {
            Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Created { get; set; }
        public string Title { get; set; } = null!;
        public string Body { get; set; } = null!;
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public bool IsActive { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
