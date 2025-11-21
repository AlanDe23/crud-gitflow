using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WebTrut.Application.DTOs
{
    public class AnalisisResultadoDto
    {
        public string Url { get; set; } = string.Empty;
        public string Titulo { get; set; } = string.Empty;
        public double PorcentajeConfianza { get; set; }
        public string Detalles { get; set; } = string.Empty;
    }
}
