using System.Security.Cryptography;
using System.Text;
using WebTrust.Domain.DTO.UsuarioDTO;
using WebTrust.Domain.Entities;
using WebTrut.Application.Interfaces;

namespace WebTrust.Infrastructure.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        /// <summary>
        /// Registra un nuevo usuario en el sistema.
        /// </summary>
        public async Task<Usuario> RegistrarAsync(UsuarioCreateDto dto)
        {
            // Validar correo duplicado
            bool existe = await _usuarioRepository.ExistsByEmailAsync(dto.Email);
            if (existe)
                throw new InvalidOperationException("El correo ya está registrado.");

            var usuario = new Usuario
            {
                Nombre = dto.Nombre,
                Email = dto.Email,
                PasswordHash =dto.Password,
                FechaRegistro = DateTime.Now,
                Activo = true
            };

            await _usuarioRepository.AddAsync(usuario);
            await _usuarioRepository.SaveChangesAsync();
            return usuario;
        }

        /// <summary>
        /// Obtiene todos los usuarios activos.
        /// </summary>
        public async Task<IEnumerable<Usuario>> ObtenerUsuariosAsync()
        {
            return await _usuarioRepository.GetAllAsync();
        }

        /// <summary>
        /// Obtiene un usuario por su Id.
        /// </summary>
        public async Task<Usuario?> ObtenerPorIdAsync(int id)
        {
            return await _usuarioRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// Actualiza los datos de un usuario existente.
        /// </summary>
        public async Task<Usuario?> ActualizarAsync(int id, UsuarioCreateDto dto)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            if (usuario == null)
                return null;

            if (!string.IsNullOrEmpty(dto.Nombre))
                usuario.Nombre = dto.Nombre;

            if (!string.IsNullOrEmpty(dto.Email))
                usuario.Email = dto.Email;

            await _usuarioRepository.Update(usuario);
            await _usuarioRepository.SaveChangesAsync();
            return usuario;
        }

        /// <summary>
        /// Desactiva (elimina lógicamente) un usuario.
        /// </summary>
        public async Task<bool> EliminarAsync(int id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            if (usuario == null)
                return false;

            usuario.Activo = false;
            await _usuarioRepository.Update(usuario);
            return true;
        }

        public async Task<Usuario?> ObtenerPorEmailAsync(string email)
        {
            return await _usuarioRepository.GetByEmailAsync(email);
        }
    }
}