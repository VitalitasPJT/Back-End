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

    public class LoginResponse
    {
        public string Sucesso { get; set; }
        public string Tipo { get; set; }
        public string Mensagem { get; set; }
        public string Id { get; set; }
    }

    public class Professor
    {
        public string Nome { get; set; }
        public string Usuario { get; set; }
        public string Id { get; set; }
    }

    [Table("ALUNO")]
    public class ALUNO
    {
        [Required]
        public string Id_Usuario { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public DateTime Data_Inscricao { get; set; }

        public string Objetivo { get; set; }

        [Key]
        [Required]
        public string Cpf { get; set; }

        [Required]
        public DateTime Data_Nascimento { get; set; }
        
        [Required]
        public string Responsavel { get; set; }
    }

    [Table("PROFESSOR")]
    public class PROFESSOR
    {
        [Required]
        public string Id_Usuario { get; set; }

        [Key]
        [Required]
        public long Cref { get; set; }
  
    }

    [Table("ADMINISTRADOR")]
    public class ADMINISTRADOR
    {
        [Required]
        public string Id_Usuario { get; set; }

        [Required]
        public string Nivel { get; set; }
        
        [Key]
        [Required]
        public long Registro { get; set; }
    }
}
