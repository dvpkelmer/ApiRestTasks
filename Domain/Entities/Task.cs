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

        [ForeignKey("AssignedUser")]
        public int? AssignedId { get; set; }
        public User? AssignedUser { get; set; }  // Usuario asignado

        [ForeignKey("CreatedByUser")]
        public int CreatedById { get; set; }
        public User? CreatedByUser { get; set; }  // Usuario que creó la tarea
    }
}
