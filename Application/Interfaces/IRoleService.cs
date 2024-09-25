using ApiRestTask.Application.DTOs;
using ApiRestTask.Domain.Entities;

namespace ApiRestTask.Application.Interfaces
{
    public interface IRoleService
    {
        Task<IEnumerable<Role>> GetAllRolesAsync();
        Task<Role> CreateRoleAsync(RoleDto roleDto);
        Task<Role> UpdateRoleAsync(int roleId, Role roleDto);
        Task DeleteRoleAsync(int roleId);
        Task<Role?> GetRoleByIdAsync(int roleId);
    }
}
