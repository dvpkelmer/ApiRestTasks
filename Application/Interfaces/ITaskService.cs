using ApiRestTask.Application.DTOs;

namespace ApiRestTask.Application.Interfaces
{
    public interface ITaskService
    {
        Task<TaskResponseDto> CreateTaskAsync(TaskDto taskDto);
        Task<IEnumerable<TaskResponseDto>> GetAllTasksAsync();
        Task<TaskResponseDto?> GetTaskByIdAsync(int taskId);
        Task UpdateTaskAsync(int taskId, TaskDto taskDto);
        Task DeleteTaskAsync(int taskId);
    }
}
