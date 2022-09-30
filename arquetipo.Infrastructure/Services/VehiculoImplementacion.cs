using arquetipo.Entity.Models;
using arquetipo.Repository.Context;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class VehiculoImplementacion : IVehiculo
    {
        private readonly BlogContext _context;

        public VehiculoImplementacion(BlogContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Vehiculo>> GetVehiculos()
        {
            return await _context.Vehiculo.ToListAsync();
        }
    }
}
