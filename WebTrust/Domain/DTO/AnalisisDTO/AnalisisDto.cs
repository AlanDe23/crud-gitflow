using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTrust.Domain.DTO.UsuarioDTO;

namespace WebTrust.Domain.DTO.AnalisisDTO
{
    public  class AnalisisDto
    {
        public int IdAnalisis { get; set; }
        public string Url { get; set; } = string.Empty;
        public string? Titulo { get; set; }
        public decimal PorcentajeConfianza { get; set; }
        public DateTime FechaAnalisis { get; set; }

        public UsuarioDto? Usuario { get; set; }

        public string? Detalles { get; set; }   

    }
}
