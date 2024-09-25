using System.ComponentModel.DataAnnotations;
using ApiRestTask.Domain.Entities;

namespace ApiRestTask.Application.DTOs
{
    public class UserDto
    {       
        public int Id { get; set; }

        [Required]
        [StringLength(100)] 
        public string UserName { get; set; }

        [Required]
        [StringLength(100)] 
        public string Password { get; set; }

        [Required]
        [StringLength(255)] 
        public string Email { get; set; }

        [Required]
        public int RoleId { get; set; } 

        public Role? Role { get; set; } 
    }
}
