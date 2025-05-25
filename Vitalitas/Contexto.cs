using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using Vitalitas.Models;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }

    public DbSet<UsuarioC> Usuarios { get; set; }
    public DbSet<Aluno> Alunos { get; set; }
    public DbSet<Professor> Professores { get; set; }
    public DbSet<Administrador> Administradores { get; set; }
    public DbSet<FICHA_DE_TREINO> FichasDeTreinos { get; set; }
    public DbSet<TREINO> Treinos { get; set; }
}
