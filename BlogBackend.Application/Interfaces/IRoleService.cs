using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlogBackend.Application.DTOs.Roles;
using BlogBackend.Domain.Entities;

namespace BlogBackend.Application.Interfaces
{
    public interface IRoleService
    {
        Task<bool> CreateRoleAsync(CreateRoleRequest request);
        Task<bool> AssignRoleToUserAsync(AssignRoleRequest request);
        Task<bool> AssignPermissionAsync(PermissionRequest request);
        Task<IEnumerable<Role>> GetAllRolesAsync();
    }
} 