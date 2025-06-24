using Domain.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; }

        [Required]
        [EmailAddress]
        public string Email { get; }

        [MinLength(7)]
        public string NombreUsuario { get; }

        [Required]
        public string Contraseña { get; }

        [Required]
        public EstatusEnum Estatus { get; }

        [Required]
        public SexoEnum Sexo { get; }

        public DateTime FechaDeCreacion { get; }

        public Usuario(string email, string nombreUsuario, string contraseña, EstatusEnum estatus, SexoEnum sexo)
        {
            Email = email;
            NombreUsuario = nombreUsuario;
            Contraseña = contraseña;
            Estatus = estatus;
            Sexo = sexo;
            FechaDeCreacion = DateTime.Now;
        }
    }
}

