using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTrust.Domain.DTO.Historial;

namespace WebTrut.Application.Interfaces
{
     public interface  IHistorialAnalisisService
    {


        Task<IEnumerable<HistorialAnalisisDto>> GetByAnalisisAsync(int idAnalisis);
        Task<HistorialAnalisisDto> CreateAsync(HistorialAnalisisCreateDto dto);
    }
}
