using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoApi.Models;

namespace ProyectoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NoticiaController : ControllerBase
    {
        private readonly AppDbContext _context;
        public NoticiaController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Noticia>>> GetNoticias()
        {
            return await _context.Noticias.ToListAsync();
        }

        [HttpGet("{idusuario}")]
        public async Task<ActionResult<IEnumerable<Noticia>>> GetNoticiasPorUsuario(int idusuario)
        {
            var noticias = await _context.Noticias
                                         .Where(n => n.UsuarioId == idusuario)
                                         .ToListAsync();

            if (noticias == null || noticias.Count == 0)
            {
                return NotFound($"No se encontraron noticias para el usuario con ID {idusuario}.");
            }

            return noticias;
        }
        [HttpPost]
        public async Task<ActionResult<Noticia>> CrearNoticia(Noticia noticia)
        {
            noticia.Fecha = noticia.Fecha.Date;

            _context.Noticias.Add(noticia);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetNoticias), new { id = noticia.Id }, noticia);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarNoticia(int id, Noticia noticia)
        {
            if (id != noticia.Id)
            {
                return BadRequest("El ID proporcionado no coincide con el ID de la noticia.");
            }
            noticia.Fecha = noticia.Fecha.Date;

            _context.Entry(noticia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NoticiaExiste(id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarNoticia(int id)
        {
            var noticia = await _context.Noticias.FindAsync(id);
            if (noticia == null)
            {
                return NotFound();
            }

            _context.Noticias.Remove(noticia);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NoticiaExiste(int id)
        {
            return _context.Noticias.Any(e => e.Id == id);
        }
    }
}

