using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTrust.Domain.DTO.UsuarioDTO;
using WebTrust.Domain.Entities;

namespace WebTrut.Application.Interfaces
{
   public  interface IUsuarioService
    {
        Task<Usuario> RegistrarAsync(UsuarioCreateDto dto);
        Task<IEnumerable<Usuario>> ObtenerUsuariosAsync();
        Task<Usuario?> ObtenerPorIdAsync(int id);
        Task<Usuario?> ActualizarAsync(int id, UsuarioCreateDto dto);
        Task<bool> EliminarAsync(int id);


        Task<Usuario?> ObtenerPorEmailAsync(string email);
    }
}
