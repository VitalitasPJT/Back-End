using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Vitalitas.Models;

[ApiController]
[Route("vitalitas/user")]
public class UserController : ControllerBase
{
    private readonly Contexto _context;

    public UserController(Contexto context)
    {
        _context = context;
    }

    [HttpGet("test")]
    public IActionResult Test()
    {
        return Ok(new { message = "Hello World", success = true });
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
    public ActionResult<LoginResponse> Login([FromBody] Login login)
    {
        var usuario = _context.Usuarios
            .Where(u => u.Usuario == login.Usuario && u.Senha == login.Password)
            .Select(u => new { u.Tipo, u.Id})
            .FirstOrDefault();

        if (usuario != null)
        {
            var response = new LoginResponse
            {
                Sucesso = "true",
                Tipo = usuario.Tipo,
                Mensagem = "Login efetuado",
                Id = usuario.Id
            };

            return Ok(response);
        }
        else
        {
            return Unauthorized(new LoginResponse
            {
                Sucesso = "false",
                Tipo = null,
                Mensagem = "Usuário ou senha inválidos",
                Id = null,
            });
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

    [HttpGet("professores")]
    public async Task<ActionResult<List<Professor>>> getProfessores()
    {
        var professores = await (
            from u in _context.Usuarios
            select new Professor
            {
                Nome = u.Nome,
                Usuario = u.Usuario,
                Id = u.Id,
            }
            ).ToListAsync();

        return Ok(professores);
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
