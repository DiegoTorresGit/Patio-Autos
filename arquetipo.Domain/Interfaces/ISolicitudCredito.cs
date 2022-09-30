using arquetipo.Entity.Models;

namespace Domain.Interfaces
{
    public interface ISolicitudCredito
    {
        Task<IEnumerable<Solicitud_Credito>> GetSolicitud();
    }
}
