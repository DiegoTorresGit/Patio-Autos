using Domain.Interfaces;
using arquetipo.Entity.Models;
using arquetipo.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class SolicitudImplementacion : ISolicitudCredito
    {
        private readonly BlogContext _context;

        public SolicitudImplementacion(BlogContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Solicitud_Credito>> GetSolicitud()
        {
            return await _context.Solicitud.ToListAsync();
        }
    }
}
