using System.ComponentModel.DataAnnotations;
using Domain.Enum;

namespace Application.DTOs
{
    public class AddUsuarioRequestDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(7)]
        public string NombreUsuario { get; set; }

        [Required]
        [MinLength(10)]
        public string Contraseņa { get; set; }

        [Required]
        [Compare("Contraseņa", ErrorMessage = "Las contraseņas no coinciden")]
        public string ConfirmarContraseņa { get; set; }

        [Required]
        public SexoEnum Sexo { get; set; }
    }
}