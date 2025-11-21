using WebTrust.Domain.DTO.Historial;
using WebTrust.Domain.Entities;
using WebTrut.Application.Interfaces;

namespace WebTrut.Application.Service
{
    public class HistorialAnalisisService : IHistorialAnalisisService
    {
        private readonly IHistorialAnalisisRepository _repo;

        public HistorialAnalisisService(IHistorialAnalisisRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<HistorialAnalisisDto>> GetByAnalisisAsync(int idAnalisis)
        {
            var lista = await _repo.GetByAnalisisAsync(idAnalisis);
            return lista.Select(h => new HistorialAnalisisDto
            {
                IdHistorial = h.IdHistorial,
                IdAnalisis = h.IdAnalisis,
                FechaRegistro = h.FechaRegistro,
                ResultadoAnterior = h.ResultadoAnterior,
                ResultadoNuevo = h.ResultadoNuevo,
                Observacion = h.Observacion
            });
        }

        public async Task<HistorialAnalisisDto> CreateAsync(HistorialAnalisisCreateDto dto)
        {
            var entity = new HistorialAnalisis
            {
                IdAnalisis = dto.IdAnalisis,
                ResultadoAnterior = dto.ResultadoAnterior,
                ResultadoNuevo = dto.ResultadoNuevo,
                Observacion = dto.Observacion,
                FechaRegistro = DateTime.UtcNow
            };

            await _repo.AddAsync(entity);
            await _repo.SaveChangesAsync();

            return new HistorialAnalisisDto
            {
                IdHistorial = entity.IdHistorial,
                IdAnalisis = entity.IdAnalisis,
                FechaRegistro = entity.FechaRegistro,
                ResultadoAnterior = entity.ResultadoAnterior,
                ResultadoNuevo = entity.ResultadoNuevo,
                Observacion = entity.Observacion
            };
        }
    }
}
