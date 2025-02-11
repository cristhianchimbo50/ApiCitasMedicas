﻿using ApiCitasMedicas.Data;
using ApiCitasMedicas.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCitasMedicas.Facades
{
    public class CitasFacade
    {
        private readonly AppDbContext _context;

        public CitasFacade(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Paciente>> ObtenerPacientes()
        {
            return await _context.Pacientes.ToListAsync();
        }

        public async Task<Paciente?> ObtenerPacientePorId(int id)
        {
            return await _context.Pacientes.FindAsync(id);
        }

        public async Task<Paciente> AgregarPaciente(Paciente paciente)
        {
            _context.Pacientes.Add(paciente);
            await _context.SaveChangesAsync();
            return paciente;
        }

        public async Task<bool> ActualizarPaciente(int id, Paciente paciente)
        {
            if (id != paciente.Id) return false;

            _context.Entry(paciente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EliminarPaciente(int id)
        {
            var paciente = await _context.Pacientes.FindAsync(id);
            if (paciente == null) return false;

            _context.Pacientes.Remove(paciente);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Medico>> ObtenerMedicos()
        {
            return await _context.Medicos.ToListAsync();
        }

        public async Task<Medico?> ObtenerMedicoPorId(int id)
        {
            return await _context.Medicos.FindAsync(id);
        }

        public async Task<Medico> AgregarMedico(Medico medico)
        {
            _context.Medicos.Add(medico);
            await _context.SaveChangesAsync();
            return medico;
        }

        public async Task<bool> ActualizarMedico(int id, Medico medico)
        {
            if (id != medico.Id) return false;

            _context.Entry(medico).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EliminarMedico(int id)
        {
            var medico = await _context.Medicos.FindAsync(id);
            if (medico == null) return false;

            _context.Medicos.Remove(medico);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Cita>> ObtenerCitas()
        {
            return await _context.Citas.ToListAsync();
        }

        public async Task<Cita?> ObtenerCitaPorId(int id)
        {
            return await _context.Citas.FindAsync(id);
        }

        public async Task<Cita> AgregarCita(Cita cita)
        {
            _context.Citas.Add(cita);
            await _context.SaveChangesAsync();
            return cita;
        }

        public async Task<bool> ActualizarCita(int id, Cita cita)
        {
            if (id != cita.Id) return false;

            _context.Entry(cita).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EliminarCita(int id)
        {
            var cita = await _context.Citas.FindAsync(id);
            if (cita == null) return false;

            _context.Citas.Remove(cita);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
