using arquetipo.Domain.Interfaces;
using arquetipo.Entity.Models;
using arquetipo.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class ClienteImplementacion : ICliente
    {
        private readonly BlogContext _context;

        public ClienteImplementacion(BlogContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> GetClientes()
        {
            return await _context.Cliente.ToListAsync();
        }
    }
}
