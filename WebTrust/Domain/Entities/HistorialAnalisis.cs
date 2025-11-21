using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTrust.Domain.Entities
{
    public class HistorialAnalisis
    {
        [Key]
        public int IdHistorial { get; set; }
        public int IdAnalisis { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
        public decimal ResultadoAnterior { get; set; }
        public decimal ResultadoNuevo { get; set; }
        public string? Observacion { get; set; }

        // Relación
        public Analisis? Analisis { get; set; }

    }
}
