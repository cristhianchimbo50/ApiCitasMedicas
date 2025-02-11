using Microsoft.AspNetCore.Mvc;
using ApiCitasMedicas.Facades;
using ApiCitasMedicas.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiCitasMedicas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacientesController : ControllerBase
    {
        private readonly CitasFacade _citasFacade;

        public PacientesController(CitasFacade citasFacade)
        {
            _citasFacade = citasFacade;
        }

        // Obtener todos los pacientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Paciente>>> GetPacientes()
        {
            try
            {
                var pacientes = await _citasFacade.ObtenerPacientes();
                return Ok(pacientes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error obteniendo pacientes: {ex.Message}");
            }
        }

        // Crear un paciente
        [HttpPost]
        public async Task<ActionResult<Paciente>> CreatePaciente([FromBody] Paciente paciente)
        {
            if (paciente == null) return BadRequest("El paciente no puede ser nulo");

            try
            {
                var nuevoPaciente = await _citasFacade.AgregarPaciente(paciente);
                return CreatedAtAction(nameof(GetPacientes), new { id = nuevoPaciente.Id }, nuevoPaciente);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al agregar paciente: {ex.Message}");
            }
        }

        // Actualizar un paciente
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePaciente(int id, [FromBody] Paciente paciente)
        {
            if (id != paciente.Id) return BadRequest("El ID del paciente no coincide con el parámetro de la URL");

            try
            {
                var resultado = await _citasFacade.ActualizarPaciente(id, paciente);
                if (!resultado) return NotFound("Paciente no encontrado");

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar paciente: {ex.Message}");
            }
        }

        // Eliminar un paciente
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaciente(int id)
        {
            try
            {
                var resultado = await _citasFacade.EliminarPaciente(id);
                if (!resultado) return NotFound("Paciente no encontrado");

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al eliminar paciente: {ex.Message}");
            }
        }
    }
}
