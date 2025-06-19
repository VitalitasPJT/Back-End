using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Vitalitas.Calculations;
using Vitalitas.Models;

namespace Vitalitas.Controllers
{
    [ApiController]
    [Route("vitalitas/avaliacao")]
    public class AvaliacaoController : ControllerBase
    {
        private readonly Contexto _context;
        private readonly CalculosFeminino _calculosFeminino;
        private readonly CalculosMasculino _calculosMasculino;

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
        public ActionResult<Responser<dynamic>> PostCalcular([FromBody] BodyCalculo body)
        {
            var avaliacao = (from a in _context.Avaliacoes
                             where a.Id_Avaliacao == body.Id_Avaliacao
                             select new
                             {
                                 a.Peso,
                                 a.Altura,
                                 a.Idade
                             }).FirstOrDefault();

            var perimetro = (from u in _context.Perimetros
                             where u.Id_Avaliacao == body.Id_Avaliacao
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
                           where j.Id_Avaliacao == body.Id_Avaliacao
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


           switch (body.Sexo)
            {
                case "M":
                    string id = body.Id_Avaliacao;
                    CalculosMasculino calculo = new CalculosMasculino(
                        avaliacao.Altura,
                        avaliacao.Peso,
                        cutanea.Tr,
                        cutanea.Cx,
                        cutanea.Si,
                        cutanea.Ab,
                        cutanea.Ax,
                        cutanea.Pt,
                        cutanea.Se,
                        avaliacao.Idade
                        );
                    Resultado result = new Resultado(
                        id, 
                        calculo.Imc, 
                        calculo.Soma_Das_Dobras, 
                        calculo.Densidade_Corporal, 
                        calculo.Percentual_De_Gordura, 
                        calculo.Massa_Gorda, 
                        calculo.Percentual_De_Massa_Magra,
                        calculo.Massa_Magra
                        );
                    _context.Resultado.Add(result);
                    break;
                case "F":
                    break;
            }
            return Ok(new Responser<dynamic>("", true, null));
        }
    }
}
