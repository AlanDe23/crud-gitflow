using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTrust.Infrastructure.Persitence.Data;
using WebTrut.Application.Interfaces;

namespace WebTrust.Infrastructure.GeneryRepository
{
    public class RepositorioGenerico<T> : IRepositorioGenerico<T> where T : class
    {

        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public RepositorioGenerico(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public virtual async Task Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public virtual async Task Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }




    }
}
