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
        public string? Contraseņa { get; set; }

        [MinLength(10)]
        [Compare("Contraseņa", ErrorMessage = "Las contraseņas no coinciden")]
        public string? ConfirmarContraseņa { get; set; }

        public SexoEnum? Sexo { get; set; }
    }
}