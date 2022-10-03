using arquetipo.Entity.Models;

namespace arquetipo.Domain.Interfaces
{
    public interface IPatio
    {
        Task<IEnumerable<Patio>> Get(string placa);
        Task<bool> Create(Patio _vehiculo);
        Task Delete(int id);
        Task<Patio> Update(Patio _vehiculo);
        Task<Patio> GetById(int id);
    }
}
