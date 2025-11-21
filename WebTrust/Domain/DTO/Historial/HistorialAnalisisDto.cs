using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTrust.Domain.DTO.Historial
{
   public  class HistorialAnalisisDto
    {

        public int IdHistorial { get; set; }
        public int IdAnalisis { get; set; }
        public DateTime FechaRegistro { get; set; }
        public decimal ResultadoAnterior { get; set; }
        public decimal ResultadoNuevo { get; set; }
        public string? Observacion { get; set; }
    } 
}
