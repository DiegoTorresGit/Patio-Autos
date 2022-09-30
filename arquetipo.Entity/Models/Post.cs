using System.ComponentModel.DataAnnotations;

namespace arquetipo.Entity.Models
{
    
    public class Post
    {
        [KeyAttribute]
        public int PosId { get; set; }
        public string? Titulo { get; set; }
        public string? Detalle { get; set; }
    }
}
