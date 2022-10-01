using arquetipo.Entity.Models;
using System.Data;

namespace arquetipo.Domain.Interfaces
{
    public interface ICliente 
    {
        Task<IEnumerable<Cliente>> GetClientes();
        Task<String> Import(string url);
    }

}
