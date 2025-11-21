using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTrust.Domain.DTO.AnalisisDTO
{
   public  class AnalisisCreateDto
    {
        public int IdUsuario { get; set; }
        public string Url { get; set; } = string.Empty;
        public string? Titulo { get; set; }
        public decimal PorcentajeConfianza { get; set; }

        public string? Detalles { get; set; }

    }
}
