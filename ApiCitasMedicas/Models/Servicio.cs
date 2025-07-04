﻿namespace ApiCitasMedicas.Models
{
    public class Servicio
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public decimal Precio { get; set; }

        public ICollection<Cita>? Citas { get; set; }
    }
}
