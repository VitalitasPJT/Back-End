using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

public class MeuContexto : DbContext
{
    public MeuContexto(DbContextOptions<MeuContexto> options) : base(options) { }

    public DbSet<TabelaTeste> TabelaTestes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TabelaTeste>().ToTable("TABELA_TESTE");
    }
}
