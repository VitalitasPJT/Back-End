using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class TabelaTesteController : ControllerBase
{
    private readonly MeuContexto _context;

    public TabelaTesteController(MeuContexto context)
    {
        _context = context;
    }

    // Endpoint para inserir dados
    [HttpPost]
    public async Task<ActionResult<TabelaTeste>> PostTabelaTeste(TabelaTeste tabelaTeste)
    {
        _context.TabelaTestes.Add(tabelaTeste);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetTabelaTeste), new { id = tabelaTeste.Id }, tabelaTeste);
    }

    // Endpoint para recuperar todos os dados
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TabelaTeste>>> GetTabelaTestes()
    {
        return await _context.TabelaTestes.ToListAsync();
    }

    // Endpoint para recuperar um item por ID
    [HttpGet("{id}")]
    public async Task<ActionResult<TabelaTeste>> GetTabelaTeste(int id)
    {
        var tabelaTeste = await _context.TabelaTestes.FindAsync(id);
        if (tabelaTeste == null)
        {
            return NotFound();
        }
        return tabelaTeste;
    }
}
