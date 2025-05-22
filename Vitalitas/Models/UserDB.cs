using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vitalitas.Models
{
    [Table("USUARIO")]
    public class USUARIO
    {
        [Key]
        [Column("ID")]
        public required string Id { get; set; }

        [Required]
        public required string Nome { get; set; }

        [Required]
        public required string Usuario { get; set; }

        [Required]
        public required string Email { get; set; }

        [Required]
        public required string Senha { get; set; }

        [Required]
        public required string Telefone { get; set; }

        [Required]
        public required string Tipo { get; set; }
        
    }

    public class Login
    {
        public string Usuario { get; set; }
        public string Password { get; set; }
    }
}
