using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTrust.Domain.Entities;

namespace WebTrut.Application.Interfaces
{
  public interface IUsuarioRepository:IRepositorioGenerico<Usuario>
    {

        Task<Usuario?> GetByEmailAsync(string email);
        Task<bool> ExistsByEmailAsync(string email);
    }



}
