using arquetipo.Domain.Interfaces;
using arquetipo.Entity.Models;
using arquetipo.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace arquetipo.Infrastructure.Services
{
    public class AsignacionImplementacion : IAsignacion
    {
        private readonly BlogContext _context;

        public AsignacionImplementacion(BlogContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Asignacion>> GetAsignacion()
        {
            return await _context.Asignacion.ToListAsync();
        }
    }
}
