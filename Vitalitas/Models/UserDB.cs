using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vitalitas.Models
{
    [Table("USUARIO")]
    public class USUARIO
    {
        [Key]
        [Column("ID", TypeName = "nchar(15)")]
        public required string Id { get; set; }

        [Required]
        [StringLength(30)]
        public required string Name { get; set; }

        [Required]
        [StringLength(15)]
        public required string Usuario { get; set; }

        [Required]
        [StringLength(50)]
        public required string Email { get; set; }

        [Required]
        [StringLength(20)]
        public  required string Password { get; set; }

        [Required]
        [StringLength(1)]
        public required string Tipo { get; set; }
        
    }
}
