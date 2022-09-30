using arquetipo.Entity.Models;

namespace Domain.Interfaces
{
    public interface IMarca
    {
        Task<IEnumerable<Marca>> GetMarca();
    }
}
