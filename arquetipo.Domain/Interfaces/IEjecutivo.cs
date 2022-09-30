using arquetipo.Entity.Models;

namespace Domain.Interfaces
{
    public interface IEjecutivo
    {
        Task<IEnumerable<Ejecutivo>> GetEjecutivo();
    }
}
