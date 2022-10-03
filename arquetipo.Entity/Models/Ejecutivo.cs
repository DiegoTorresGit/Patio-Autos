using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arquetipo.Entity.Models
{
    public class Ejecutivo
    {
        [KeyAttribute]
        [Required]
        public int id_eje { get; set; }
        [Required]
        public string? identificacion_eje { get; set; }
        [Required]
        public string? nombres_eje { get; set; }
        [Required]
        public string? apellidos_eje { get; set; }
        [Required]
        public string? direccion_eje { get; set; }
        [Required]
        public string? telefono_con_eje { get; set; }
        [Required]
        public string? celular_eje { get; set; }
        [Required]
        public int id_pat { get; set; }
        [Required]
        public int edad_eje { get; set; }

    }
}
