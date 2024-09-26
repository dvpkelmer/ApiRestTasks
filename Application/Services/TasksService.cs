using ApiRestTask.Application.Interfaces;
using ApiRestTask.Application.DTOs;
using ApiRestTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using ApiRestTask.Data;

namespace ApiRestTask.Application.Services
{
    public class TaskService : ITaskService
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public TaskService(AppDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;

        }

        public async Task<TaskResponseDto> CreateTaskAsync(TaskDto taskDto)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst("userId")?.Value;

            if (userId == null)
            {
                throw new UnauthorizedAccessException("No se puede obtener el ID del usuario autenticado.");
            }

            var task = new Tasks
            {
                Name = taskDto.Name,
                Description = taskDto.Description,
                Status = taskDto.Status,
                CreatedById = int.Parse(userId)
            };

            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();

            return new TaskResponseDto
            {
                Id = task.Id,
                Name = task.Name,
                Description = task.Description,
                Status = task.Status,
                CreatedById = task.CreatedById
            };
        }

        public async Task<IEnumerable<TaskGroupedResponseDto>> GetAllTasksAsync()
        {
            var userId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirst("userId")?.Value);
            var userRole = _httpContextAccessor.HttpContext.User.FindFirst("rol")?.Value;

            IQueryable<Tasks> query;

            if (userRole == "Administrador" || userRole == "Supervisor")
            {
                query = _context.Tasks;
            }
            else if (userRole == "Empleado")
            {
                query = _context.Tasks.Where(t => t.CreatedById == userId || t.AssignedId == userId);
            }
            else
            {
                throw new UnauthorizedAccessException("No tienes permiso para acceder a estas tareas.");
            }

            var tasks = await query
                .Include(t => t.AssignedUser)
                .Select(t => new TaskResponseDto
                {
                    Id = t.Id,
                    Name = t.Name,
                    Description = t.Description,
                    Status = t.Status,
                    AssignedId = t.AssignedId,
                    CreatedById = t.CreatedById,
                    AssignedUserName = t.AssignedUser != null ? t.AssignedUser.UserName : null,  // Nombre del usuario asignado
                }).ToListAsync();

            var groupedTasks = tasks
                .GroupBy(t => t.Status)
                .Select(g => new TaskGroupedResponseDto
                {
                    Status = g.Key,
                    Tasks = g.ToList()
                })
                .ToList();

            return groupedTasks;
        }


        public async Task<TaskResponseDto?> GetTaskByIdAsync(int taskId)
        {
            var task = await _context.Tasks.FindAsync(taskId);

            if (task == null) return null;

            return new TaskResponseDto
            {
                Id = task.Id,
                Name = task.Name,
                Description = task.Description,
                Status = task.Status,
                AssignedId = task.AssignedId,
                CreatedById = task.CreatedById
            };
        }

        public async Task UpdateTaskAsync(int taskId, UpdateTaskDto taskDto)
        {
            var task = await _context.Tasks.FindAsync(taskId);

            if (task == null)
            {
                throw new KeyNotFoundException("Task not found");
            }

            if (!string.IsNullOrWhiteSpace(taskDto.Status))
            {
                task.Status = taskDto.Status;
            }

            if (taskDto.AssignedId.HasValue)
            {
                task.AssignedId = taskDto.AssignedId;
            }

            await _context.SaveChangesAsync();
        }



        public async Task DeleteTaskAsync(int taskId)
        {
            var task = await _context.Tasks.FindAsync(taskId);

            if (task == null)
                throw new KeyNotFoundException("Task not found");

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
        }


    }
}