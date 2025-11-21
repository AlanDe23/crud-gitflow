using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTrust.Domain.Entities
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string  Email { get; set; } = string.Empty;


        public string PasswordHash { get; set; } = string.Empty;


        public DateTime FechaRegistro { get; set; } = DateTime.Now;


        public DateTime? UltimoAcceso { get; set; }


        public  bool Activo { get; set; } = true;



        public ICollection<Analisis> Analisis { get; set; } = new List<Analisis>();
    }


}