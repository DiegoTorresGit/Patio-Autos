using arquetipo.Domain.Interfaces;
using arquetipo.Entity.Models;
using arquetipo.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace arquetipo.Infrastructure.Services
{
    public class VehiculoImplementacion : IVehiculo
    {
        private readonly BlogContext _context;

        public VehiculoImplementacion(BlogContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Vehiculo>> GetVehiculo(string placa)
        {
            return await _context.Vehiculo.Where(r => r.placa_veh == placa).ToListAsync();
        }

        public async Task<Vehiculo> Update(Vehiculo entity)
        {
            _context.Set<Vehiculo>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(int id)
        {
            try
            {
                var entity = await GetById(id);
                if (entity == null)
                    throw new Exception("No existen datos");

                _context.Set<Vehiculo>().Remove(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async Task<Vehiculo> GetById(int id)
        {
            try
            {
                return await _context.Set<Vehiculo>().FindAsync(id);
            }
            catch (Exception e)
            {
                return null;

            }
        }
        public async Task<bool> Create(Vehiculo entity)
        {
            try
            {
                if (!_context.Vehiculo.Any(r => r.placa_veh == entity.placa_veh))
                {
                    _context.Set<Vehiculo>().Add(entity);
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }

        }
    }
}
