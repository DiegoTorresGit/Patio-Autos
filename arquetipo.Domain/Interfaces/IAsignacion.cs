using arquetipo.Entity.Models;

namespace arquetipo.Domain.Interfaces
{
    public interface IAsignacion
    {
        Task<IEnumerable<Asignacion>> GetAsignacion(int cliente);
        Task<bool> Create(Asignacion cliente);
        Task Delete(int id);
        Task<Asignacion> Update(Asignacion cliente);
        Task<Asignacion> GetById(int id);
    }
}
