
using System.ComponentModel.DataAnnotations;

namespace arquetipo.Entity.Models
{

    public class Vehiculo
    {
        [Key]
        [Required]
        public int id_veh { get; set; }
        [Required]
        public string? placa_veh { get; set; }
        [Required]
        public string? modelo_veh { get; set; }
        [Required]
        public string? nro_chasis_veh { get; set; }
        [Required]
        public int id_mar { get; set; }
        public string? tipo_veh { get; set; }
        [Required]
        public decimal cilindraje_veh { get; set; }
        [Required]
        public decimal avaluo_veh { get; set; }
        [Required]
        public int anio_veh { get; set; }
        [Required]
        public bool reservado_veh { get; set; } = false;

    }
}
