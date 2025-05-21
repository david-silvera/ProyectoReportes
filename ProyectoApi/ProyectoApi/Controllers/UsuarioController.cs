using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoApi.Models;

namespace ProyectoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly AppDbContext _context;
        public UsuarioController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null) return NotFound();
            return usuario;
        }


        [HttpPost]
        public async Task<ActionResult<Usuario>> CrearUsuario(Usuario usuario)
        {
            var existe = await _context.Usuarios.AnyAsync(u => u.Username == usuario.Username);
            if (existe)
            {
                return BadRequest("El nombre de usuario ya existe.");
            }

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUsuarios), new { id = usuario.Id }, new
            {
                usuario.Id,
                usuario.Nombre,
                usuario.Apellido,
                usuario.Username
            });
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarUsuario(int id, Usuario usuarioActualizado)
        {
            if (id != usuarioActualizado.Id)
            {
                return BadRequest("El ID del usuario no coincide.");
            }

            var usuarioExistente = await _context.Usuarios.FindAsync(id);
            if (usuarioExistente == null)
            {
                return NotFound("Usuario no encontrado.");
            }

            var usernameEnUso = await _context.Usuarios
                .AnyAsync(u => u.Username == usuarioActualizado.Username && u.Id != id);

            if (usernameEnUso)
            {
                return BadRequest("El nombre de usuario ya está en uso.");
            }

            usuarioExistente.Nombre = usuarioActualizado.Nombre;
            usuarioExistente.Apellido = usuarioActualizado.Apellido;
            usuarioExistente.Username = usuarioActualizado.Username;
            usuarioExistente.Contraseña = usuarioActualizado.Contraseña;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.Id == id);
        }

    }
}
