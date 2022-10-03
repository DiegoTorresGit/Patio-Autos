using System.ComponentModel.DataAnnotations;

namespace arquetipo.Entity.Models
{
    public class Cliente
    {
        [KeyAttribute]
        [Required]
        public int id_cli { get; set; }
        [Required]
        public string? identificacion_cli { get; set; }
        [Required]
        public string? nombres_cli { get; set; }
        [Required]
        public int edad_cli { get; set; }
        [Required]
        public DateTime fecha_naciminto_cli { get; set; }
        [Required]
        public string? apellidos_cli { get; set; }
        [Required]
        public string? direccion_cli { get; set; }
        [Required]
        public string? telefono_cli { get; set; }
        [Required]
        public string? estado_civil_cli { get; set; }
        [Required]
        public string? identificacion_conyuge_cli { get; set; }
        [Required]
        public string? nombre_conyugue_cli { get; set; }
        [Required]
        public string? sujeto_credito_cli { get; set; }
    }
}
