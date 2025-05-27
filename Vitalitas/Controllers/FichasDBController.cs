using Microsoft.AspNetCore.Mvc;
using Vitalitas.Models;
using System.Collections.Generic;
using System.Linq;

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
}
