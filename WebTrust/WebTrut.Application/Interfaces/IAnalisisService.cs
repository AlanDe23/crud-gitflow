using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTrust.Domain.DTO.AnalisisDTO;
using WebTrust.Domain.Entities;

namespace WebTrut.Application.Interfaces
{
   public interface IAnalisisService
    {

        Task<Analisis> CrearAsync(AnalisisCreateDto dto);
        Task<IEnumerable<Analisis>> ObtenerTodosAsync();
        Task<IEnumerable<Analisis>> ObtenerPorUsuarioAsync(int idUsuario);
        Task<Analisis?> ObtenerPorIdAsync(int id);
        Task<bool> EliminarAsync(int id);

    }
}
