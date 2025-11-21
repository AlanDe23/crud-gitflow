using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTrust.Domain.Entities;
using WebTrust.Infrastructure.GeneryRepository;
using WebTrust.Infrastructure.Persitence.Data;
using WebTrut.Application.Interfaces;

namespace WebTrust.Infrastructure.Repository
{
    public class HistorialAnalisisRepository : RepositorioGenerico<HistorialAnalisis>, IHistorialAnalisisRepository
    {
        private readonly AppDbContext _context;

        public HistorialAnalisisRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<HistorialAnalisis>> GetByAnalisisAsync(int idAnalisis)
        {
            return await _context.HistorialAnalisis
                .Where(h => h.IdAnalisis == idAnalisis)
                .OrderByDescending(h => h.FechaRegistro)
                .ToListAsync();
        }
    }


}