using arquetipo.Domain.Interfaces;
using arquetipo.Entity.Constants;
using arquetipo.Entity.Models;
using arquetipo.Entity.Response;
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
            return await _context.Asignacion.Where(r => r.codigo_asi == cliente).ToListAsync();
        }

        public async Task<Asignacion> Update(Asignacion entity)
        {
            _context.Set<Asignacion>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Response<string>> Delete(int id)
        {

            Response<string> response = new();
            try
            {
                var entity = await GetById(id);
                if (entity != null)
                {
                    _context.Set<Asignacion>().Remove(entity);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    response.Data = null;
                    response.Success = !response.Success;
                    response.Message = Constants.ResponseConstants.NotFound;
                }
            }
            catch (Exception e)
            {
                response.Data = null;
                response.Success = !response.Success;
                response.Message = e.Message;
            }
            return response;

        }

        public async Task<Asignacion> GetById(int id)
        {
            try
            {
                return await _context.Set<Asignacion>().FindAsync(id);
            }
            catch (Exception)
            {
                return null;

            }
        }

        public async Task<bool> Create(Asignacion entity)
        {
            try
            {
                if (!_context.Asignacion.Any(r => r.codigo_sc == entity.codigo_sc))
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
            catch (Exception)
            {
                return false;
            }

        }
    }
}
