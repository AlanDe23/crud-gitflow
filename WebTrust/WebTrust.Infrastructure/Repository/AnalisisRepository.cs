namespace WebTrust.Infrastructure.Repository
{
    using global::WebTrust.Domain.Entities;
    using global::WebTrust.Infrastructure.GeneryRepository;
    using global::WebTrust.Infrastructure.Persitence.Data;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using WebTrut.Application.Interfaces;

    namespace WebTrust.Infrastructure.Repositories
    {
        public class AnalisisRepository : RepositorioGenerico<Analisis>, IAnalisisRepository
        {
            private readonly AppDbContext _context;

            public AnalisisRepository(AppDbContext context) : base(context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Analisis>> GetByUsuarioIdAsync(int idUsuario)
            {
                return await _context.Analisis
                    .Where(a => a.IdUsuario == idUsuario)
                    .ToListAsync();
            }
        }
    }

}
