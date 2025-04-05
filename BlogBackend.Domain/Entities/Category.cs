using System.Collections.Generic;

namespace BlogBackend.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public ICollection<PostCategory> PostCategories { get; set; }
    }
} 