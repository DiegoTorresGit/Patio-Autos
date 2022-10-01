using arquetipo.Entity.Models;

namespace arquetipo.Domain.Interfaces
{
    public interface IMarca
    {
        Task<IEnumerable<Marca>> GetMarca();

        Task<String> Import(string url);
    }
}
