using System.ComponentModel.DataAnnotations;

namespace arquetipo.Entity.Models
{
    public class Asignacion
    {
        [KeyAttribute]
        [Required]
        public int codigo_asi { get; set; }
        [Required]
        public int codigo_sc { get; set; }
        [Required]
        public string? fecha_asi { get; set; }
    }
}
