using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Vitalitas.Models;

[ApiController]
[Route("vitalitas/agenda")]
public class AgendaController : ControllerBase
{
    private readonly Contexto _context;
    public AgendaController(Contexto context)
    {
        _context = context;
    }

    [HttpPost]
    public ActionResult<Agenda> PostAgenda([FromBody] Agenda agenda)
    {
        _context.Agendas.Add(agenda);
        _context.SaveChanges();

        return Ok(new {mesaage= "Agendado com sucesso", success = true});
    }

    [HttpGet]
    public async Task<ActionResult<List<Agenda>>> getAgenda([FromQuery] string idProf)
    {
        var agendas = await (
            from u in _context.Agendas
            where u.Id_Professor == idProf
            select new Agenda
            {
                Id_Agenda = u.Id_Agenda,
                Id_Aluno = u.Id_Aluno, 
                Id_Professor = u.Id_Professor,
                Status = u.Status,
                Hora = u.Hora,
                Data = u.Data
            }
            ).ToListAsync();
        return Ok(agendas);
    }

}
