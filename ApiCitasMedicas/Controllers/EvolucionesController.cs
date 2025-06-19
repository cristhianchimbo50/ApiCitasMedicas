using ApiCitasMedicas.Data;
using ApiCitasMedicas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiCitasMedicas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EvolucionesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EvolucionesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("cita/{citaId}")]
        public async Task<ActionResult<IEnumerable<EvolucionMedica>>> GetPorCita(int citaId)
        {
            var evoluciones = await _context.Evoluciones
                .Where(e => e.CitaId == citaId)
                .ToListAsync();

            return Ok(evoluciones);
        }

        [HttpPost]
        public async Task<ActionResult<EvolucionMedica>> CrearEvolucion([FromBody] EvolucionMedica evolucion)
        {
            _context.Evoluciones.Add(evolucion);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPorCita), new { citaId = evolucion.CitaId }, evolucion);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EvolucionMedica>> GetById(int id)
        {
            var evolucion = await _context.Evoluciones.FindAsync(id);
            return evolucion == null ? NotFound() : Ok(evolucion);
        }
    }
}
