using arquetipo.Entity.Models;
using System.Data;

namespace arquetipo.Domain.Interfaces
{
    public interface ICliente 
    {
        Task <IEnumerable<Cliente>> GetClientes(string cedula);
        Task<String> Import(string url);
        Task<bool> Create(Cliente cliente);
        Task Delete(int id);
        Task<Cliente> Update(Cliente cliente);
        Task<Cliente> GetById(int id);
    }

}
