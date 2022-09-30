using arquetipo.Entity.Models;
using arquetipo.Repository.Context;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class EjecutivoImplementacion : IEjecutivo
    {
        private readonly BlogContext _context;

        public EjecutivoImplementacion(BlogContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ejecutivo>> GetEjecutivo()
        {
            return await _context.Ejecutivo.ToListAsync();
        }
    }
}
