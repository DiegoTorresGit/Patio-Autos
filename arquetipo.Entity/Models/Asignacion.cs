using System.ComponentModel.DataAnnotations;

namespace arquetipo.Entity.Models
{
    public class Asignacion
    {
        [KeyAttribute]
        [Required]
        public int codigo_asi { get; set; }
        [Required]
        public int id_cli { get; set; }
        [Required]
        public int id_pat { get; set; }
        [Required]
        public DateTime fecha_asi { get; set; }
    }
}
