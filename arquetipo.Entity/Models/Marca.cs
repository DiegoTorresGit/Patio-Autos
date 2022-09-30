using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arquetipo.Entity.Models
{
    public class Marca
    {
        [KeyAttribute]
        public int id_mar { get; set; }
        public string? descripcion_mar { get; set; }
    }
}
