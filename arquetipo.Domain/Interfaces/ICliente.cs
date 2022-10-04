using arquetipo.Entity.Models;
using arquetipo.Entity.Response;
using System.Data;

namespace arquetipo.Domain.Interfaces
{
    public interface ICliente 
    {
        Task<Response<List<Cliente>>> GetAll();
        Task <IEnumerable<Cliente>> GetClientes(string cedula);
        Task<String> Import(string url);
        Task<Response<string>> Create(Cliente cliente);
        Task Delete(int id);
        Task<Cliente> Update(Cliente cliente);
        Task<Cliente> GetById(int id);
    }

}
