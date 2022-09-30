
using System.ComponentModel.DataAnnotations;

namespace arquetipo.Entity.Models
{
    public class Solicitud_Credito
    {
        [Key]
        public int codigo_sc { get; set; }
        public DateTime fecha_sc { get; set; }
        public int id_cli { get; set; }
        public int id_pat { get; set; }
        public int id_veh { get; set; }
        public int meses_plazo { get; set; }
        public int cuotas_sc { get; set; }
        public int entrada_sc { get; set; }
        public int id_eje { get; set; }
        public string? observacion_eje { get; set; }

    }
}
