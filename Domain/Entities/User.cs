using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiRestTask.Domain.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public required string UserName { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }

        [ForeignKey("RoleId")]
        public int RoleId { get; set; }

        public Role? Role { get; set; }
        
    }
}
