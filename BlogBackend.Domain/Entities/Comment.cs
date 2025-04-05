using System;

namespace BlogBackend.Domain.Entities
{
    public class Comment
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Content { get; set; } = string.Empty;
        public Guid PostId { get; set; }
        public Post Post { get; set; }
        public Guid AuthorId { get; set; }
        public User Author { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
} 