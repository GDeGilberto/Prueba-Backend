using System.ComponentModel.DataAnnotations;
using Domain.Enum;

namespace Application.DTOs
{
    public class UpdateUsuarioDTO
    {
        [EmailAddress]
        public string? Email { get; set; }

        [MinLength(7)]
        public string? NombreUsuario { get; set; }

        [MinLength(10)]
        public string? Contrase�a { get; set; }

        [MinLength(10)]
        [Compare("Contrase�a", ErrorMessage = "Las contrase�as no coinciden")]
        public string? ConfirmarContrase�a { get; set; }

        public SexoEnum? Sexo { get; set; }
    }
}