using System.ComponentModel.DataAnnotations;

namespace ApiRestTask.Application.DTOs
{
    public class UpdateTaskDto
    {
        public string? Status { get; set; } = string.Empty;

        public int? AssignedId { get; set; }

    }
}
