using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arquetipo.Entity.Models
{
    public class Asignacion
    {
        [KeyAttribute]
        public int codigo_asi { get; set; }
        public int id_cli { get; set; }
        public int patio_cli { get; set; }
        public DateTime fecha_asi { get; set; }
    }
}
