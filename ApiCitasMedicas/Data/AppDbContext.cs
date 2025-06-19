using Microsoft.EntityFrameworkCore;
using ApiCitasMedicas.Models;

namespace ApiCitasMedicas.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Constructor sin parámetros requerido por las herramientas de migración
        public AppDbContext() { }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Cita> Citas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<EvolucionMedica> Evoluciones { get; set; }

    }
}
