using System.ComponentModel.DataAnnotations;

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

        [Required]
        public int AssignedId { get; set; }

        [Required]
        public int CreatedById { get; set; }
    }

    public class TaskResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public int AssignedId { get; set; }
        public int CreatedById { get; set; }
    }
}
