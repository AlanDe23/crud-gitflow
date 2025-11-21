using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTrust.Domain.Entities;

namespace WebTrut.Application.Interfaces
{
    public interface IAnalisisRepository : IRepositorioGenerico<Analisis>
    {
        Task<IEnumerable<Analisis>> GetByUsuarioIdAsync(int idUsuario);
    }
}
