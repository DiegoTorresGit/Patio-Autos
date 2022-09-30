using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arquetipo.Entity.Models
{
    public class Patio
    {
        [KeyAttribute]
        public int id_pat { get; set; }
        public string? nombre_pat { get; set; }
        public string? direccion_pat { get; set; }
        public string? telefono_pat { get; set; }
        public int numero_pv_pat { get; set; }

    }
}
