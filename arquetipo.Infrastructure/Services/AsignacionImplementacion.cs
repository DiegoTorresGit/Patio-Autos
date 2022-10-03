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

        public async Task<IEnumerable<Asignacion>> GetAsignacion(int cliente)
        {
            return await _context.Asignacion.Where(r => r.id_cli == cliente).ToListAsync();
        }

        public async Task<Asignacion> Update(Asignacion entity)
        {
            _context.Set<Asignacion>().Update(entity);
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

                _context.Set<Asignacion>().Remove(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async Task<Asignacion> GetById(int id)
        {
            try
            {
                return await _context.Set<Asignacion>().FindAsync(id);
            }
            catch (Exception e)
            {
                return null;

            }
        }

        public async Task<bool> Create(Asignacion entity)
        {
            try
            {
                if (!_context.Asignacion.Any(r => r.id_cli == entity.id_cli))
                {
                    _context.Set<Asignacion>().Add(entity);
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
