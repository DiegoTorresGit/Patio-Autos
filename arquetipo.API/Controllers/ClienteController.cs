using arquetipo.Entity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace arquetipo.API.Controllers
{
    /// <summary>
    /// Controlador de clientes
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly Domain.Interfaces.ICliente tcr;

        public ClienteController(Domain.Interfaces.ICliente context)
        {
            tcr = context;
        }
        [HttpGet]
        public async Task<IEnumerable<Cliente>> GetCliente()
        {
            return await tcr.GetClientes();
        }


        [HttpPost]
        public async Task<ActionResult>Import(string rutacsv)
        {
            try
            {
                //DataTable csv = tcr.Import(@"C:\Users\Diego Torres\Documents\cliente.csv");

                //var result = from row in csv.AsEnumerable()
                //             group row by row.Field<string>("identificacion") into g
                //             where g.Count() > 1
                //             select new
                //             {
                //                 codigo = g.Key
                //             };
                //if (result.Count()>0)
                //{
                //    return BadRequest("Existen datos duplicados : " + result.FirstOrDefault().codigo);
                //}

                //foreach (DataRow dt_csv in csv.Rows)
                //{
                //    cliente cliente = new cliente();
                //    cliente.identificacion_cli = dt_csv[0].ToString();
                //    cliente.nombres_cli = dt_csv[1].ToString();
                //    cliente.edad_cli = Convert.ToInt32(dt_csv[2].ToString());
                //    cliente.fecha_naciminto_cli = Convert.ToDateTime(dt_csv[3].ToString());
                //    cliente.apellidos_cli = dt_csv[4].ToString();
                //    cliente.direccion_cli = dt_csv[5].ToString();
                //    cliente.telefono_cli = dt_csv[6].ToString();
                //    cliente.estado_civil_cli = dt_csv[7].ToString();
                //    cliente.identificacion_cli = dt_csv[8].ToString();
                //    cliente.nombre_conyugue_cli = dt_csv[9].ToString();
                //    cliente.sujeto_credito_cli = dt_csv[10].ToString();
                //    await tcr.Create(cliente);
                //}
                return Ok("Datos importados exitosamente");
            }
            catch (Exception ex)
            {
                return BadRequest("Mensaje : " +  ex.Message);
            }
        }
    }
}
