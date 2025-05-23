using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using Vitalitas.Models;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }

    public DbSet<USUARIO> Usuarios { get; set; }
    public DbSet<ALUNO> Alunos { get; set; }
    public DbSet<PROFESSOR> Professores { get; set; }
    public DbSet<ADMINISTRADOR> Administradores { get; set; }
    public DbSet<FICHA_DE_TREINO> FichasDeTreinos { get; set; }
    public DbSet<TREINO> Treinos { get; set; }
    public DbSet<EXERCICIO> Exercicio { get; set; }
}
