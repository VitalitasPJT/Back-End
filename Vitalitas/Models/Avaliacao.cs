using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vitalitas.Models
{
    [Table("AVALIACAO")]
    public class Avaliacao
    {
        [Key]
        [Required]
        public string Id_Avaliacao { get; set; }

        [Required]
        public string Id_Aluno { get;set; }

        [Required]
        public string Id_Professor { get; set; }

        [Required]
        public DateOnly Data { get; set; }

        [Required]
        public TimeOnly Hora { get; set; }

        [Required]
        public float Peso { get; set; }

        [Required]
        public int Idade { get; set; }

        [Required]
        public float Altura { get; set; }

        [Required]
        public float IMC { get; set; }
    }

    [Table("PERIMETRO_AVALIACAO")]
    public class Perimetro
    {
        [Key]
        [Required]
        public string Id_Avaliacao { get; set; }

        [Required]
        public float Perna_E { get; set; }

        [Required]
        public float Perna_D { get; set; } 

        [Required]
        public float Coxa_E { get; set; }

        [Required]
        public float Coxa_D { get; set; }

        [Required]
        public float Braco_E { get; set; }

        [Required]
        public float Braco_D { get; set; }

        [Required]
        public float Quadril { get; set; }

        [Required]
        public float Abdomen { get; set; }

        [Required]
        public float Deltoide { get; set; }

        [Required]
        public float Cintura { get; set; }

        [Required]
        public float Torax { get; set; }
    }

    [Table("CUTANEAS_AVALIACAO")]
    public class Cutaneas
    {
        [Key]
        [Required]
        public string Id_Avaliacao { get; set; }

        [Required]
        public float Tr { get; set; }

        [Required]
        public float Cx { get; set; }

        [Required]
        public float Si { get; set; }

        [Required]
        public float Ab { get; set; }

        [Required]
        public float Ax { get; set; }

        [Required]
        public float Pt { get; set; }

        [Required]
        public float Se { get; set; }

        [Required]
        public float Paturrilha { get; set; }

        [Required]
        public float Umero { get; set; }

        [Required]
        public float Femur { get; set; }
    }
}
