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

        public TaskService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TaskResponseDto> CreateTaskAsync(TaskDto taskDto)
        {
            var task = new Tasks
            {
                Name = taskDto.Name,
                Description = taskDto.Description,
                Status = taskDto.Status,
                AssignedId = taskDto.AssignedId,
                CreatedById = taskDto.CreatedById
            };

            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();

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

        public async Task<IEnumerable<TaskResponseDto>> GetAllTasksAsync()
        {
            return await _context.Tasks.Select(t => new TaskResponseDto
            {
                Id = t.Id,
                Name = t.Name,
                Description = t.Description,
                Status = t.Status,
                AssignedId = t.AssignedId,
                CreatedById = t.CreatedById
            }).ToListAsync();
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

        public async Task UpdateTaskAsync(int taskId, TaskDto taskDto)
        {
            var task = await _context.Tasks.FindAsync(taskId);

            if (task == null)
                throw new KeyNotFoundException("Task not found");

            task.Name = taskDto.Name;
            task.Description = taskDto.Description;
            task.Status = taskDto.Status;
            task.AssignedId = taskDto.AssignedId;
            task.CreatedById = taskDto.CreatedById;

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
