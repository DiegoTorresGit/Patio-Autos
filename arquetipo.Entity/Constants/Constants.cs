using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arquetipo.Entity.Constants
{
    public class Constants
    {

        public class ResponseConstants
        {
            public static string Success = "OK.";
            public static string NotFound = "No Encontrado.";
        }

        public class EntitiesConstants
        {
            public static string Successful = "successfully completed";
            public static string NotCompleted = "No completado";
        }

        public class ControlControls
        {
            public static string StatusOK = "100";
            public static string Empty = "No hay registros";
            public static string DuplicatedClient = "El cliente ya existe";
            public static string DuplicatedVehicle = "El vehiculo ya existe";
            public static string ActiveCredit = "Ya existe una solicitud para el cliente";
            public static string ReservedVehicle = "Ya existe una reserva para el vehiculo";
        }
    }
}
