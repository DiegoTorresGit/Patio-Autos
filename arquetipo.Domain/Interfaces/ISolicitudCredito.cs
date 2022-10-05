using arquetipo.Entity.Models;
using arquetipo.Entity.Response;

namespace arquetipo.Domain.Interfaces
{
    public interface ISolicitudCredito
    {
        Task<IEnumerable<Solicitud_Credito>> Get(string placa);
        Task<Response<string>> Create(Solicitud_Credito cliente);

        Task<Response<string>> Delete(int id);

        Task<Solicitud_Credito> Update(Solicitud_Credito _entity);
        Task<Solicitud_Credito> GetById(int id);
    }
}
