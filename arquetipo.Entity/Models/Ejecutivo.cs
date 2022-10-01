using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arquetipo.Entity.Models
{
    public class Ejecutivo
    {
        [KeyAttribute]
        public int id_eje { get; set; }
        public string? identificacion_eje { get; set; }
        public string? nombres_eje { get; set; }
        public string? apellidos_eje { get; set; }
        public string? direccion_eje { get; set; }
        public string? telefono_con_eje { get; set; }
        public string? celular_eje { get; set; }
        public int id_pat { get; set; }
        public int edad_eje { get; set; }

    }
}
