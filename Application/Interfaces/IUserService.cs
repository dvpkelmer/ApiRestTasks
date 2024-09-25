using ApiRestTask.Application.DTOs;
using ApiRestTask.Domain.Entities;

namespace ApiRestTask.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserDto?> GetUserByIdAsync(int userId);
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<UserDto> CreateUserAsync(UserDto userDto);
        Task UpdateUserAsync(int userId, UserDto userDto);
        Task DeleteUserAsync(int userId);
        Task<AuthResponseDto> AuthenticateAsync(string email, string password);
    }
}
