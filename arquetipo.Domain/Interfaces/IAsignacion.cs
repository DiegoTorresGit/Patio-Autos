using arquetipo.Entity.Models;

namespace arquetipo.Domain.Interfaces
{
    public interface IAsignacion
    {
        Task<IEnumerable<Asignacion>> GetAsignacion();
    }
}
