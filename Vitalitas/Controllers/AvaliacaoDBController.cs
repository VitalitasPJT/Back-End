using Microsoft.AspNetCore.Mvc;
using Vitalitas.Calculations;
using Vitalitas.Models;
using Vitalitas.Utils;

namespace Vitalitas.Controllers
{
    [ApiController]
    [Route("vitalitas/avaliacao")]
    public class AvaliacaoController : ControllerBase
    {
        private readonly Contexto _context;
        private readonly Calculos _calculos;

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

        [HttpPost("calcular")]
        public ActionResult<Responser<dynamic>> PostCalcular([FromQuery] string id_avaliacao)
        {
            var avaliacao = (from a in _context.Avaliacoes
                             where a.Id_Avaliacao == id_avaliacao
                             select new
                             {
                                 a.Peso,
                                 a.Altura,
                                 a.Idade
                             }).FirstOrDefault();

            var perimetro = (from u in _context.Perimetros
                             where u.Id_Avaliacao == id_avaliacao
                             select new
                             {
                                 u.Perna_E,
                                 u.Perna_D,
                                 u.Coxa_E,
                                 u.Coxa_D,
                                 u.Braco_D,
                                 u.Braco_E,
                                 u.Quadril,
                                 u.Abdomen,
                                 u.Deltoide,
                                 u.Cintura,
                                 u.Torax
                             }).FirstOrDefault();

            var cutanea = (from j in _context.Cutaneass
                           where j.Id_Avaliacao == id_avaliacao
                           select new
                           {
                               j.Tr,
                               j.Cx,
                               j.Si,
                               j.Ab,
                               j.Ax,
                               j.Pt,
                               j.Se,
                               j.Paturrilha,
                               j.Umero,
                               j.Femur
                           }).FirstOrDefault();

            float imc = _calculos.IMC(avaliacao.Altura, avaliacao.Peso);


            return Ok(id_avaliacao);
        }
    }
}
