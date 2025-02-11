using Microsoft.AspNetCore.Mvc;
using ApiCitasMedicas.Facades;
using ApiCitasMedicas.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiCitasMedicas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitasController : ControllerBase
    {
        private readonly CitasFacade _citasFacade;

        public CitasController(CitasFacade citasFacade)
        {
            _citasFacade = citasFacade;
        }

        // Obtener todas las citas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cita>>> GetCitas()
        {
            try
            {
                var citas = await _citasFacade.ObtenerCitas();
                return Ok(citas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error obteniendo citas: {ex.Message}");
            }
        }

        // Crear una cita
        [HttpPost]
        public async Task<ActionResult<Cita>> CreateCita([FromBody] Cita cita)
        {
            if (cita == null) return BadRequest("La cita no puede ser nula");

            try
            {
                var nuevaCita = await _citasFacade.AgregarCita(cita);
                return CreatedAtAction(nameof(GetCitas), new { id = nuevaCita.Id }, nuevaCita);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al agregar cita: {ex.Message}");
            }
        }

        // Actualizar una cita
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCita(int id, [FromBody] Cita cita)
        {
            if (id != cita.Id) return BadRequest("El ID de la cita no coincide con el parámetro de la URL");

            try
            {
                var resultado = await _citasFacade.ActualizarCita(id, cita);
                if (!resultado) return NotFound("Cita no encontrada");

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar cita: {ex.Message}");
            }
        }

        // Eliminar una cita
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCita(int id)
        {
            try
            {
                var resultado = await _citasFacade.EliminarCita(id);
                if (!resultado) return NotFound("Cita no encontrada");

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al eliminar cita: {ex.Message}");
            }
        }
    }
}
