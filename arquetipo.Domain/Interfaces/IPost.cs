using arquetipo.Entity.Models;

namespace arquetipo.Domain.Interfaces
{
    public interface IPost    
    {
       Task<IEnumerable<Post>> GetPosts();
        
    }
}