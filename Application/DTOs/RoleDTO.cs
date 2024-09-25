using System.ComponentModel.DataAnnotations;

namespace ApiRestTask.Application.DTOs
{
    public class RoleDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del rol es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre del rol no puede superar los 100 caracteres.")]
        public string Name { get; set; }
    }
}
