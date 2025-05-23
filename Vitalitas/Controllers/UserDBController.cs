using Microsoft.AspNetCore.Mvc;
using Vitalitas.Models;
using System.Collections.Generic;
using System.Linq;

[ApiController]
[Route("vitalitas/user")]
public class UserController : ControllerBase
{
    private readonly Contexto _context;

    public UserController(Contexto context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<USUARIO>> Get()
    {
        return _context.Usuarios.ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<USUARIO> Get(int id)
    {
        var user = _context.Usuarios.Find(id);
        if (user == null)
            return NotFound();

        return user;
    }

    [HttpPost("login")]
    public ActionResult<bool> Login([FromBody] Login login)
    {
        var usuarip = _context.Usuarios.FirstOrDefault(u  => u.Usuario == login.Usuario && u.Senha == login.Password);

        if (usuarip != null)
        {
            return true;
        } 
        else
        {
            return false;
        }
    }

    [HttpPost]
    public ActionResult<USUARIO> Post(USUARIO user)
    {
        _context.Usuarios.Add(user);
        _context.SaveChanges();

        return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
    }

    [HttpPost("aluno")]
    public ActionResult<ALUNO> PostAluno([FromBody] ALUNO aluno)
    {
        _context.Alunos.Add(aluno);
        _context.SaveChanges();

        return CreatedAtAction(nameof(Get), new { id = aluno.Id_Usuario }, aluno);
    }

    [HttpPost("professor")]
    public ActionResult<PROFESSOR> PostProfessor([FromBody] PROFESSOR professor)
    {
        _context.Professores.Add(professor);
        _context.SaveChanges();

        return CreatedAtAction(nameof(Get), new {id = professor.Id_Usuario}, professor);
    }

    [HttpPost("administrador")]
    public ActionResult<ADMINISTRADOR> PostAdministrador([FromBody] ADMINISTRADOR administrador)
    {
        _context.Administradores.Add(administrador);
        _context.SaveChanges();

        return CreatedAtAction(nameof(Get), new { id = administrador.Id_Usuario }, administrador);
    }

    [HttpPut("{id}")]
    public IActionResult Put(string id, USUARIO user)
    {
        if (id != user.Id)
            return BadRequest();

        _context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var user = _context.Usuarios.Find(id);
        if (user == null)
            return NotFound();

        _context.Usuarios.Remove(user);
        _context.SaveChanges();
        return NoContent();
    }
}
