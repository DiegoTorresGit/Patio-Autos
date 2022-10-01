using System.ComponentModel.DataAnnotations;

namespace arquetipo.Entity.Models
{
    public class Marca
    {
        [KeyAttribute]
        public int id_mar { get; set; }
        public string? descripcion_mar { get; set; }
    }
}
