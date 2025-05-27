using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vitalitas.Models
{
    [Table("FICHA_DE_TREINO")]
    public class FICHA_DE_TREINO
    {
        [Key]
        [Required]
        public string Id_Ficha { get; set; }

        [Required]
        public string Id_Aluno { get; set; }

        [Required]
        public string Responsavel { get; set; }

        [Required]
        public DateTime Data_Criacao { get; set; }

        [Required]
        public DateTime Data_Validade { get; set; }
        [Required]
        public string Nome { get; set; }

        public string Observacoes { get; set; }
    }

    [Table("TREINO")]
    public class TREINO
    {

        [Required]
        public string Id_Ficha_Treino { get; set; }

        [Required]
        [Key]
        public string Id_Treino { get; set; }

        [Required]
        public string Nome { get; set; }
    }

    [Table("TREINO_EXERCICIO")]
    public class TREINO_EXERCICIO
    {
        [Key]
        [Required]
        public string Id_Treino { get; set; }

        [Required]
        [Key]
        public string Id_Exercicio { get; set; }
        public string Series { get; set; }
        public int Repeticoes { get; set; }
        public string Aparelho { get; set; }
        
        [Required]
        public string Nome { get; set; }
        
        [Required]
        public string Musculo { get; set; }
    }
}
