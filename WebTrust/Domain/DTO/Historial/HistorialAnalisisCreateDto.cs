using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTrust.Domain.DTO.Historial
{
public class HistorialAnalisisCreateDto
    {

        public int IdAnalisis { get; set; }
        public decimal ResultadoAnterior { get; set; }
        public decimal ResultadoNuevo { get; set; }
        public string? Observacion { get; set; }

    }
}
