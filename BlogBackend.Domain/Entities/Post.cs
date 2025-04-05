using System;
using System.Collections.Generic;

namespace BlogBackend.Domain.Entities
{
    public class Post
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public Guid AuthorId { get; set; }
        public User Author { get; set; }
        public DateTime PublishedAt { get; set; } = DateTime.UtcNow;

        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
} 