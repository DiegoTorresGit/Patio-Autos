using System;
using System.ComponentModel.DataAnnotations;

namespace arquetipo.Entity.Models
{
    public class Cliente
    {
        [KeyAttribute]
        public int id_cli { get; set; }
        public string? identificacion_cli { get; set; }
        public string? nombres_cli { get; set; }
        public int edad_cli { get; set; }
        public DateTime fecha_naciminto_cli { get; set; }
        public string? apellidos_cli { get; set; }
        public string? direccion_cli { get; set; }
        public string? telefono_cli { get; set; }
        public string? estado_civil_cli { get; set; }
        public string? identificacion_conyuge_cli { get; set; }
        public string? nombre_conyugue_cli { get; set; }
        public string? sujeto_credito_cli { get; set; }
    }
}
