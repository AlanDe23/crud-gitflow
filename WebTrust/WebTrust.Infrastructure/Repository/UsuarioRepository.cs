using WebTrust.Domain.Entities;
using WebTrust.Infrastructure.Persitence.Data;
using WebTrut.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using WebTrust.Infrastructure.GeneryRepository;

namespace WebTrust.Infrastructure.Repository
{

    public class UsuarioRepository : RepositorioGenerico<Usuario>, IUsuarioRepository
    {
        private readonly AppDbContext _context;
            
        public UsuarioRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

   
        public async Task<bool> ExistsByEmailAsync(string email)
        {
            return await _context.Usuario.AnyAsync(u => u.Email == email);
        }



        public async Task<Usuario?> GetByEmailAsync(string email)
        {
            return await _context.Usuario
                .FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());
        }


    }

}
