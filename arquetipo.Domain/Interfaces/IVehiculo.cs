using arquetipo.Entity.Models;
namespace arquetipo.Domain.Interfaces
{
    public interface IVehiculo
    {
        Task<IEnumerable<Vehiculo>> GetVehiculo(string placa);
        Task<bool> Create(Vehiculo _vehiculo);
        Task Delete(int id);
        Task<Vehiculo> Update(Vehiculo _vehiculo);
        Task<Vehiculo> GetById(int id);
    }
}
