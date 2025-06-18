using Microsoft.AspNetCore.Mvc;
using Vitalitas.Models;

namespace Vitalitas.Controllers
{
    [ApiController]
    [Route("vitalitas/avaliacao")]
    public class AvaliacaoController : ControllerBase
    {
        private readonly Contexto _context;

        public AvaliacaoController(Contexto context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult<Responser<Avaliacao>> PostAvaliacao([FromBody] Avaliacao avaliacao)
        {
            _context.Avaliacoes.Add(avaliacao);
            _context.SaveChanges();

            return Ok(new Responser<Avaliacao>("Avaliação inserida com sucesso", true, avaliacao));
        }

        [HttpPost("perimetro")]
        public ActionResult<Responser<Perimetro>> PostPerimetro([FromBody] Perimetro perimetro)
        {
            _context.Perimetros.Add(perimetro);
            _context.SaveChanges();

            return Ok(new Responser<Perimetro>("Perimetro inserido com sucesso", true, perimetro));
        }

        [HttpPost("cutaneas")]
        public ActionResult<Responser<Cutaneas>> PostCutaneas([FromBody] Cutaneas cutaneas)
        {
            _context.Cutaneass.Add(cutaneas);
            _context.SaveChanges();

            return Ok(new Responser<Cutaneas>("Perimetro inserido com sucesso", true, cutaneas));
        }
    }
}
