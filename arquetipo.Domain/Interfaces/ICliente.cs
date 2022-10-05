using arquetipo.Entity.Models;
using arquetipo.Entity.Response;
using System.Data;

namespace arquetipo.Domain.Interfaces
{
    public interface ICliente 
    {
        Task<Response<List<Cliente>>> GetAll();
        Task <Response<List<Cliente>>> GetClientesCedula(string cedula);
        Task<String> Import(string url);
        Task<Response<string>> Create(Cliente cliente);
        Task<Response<string>> Delete(int id);
        Task<Response<string>> Update(Cliente cliente);
        Task<Cliente> GetById(int id);
    }

}
