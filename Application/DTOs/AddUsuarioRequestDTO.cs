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
        public string Contrase�a { get; set; }

        [Required]
        [Compare("Contrase�a", ErrorMessage = "Las contrase�as no coinciden")]
        public string ConfirmarContrase�a { get; set; }

        [Required]
        public SexoEnum Sexo { get; set; }
    }
}