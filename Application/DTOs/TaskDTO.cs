using System.ComponentModel.DataAnnotations;
using ApiRestTask.Domain.Entities;

namespace ApiRestTask.Application.DTOs
{
    public class TaskDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string Status { get; set; } = string.Empty;

        public int? AssignedId { get; set; }

    }

    public class TaskGroupedResponseDto
    {
        public string Status { get; set; }
        public List<TaskResponseDto> Tasks { get; set; }
    }

    public class TaskResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int? AssignedId { get; set; }
        public int CreatedById { get; set; }
        public string? AssignedUserName { get; set; }  // Cambiar a string para el nombre del usuario asignado
    }

}
