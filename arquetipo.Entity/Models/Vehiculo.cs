
using System.ComponentModel.DataAnnotations;

namespace arquetipo.Entity.Models
{
    public class Vehiculo
    {
        [Key]
        public int id_veh { get; set; }
        public string? placa_veh { get; set; }
        public string? modelo_veh { get; set; }
        public string? nro_chasis_veh { get; set; }
        public int id_mar { get; set; }
        public string? tipo_veh { get; set; }
        public string? cilindraje_veh { get; set; }
        public string? avaluo_veh { get; set; }

    }
}
