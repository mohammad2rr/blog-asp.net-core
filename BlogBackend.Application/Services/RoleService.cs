using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogBackend.Application.DTOs.Roles;
using BlogBackend.Application.Interfaces;
using BlogBackend.Domain.Entities;
using BlogBackend.Domain.Interfaces;

namespace BlogBackend.Application.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRepository<Role> _roleRepository;
        private readonly IRepository<UserRole> _userRoleRepository;
        private readonly IRepository<Permission> _permissionRepository;

        public RoleService(IRepository<Role> roleRepository, IRepository<UserRole> userRoleRepository, IRepository<Permission> permissionRepository)
        {
            _roleRepository = roleRepository;
            _userRoleRepository = userRoleRepository;
            _permissionRepository = permissionRepository;
        }

        public async Task<bool> CreateRoleAsync(CreateRoleRequest request)
        {
            var existingRole = (await _roleRepository.GetAllAsync()).FirstOrDefault(r => r.Name == request.RoleName);
            if (existingRole != null)
                return false;

            var newRole = new Role { Name = request.RoleName };
            await _roleRepository.AddAsync(newRole);
            return true;
        }

        public async Task<bool> AssignRoleToUserAsync(AssignRoleRequest request)
        {
            var userRole = new UserRole
            {
                UserId = request.UserId,
                RoleId = request.RoleId
            };

            await _userRoleRepository.AddAsync(userRole);
            return true;
        }

        public async Task<bool> AssignPermissionAsync(PermissionRequest request)
        {
            var permission = new Permission
            {
                RoleId = request.RoleId,
                ApiEndpoint = request.ApiEndpoint
            };

            await _permissionRepository.AddAsync(permission);
            return true;
        }

        public async Task<IEnumerable<Role>> GetAllRolesAsync() => await _roleRepository.GetAllAsync();
    }
} 