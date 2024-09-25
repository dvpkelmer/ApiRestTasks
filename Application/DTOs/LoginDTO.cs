using System.ComponentModel.DataAnnotations;

namespace ApiRestTask.Application.DTOs
{
    public class LoginDto
    {
        [Required(ErrorMessage = "El email de usuario es requerido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida.")]
        public string Password { get; set; }
    }
}
