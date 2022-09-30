using arquetipo.Entity.Models;

namespace Domain.Interfaces
{
    public interface IPatio
    {
        Task<IEnumerable<Patio>> GetPatio();
    }
}
