using arquetipo.Entity.Models;
using arquetipo.Repository.Context;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace arquetipo.Infrastructure.Services
{
    public class PatioImplementacion : IPatio
    {
        private readonly BlogContext _context;

        public PatioImplementacion(BlogContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Patio>> GetPatio()
        {
            return await _context.Patio.ToListAsync();
        }
    }
}
