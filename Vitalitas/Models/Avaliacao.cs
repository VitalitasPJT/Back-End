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

    [Table("RESULTADO")]
    public class Resultado
    {
        [Key]
        [Required]
        public string Id_Avaliacao { get; set; }

        [Required]
        [Column(TypeName = "real")]
        public float Imc { get; set; }

        [Required]
        [Column(TypeName = "real")]
        public float Soma_Das_Dobras { get; set; }

        [Required]
        [Column(TypeName = "real")]
        public float Densidade_Corporal { get; set; }

        [Required]
        [Column(TypeName = "real")]
        public float Percentual_De_Gordura { get; set; }

        [Required]
        [Column(TypeName = "real")]
        public float Massa_Gorda { get; set; }

        [Required]
        [Column(TypeName = "real")]
        public float Percentual_De_Massa_Magra { get; set; }

        [Required]
        [Column(TypeName = "real")]
        public float Massa_Magra { get; set; }

        public Resultado() { }

        public Resultado(string id, float imc, float somadobras, float densidade, float pgordura, float massagorda, float pmagra, float massamagra)
        {
            Id_Avaliacao = id;
            Imc = imc;
            Soma_Das_Dobras = somadobras;
            Densidade_Corporal = densidade;
            Percentual_De_Gordura = pgordura;
            Massa_Gorda = massagorda;
            Percentual_De_Massa_Magra = pmagra;
            Massa_Magra = massamagra;
        }
    }

    public class BodyCalculo
    {
        public string Sexo { get; set; }
        public string Id_Avaliacao { get; set; }
    }
}
