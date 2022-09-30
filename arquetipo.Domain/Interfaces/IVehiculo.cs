using arquetipo.Entity.Models;
namespace Domain.Interfaces
{
    public interface IVehiculo
    {
        Task<IEnumerable<Vehiculo>> GetVehiculos();
    }
}
