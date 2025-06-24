using Domain.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [MinLength(7)]
        public string NombreUsuario { get; set; }

        [Required]
        public string Contraseña { get; set; }

        public bool Estatus { get; set; }

        [Required]
        public SexoEnum Sexo { get; set; }

        public DateTime FechaDeCreacion { get; set; }
    }
}

