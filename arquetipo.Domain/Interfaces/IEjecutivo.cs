using arquetipo.Entity.Models;

namespace arquetipo.Domain.Interfaces
{
    public interface IEjecutivo
    {
        Task<IEnumerable<Ejecutivo>> GetEjecutivo();

        Task<String> Import(string url);
    }
}
