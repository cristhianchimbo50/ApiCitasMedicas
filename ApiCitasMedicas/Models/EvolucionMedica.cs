namespace ApiCitasMedicas.Models
{
    public class EvolucionMedica
    {
        public int Id { get; set; }

        public int CitaId { get; set; }
        public Cita? Cita { get; set; }

        public string Diagnostico { get; set; } = string.Empty;
        public string Observaciones { get; set; } = string.Empty;
        public string Tratamiento { get; set; } = string.Empty;
        public DateTime Fecha { get; set; } = DateTime.Now;

        public int MedicoId { get; set; }
    }
}

