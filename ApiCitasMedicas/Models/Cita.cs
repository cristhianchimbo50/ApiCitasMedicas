namespace ApiCitasMedicas.Models
{
    public class Cita
    {
        public int Id { get; set; }
        public int PacienteId { get; set; }
        public int MedicoId { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; } = "Pendiente"; // Estados: Pendiente, Confirmada, Cancelada
    }
}
