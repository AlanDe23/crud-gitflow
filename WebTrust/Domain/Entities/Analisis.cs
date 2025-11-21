using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTrust.Domain.Entities;

namespace WebTrust.Domain.Entities
{
  public class Analisis
    {
        [Key]
        public int IdAnalisis { get; set; }
        public int IdUsuario { get; set; }
        public string Url { get; set; } = string.Empty;
        public string? Titulo { get; set; }
        public decimal PorcentajeConfianza { get; set; }
        public DateTime FechaAnalisis { get; set; } = DateTime.Now;
        public string? Detalles { get; set; }

        public Usuario? Usuario { get; set; }
        public ICollection<HistorialAnalisis> Historiales { get; set; } = new List<HistorialAnalisis>();

    }

 
}
