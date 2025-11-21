using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTrust.Domain.Entities;
using WebTrut.Application.Interfaces;

namespace WebTrut.Application.Service
{
     public class LoginService
    {
        private readonly IUsuarioRepository _usuarioRepository;



        public LoginService(IUsuarioRepository usuarioRepository) 
        {

            _usuarioRepository = usuarioRepository;
            
        
        
        }
        public async Task<Usuario> LoginAsync(string correo, string contrasena)
        {


            try
            {
                var usuario = await _usuarioRepository.GetByEmailAsync(correo);

                if (usuario == null)
                    throw new Exception("El correo ingresado no está registrado.");

                if (usuario.PasswordHash != contrasena)
                    throw new Exception("La contraseña es incorrecta.");

                // Si todo está bien  retorna el usuario
                return usuario;
            }
            catch (Exception ex)
            {
                // Aquí puedes registrar el error en logs o base de datos si quieres
                Console.WriteLine($"[ERROR LOGIN]: {ex.Message}");
                throw; // Re-lanza la excepción para manejarla en la capa superior (controlador, por ejemplo)
            }

        }


    }
}
