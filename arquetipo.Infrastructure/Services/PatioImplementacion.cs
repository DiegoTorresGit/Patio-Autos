using arquetipo.Domain.Interfaces;
using arquetipo.Entity.Models;
using arquetipo.Repository.Context;
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
        public async Task<IEnumerable<Patio>> GetAll()
        {
                return await _context.Patio.ToListAsync();
        }
        public async Task<IEnumerable<Patio>> Get(string patio)
        {
            return await _context.Patio.Where(r => r.nombre_pat == patio).ToListAsync();
        }
        public async Task<Patio> Update(Patio entity)
        {
            _context.Set<Patio>().Update(entity);
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

                _context.Set<Patio>().Remove(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }

        }
        public async Task<Patio> GetById(int id)
        {
            try
            {
                return await _context.Set<Patio>().FindAsync(id);
            }
            catch (Exception)
            {
                return null;

            }
        }
        public async Task<bool> Create(Patio entity)
        {
            try
            {
                if (!_context.Patio.Any(r => r.nombre_pat == entity.nombre_pat))
                {
                    _context.Set<Patio>().Add(entity);
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
