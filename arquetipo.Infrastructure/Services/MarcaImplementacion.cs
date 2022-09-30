using Domain.Interfaces;
using arquetipo.Repository.Context;
using arquetipo.Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class MarcaImplementacion :  IMarca
    {

        private readonly BlogContext _context;

        public MarcaImplementacion(BlogContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Marca>> GetMarca()
        {
            return await _context.Marca.ToListAsync();
        }
    }
}
