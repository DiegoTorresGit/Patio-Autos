using arquetipo.Entity.Models;

namespace arquetipo.Domain.Interfaces
{
    public interface ISolicitudCredito
    {
        Task<IEnumerable<Solicitud_Credito>> Get(string placa);
        Task<bool> Create(Solicitud_Credito _entity);
        Task Delete(int id);
        Task<Solicitud_Credito> Update(Solicitud_Credito _entity);
        Task<Solicitud_Credito> GetById(int id);
    }
}
