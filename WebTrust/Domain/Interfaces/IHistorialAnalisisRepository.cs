using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTrust.Domain.Entities;

namespace WebTrut.Application.Interfaces
{
    public interface IHistorialAnalisisRepository : IRepositorioGenerico<HistorialAnalisis> 
    {

        Task<IEnumerable<HistorialAnalisis>> GetByAnalisisAsync(int idAnalisis);
    }


}


