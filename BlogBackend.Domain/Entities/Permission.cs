using System;
using System.Collections.Generic;

namespace BlogBackend.Domain.Entities
{
    public class Permission
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid RoleId { get; set; }
        public Role Role { get; set; }

        public string Page { get; set; } = string.Empty;  // Page or API name
        public string Action { get; set; } = string.Empty; // CRUD operations (Create, Read, Update, Delete)
    }
} 