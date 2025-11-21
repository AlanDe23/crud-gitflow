using WebTrust.Domain.DTO.AnalisisDTO;
using WebTrust.Domain.Entities;
using WebTrut.Application.Interfaces;

namespace WebTrust.Infrastructure.Services
{
    public class AnalisisService : IAnalisisService
    {
        private readonly IAnalisisRepository _analisisRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public AnalisisService(IAnalisisRepository analisisRepository, IUsuarioRepository usuarioRepository)
        {
            _analisisRepository = analisisRepository;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Analisis> CrearAsync(AnalisisCreateDto dto)
        {
            // Verificar si el usuario existe
            var usuario = await _usuarioRepository.GetByIdAsync(dto.IdUsuario);
            if (usuario == null)
                throw new InvalidOperationException("El usuario no existe.");

            var analisis = new Analisis
            {
                IdUsuario = dto.IdUsuario,
                Url = dto.Url,
                Titulo = dto.Titulo,
                PorcentajeConfianza = dto.PorcentajeConfianza,
                Detalles = dto.Detalles,
                FechaAnalisis = DateTime.Now
            };

            await _analisisRepository.AddAsync(analisis);
            await _analisisRepository.SaveChangesAsync();
            return analisis;
        }

        public async Task<IEnumerable<Analisis>> ObtenerTodosAsync()
        {
            await _analisisRepository.SaveChangesAsync();
            return await _analisisRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Analisis>> ObtenerPorUsuarioAsync(int idUsuario)
        {
            await _analisisRepository.SaveChangesAsync();
            return await _analisisRepository.GetByUsuarioIdAsync(idUsuario);
        }

        public async Task<Analisis?> ObtenerPorIdAsync(int id)
        {
            await _analisisRepository.SaveChangesAsync();
            return await _analisisRepository.GetByIdAsync(id);
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var analisis = await _analisisRepository.GetByIdAsync(id);
            if (analisis == null)
                return false;

            await _analisisRepository.Delete(analisis);
            await _analisisRepository.SaveChangesAsync();
            return true;
        }
    }
}
