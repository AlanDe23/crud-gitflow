using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTrust.Domain.DTO.UsuarioDTO
{
    public  class LoginDto
    {

        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
