using Microsoft.AspNetCore.Mvc;
using ApiCitasMedicas.Facades;
using ApiCitasMedicas.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiCitasMedicas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicosController : ControllerBase
    {
        private readonly CitasFacade _citasFacade;

        public MedicosController(CitasFacade citasFacade)
        {
            _citasFacade = citasFacade;
        }

        // Obtener todos los médicos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Medico>>> GetMedicos()
        {
            try
            {
                var medicos = await _citasFacade.ObtenerMedicos();
                return Ok(medicos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error obteniendo médicos: {ex.Message}");
            }
        }

        // Crear un médico
        [HttpPost]
        public async Task<ActionResult<Medico>> CreateMedico([FromBody] Medico medico)
        {
            if (medico == null) return BadRequest("El médico no puede ser nulo");

            try
            {
                var nuevoMedico = await _citasFacade.AgregarMedico(medico);
                return CreatedAtAction(nameof(GetMedicos), new { id = nuevoMedico.Id }, nuevoMedico);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al agregar médico: {ex.Message}");
            }
        }

        // Actualizar un médico
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMedico(int id, [FromBody] Medico medico)
        {
            if (id != medico.Id) return BadRequest("El ID del médico no coincide con el parámetro de la URL");

            try
            {
                var resultado = await _citasFacade.ActualizarMedico(id, medico);
                if (!resultado) return NotFound("Médico no encontrado");

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar médico: {ex.Message}");
            }
        }

        // Eliminar un médico
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedico(int id)
        {
            try
            {
                var resultado = await _citasFacade.EliminarMedico(id);
                if (!resultado) return NotFound("Médico no encontrado");

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al eliminar médico: {ex.Message}");
            }
        }
    }
}
