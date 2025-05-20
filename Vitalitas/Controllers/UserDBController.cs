using Microsoft.AspNetCore.Mvc;
using Vitalitas.Models;
using System.Collections.Generic;
using System.Linq;

[ApiController]
[Route("vitalitas/[controller]")]
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

    [HttpPost]
    public ActionResult<USUARIO> Post(USUARIO user)
    {
        _context.Usuarios.Add(user);
        _context.SaveChanges();

        return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
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
