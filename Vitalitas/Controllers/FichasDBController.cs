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

    [HttpPost("ficha")]
    public ActionResult<FICHA_DE_TREINO> Post([FromBody] FICHA_DE_TREINO fichaDeTreino)
    {
        _context.FichasDeTreinos.Add(fichaDeTreino);
        _context.SaveChanges();

        return CreatedAtAction(nameof(Post), new { id = fichaDeTreino.Id_Aluno }, fichaDeTreino);
    }
}
