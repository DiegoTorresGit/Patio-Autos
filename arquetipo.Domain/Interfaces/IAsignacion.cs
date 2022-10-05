using arquetipo.Entity.Models;
using arquetipo.Entity.Response;

namespace arquetipo.Domain.Interfaces
{
    public interface IAsignacion
    {
        Task<IEnumerable<Asignacion>> GetAsignacion(int cliente);
        Task<bool> Create(Asignacion cliente);
        Task<Response<string>> Delete(int id);

        Task<Asignacion> Update(Asignacion cliente);
        Task<Asignacion> GetById(int id);
    }
}
