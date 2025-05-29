using Microsoft.AspNetCore.Mvc;
using Vitalitas.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

[ApiController]
[Route("vitalitas/fichas")]
public class FichaController : ControllerBase
{
    private readonly Contexto _context;

    public FichaController(Contexto context)
    {
        _context = context;
    }

    [HttpPost]
    public ActionResult<FichaDeTreino> PostFicha([FromBody] FichaDeTreino fichaDeTreino)
    {
        _context.FichasDeTreinos.Add(fichaDeTreino);
        _context.SaveChanges();

        return CreatedAtAction(nameof(PostFicha), fichaDeTreino);
    }

    [HttpPost("treino")]
    public ActionResult<Treino> PostTreino([FromBody] Treino treino)
    {
        _context.Treinos.Add(treino);
        _context.SaveChanges();

        return CreatedAtAction(nameof(PostTreino), treino);
    }

    [HttpPost("treino/exercicio")]
    public ActionResult<TreinoExercicio> PostExercicio([FromBody] TreinoExercicio treinoExercicio)
    {
        _context.TreinoExercicios.Add(treinoExercicio);
        _context.SaveChanges();

        return CreatedAtAction(nameof(PostTreino), treinoExercicio);
    }

    [HttpGet]
    public async Task<ActionResult<List<FichaDeTreino>>> GetFicha([FromQuery] string aluno)
    {
        var fichas = await (
            from u in _context.FichasDeTreinos
            where u.Id_Aluno == aluno
            select new FichaDeTreino
            {
                Id_Ficha = u.Id_Ficha,
                Id_Aluno = u.Id_Aluno,
                Responsavel = u.Responsavel,
                Data_Criacao = u.Data_Criacao,
                Data_Validade = u.Data_Validade,
                Nome = u.Nome,
                Observacoes = u.Observacoes

            }).ToListAsync();

        return Ok(fichas);
    }

    [HttpGet("treino")]
    public async Task<ActionResult<List<Treino>>> GetTreino([FromQuery] string idFicha)
    {
        var treino = await (
            from u in _context.Treinos
            where u.Id_Ficha_Treino == idFicha
            select new Treino
            {
                Id_Ficha_Treino = u.Id_Ficha_Treino, 
                Id_Treino = u.Id_Treino,
                Nome = u.Nome
            }).ToListAsync();

        return Ok(treino);
    }

    [HttpGet("treino/exercicio")]
    public async Task<ActionResult<List<TreinoExercicio>>> GetExercicio([FromQuery] string idTreino)
    {
        var exercicio = await (
            from u in _context.TreinoExercicios
            where u.Id_Treino == idTreino
            select new TreinoExercicio
            {
                Id_Treino = u.Id_Treino,
                Id_Exercicio = u.Id_Exercicio,
                Series = u.Series,
                Repeticoes = u.Repeticoes,
                Aparelho = u.Aparelho,
                Nome = u.Nome,
                Musculo = u.Musculo

            }).ToListAsync();

        return Ok(exercicio);
    }
}
