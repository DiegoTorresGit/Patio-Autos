using Domain.Interfaces;
using arquetipo.Entity.Models;
using arquetipo.Repository.Context;
using Microsoft.EntityFrameworkCore;
using arquetipo.Domain.Interfaces;

namespace arquetipo.Infrastructure.Services
{
    public class SolicitudCreditoImplementacion : ISolicitudCredito
    {
        private readonly BlogContext _context;
        public SolicitudCreditoImplementacion(BlogContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Solicitud_Credito>> Get(string patio)
        {
            if (patio == "TODOS")
                return await _context.Solicitud_Credito.ToListAsync();
            else
                return await _context.Solicitud_Credito.Where(r => r.observacion_eje == patio).ToListAsync();
        }
        public async Task<Solicitud_Credito> Update(Solicitud_Credito entity)
        {
            _context.Set<Solicitud_Credito>().Update(entity);
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

                _context.Set<Solicitud_Credito>().Remove(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }

        }
        public async Task<Solicitud_Credito> GetById(int id)
        {
            try
            {
                return await _context.Set<Solicitud_Credito>().FindAsync(id);
            }
            catch (Exception)
            {
                return null;

            }
        }
        public async Task<bool> Create(Solicitud_Credito entity)
        {
            try
            {
                if (!_context.Solicitud_Credito.Any(r => r.codigo_cli == entity.codigo_cli & r.fecha_sc==entity.fecha_sc & entity.codigo_est==1 ))
                {
                    _context.Set<Solicitud_Credito>().Add(entity);
                    _context.SaveChanges();

                    Asignacion asignacion = new Asignacion();
                    asignacion.codigo_sc = entity.codigo_sc;
                    asignacion.fecha_asi = entity.fecha_sc?.ToString();
                    _context.Add(asignacion);
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
