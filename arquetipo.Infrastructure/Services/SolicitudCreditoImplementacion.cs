using Domain.Interfaces;
using arquetipo.Entity.Models;
using arquetipo.Repository.Context;
using Microsoft.EntityFrameworkCore;
using arquetipo.Domain.Interfaces;
using arquetipo.Entity.Response;
using arquetipo.Entity.Constants;
using Microsoft.EntityFrameworkCore.Storage;

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
        public async Task<Response<string>> Delete(int id)
        {

            Response<string> response = new();
            try
            {
                var entity = await GetById(id);
                if (entity != null)
                {
                    _context.Set<Solicitud_Credito>().Remove(entity);
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
        public async Task<Response<string>> Create(Solicitud_Credito entity)
        {
            using (IDbContextTransaction trx = await _context.Database.BeginTransactionAsync())
            {
                Response<string> response = new();
                try
                {
                    if (!_context.Solicitud_Credito.Any(r => r.codigo_cli == entity.codigo_cli & r.fecha_sc == entity.fecha_sc & entity.codigo_est == 1))
                    {
                        _context.Set<Solicitud_Credito>().Add(entity);
                        _context.SaveChanges();

                        Asignacion asignacion = new Asignacion();
                        asignacion.codigo_sc = entity.codigo_sc;
                        asignacion.fecha_asi = entity.fecha_sc?.ToString();
                        _context.Add(asignacion);
                        await _context.SaveChangesAsync();

                        Vehiculo? veh_r = await _context.Set<Vehiculo>().FindAsync(entity.id_veh);
                        if (veh_r != null)
                        {
                            veh_r.reservado_veh = true;
                            _context.Set<Vehiculo>().Update(veh_r);
                            await _context.SaveChangesAsync();
                        }
                        await trx.CommitAsync();
                    }
                    else
                    {
                        response.Data = null;
                        response.Success = !response.Success;
                        response.Message = Constants.ControlControls.ActiveCredit;
                    }
                }
                catch (Exception e)
                {
                    await trx.RollbackAsync();
                    response.Data = null;
                    response.Success = !response.Success;
                    response.Message = e.Message;
                }
                return response;
            }

        }
    }
}
