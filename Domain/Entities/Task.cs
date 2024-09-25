using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiRestTask.Domain.Entities
{
    public class Tasks
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string Status { get; set; }

        [ForeignKey("UserId")]
        public int AssignedId { get; set; }
        [ForeignKey("UserId")]
        public int CreatedById { get; set; }
    }
}
