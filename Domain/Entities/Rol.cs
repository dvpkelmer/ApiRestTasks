using System.ComponentModel.DataAnnotations;

namespace ApiRestTask.Domain.Entities
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
    }
}
