
using System.Data;

namespace Domain.Interfaces
{
    public interface IGeneric <TEntity> where TEntity: class
    {
        Task<List<TEntity>> GetAll();

        Task<TEntity> GetById(int id);

        Task<TEntity> Create(TEntity entity);

        Task<TEntity> Update(TEntity entity);

        Task Delete(int id);

        DataTable Import(string url);
    }
}
