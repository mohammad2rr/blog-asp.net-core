using System;

namespace BlogBackend.Application.DTOs.Roles
{
    public class PermissionRequest
    {
        public Guid RoleId { get; set; }
        public string ApiEndpoint { get; set; } = string.Empty;
    }
} 