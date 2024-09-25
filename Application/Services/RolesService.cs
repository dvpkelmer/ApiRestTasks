using ApiRestTask.Application.DTOs;
using ApiRestTask.Application.Interfaces;
using ApiRestTask.Data;
using ApiRestTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiRestTask.Application.Services
{

    public class RoleService : IRoleService
    {
        private readonly AppDbContext _context;

        public RoleService(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Role> CreateRoleAsync(RoleDto roleDto)
        {
            var role = new Role
            {
                Name = roleDto.Name
            };

            _context.Roles.Add(role);
            await _context.SaveChangesAsync();

            return role;
        }


        public Task DeleteRoleAsync(int roleId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Role>> GetAllRolesAsync()
        {
            return await _context.Roles.ToListAsync();
        }


        public async Task<Role?> GetRoleByIdAsync(int roleId)
        {
            return await _context.Roles.FirstOrDefaultAsync(r => r.Id == roleId);
        }

        public Task<Role> UpdateRoleAsync(int roleId, Role roleDto)
        {
            throw new NotImplementedException();
        }

    }
}