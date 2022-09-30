using arquetipo.Entity.Models;

namespace arquetipo.Domain.Interfaces
{
    public interface ICliente 
    {
        Task<IEnumerable<Cliente>> GetClientes();
    }

}
