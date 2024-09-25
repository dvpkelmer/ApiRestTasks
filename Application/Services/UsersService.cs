using ApiRestTask.Application.Interfaces;
using ApiRestTask.Data;
using ApiRestTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using ApiRestTask.Application.DTOs;


namespace ApiRestTask.Application.Services
{

    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private readonly JwtTokenService _jwtTokenService;

        public UserService(AppDbContext context, JwtTokenService jwtTokenService)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _jwtTokenService = jwtTokenService ?? throw new ArgumentNullException(nameof(jwtTokenService));
        }

        public async Task<AuthResponseDto> AuthenticateAsync(string email, string password)
        {
            var user = await _context.Users
                .Include(u => u.Role)
                .SingleOrDefaultAsync(x => x.Email == email);

            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                return null;
            }

            if (user.Role == null)
            {
                throw new Exception("User has no role assigned.");
            }

            var token = _jwtTokenService.GenerateToken(user);

            return new AuthResponseDto
            {
                Status = "Success",
                Token = token
            };
        }

        public async Task<UserDto> CreateUserAsync(UserDto userDto)
        {
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(userDto.Password);

            var user = new User
            {
                UserName = userDto.UserName,
                Email = userDto.Email,
                PasswordHash = hashedPassword,
                RoleId = userDto.RoleId
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            userDto.Id = user.Id;
            return userDto;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _context.Users
                .Include(u => u.Role) 
                .ToListAsync();

            return users.Select(user => new UserDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Role = user.Role 
            });
        }

        public async Task<UserDto?> GetUserByIdAsync(int userId)
        {
            var user = await _context.Users
                            .Include(u => u.Role)
                            .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null) return null;

            return new UserDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Role = user.Role 
            };
        }


        public async Task UpdateUserAsync(int userId, UserDto userDto)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (existingUser == null)
            {
                throw new KeyNotFoundException("User not found");
            }

            existingUser.Email = userDto.Email;
            existingUser.UserName = userDto.UserName;
            existingUser.RoleId = userDto.RoleId;


            _context.Users.Update(existingUser);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                throw new KeyNotFoundException("User not found");
            }

            _context.Users.Remove(user);

            await _context.SaveChangesAsync();
        }

    }
}