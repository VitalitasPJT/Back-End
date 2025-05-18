using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("TABELA_TESTE")]
public class TabelaTeste
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Required]
    [Column("Descrição")]
    [StringLength(50)]
    public string Descricao { get; set; }

    [Required]
    [Column("Login")]
    [StringLength(8)]
    public string Login { get; set; }
}
