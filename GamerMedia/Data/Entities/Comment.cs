using System;
using System.Collections.Generic;

namespace GamerMedia.Data.Entities
{
    public partial class Comment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public DateTime Created { get; set; }
        public string Body { get; set; } = null!;
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public int IsActive { get; set; }

        public virtual Post Post { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
