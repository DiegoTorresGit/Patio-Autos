using arquetipo.Entity.Models;
using Microsoft.AspNetCore.Mvc;

namespace arquetipo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculoController : Controller
    {
        private readonly Domain.Interfaces.IVehiculo tcr;
        public VehiculoController(Domain.Interfaces.IVehiculo context)
        {
            tcr = context;
        }
        /// <summary>
        /// Obtiene la infromacion del vehiculo mediante busqueda por cedula
        /// </summary>
        /// <param name="cedula">numero de placa</param>
        /// <returns>todas las columnas de la tabla cliente</returns>
        [HttpGet("{placa}")]
        public async Task<IEnumerable<Vehiculo>> GetCliente(string placa)
        {
            return await tcr.GetVehiculo(placa);
        }
        /// <summary>
        /// Crea vehiculo validando que no existan duplicados validando por placa
        /// </summary>
        /// <param name="_vehiculo">recibe la estructura de vehiculo</param>
        /// <returns>Cliente creado o vehiculo ya existe</returns>
        [HttpPost]
        public async Task<ActionResult> Create(Vehiculo _vehiculo)
        {
            try
            {
                if (_vehiculo == null)
                {
                    return NotFound("Los valores a crear son nulos");
                }

                bool creado = await tcr.Create(_vehiculo);
                if (creado)
                    return Ok("vehiculo creado exitosamente");
                else
                    return BadRequest("vehiculo ya existe");
            }
            catch (Exception ex)
            {
                return BadRequest("Se produjo una excepcion en la llamada al metodo create. Mensaje : " + ex.Message);
            }
        }
        /// <summary>
        /// Actualiza los datos de un vehiculo mediante el codigo
        /// </summary>
        /// <param name="_cliente">Se recibe como parametros la estructura del vehiculo</param>
        /// <returns>Valor modificado</returns>

        [HttpPut]
        public async Task<ActionResult> Put(Vehiculo _vehiculo)
        {
            if (_vehiculo == null)
            {
                return NotFound("No hay datos para actualizar");
            }

            await tcr.Update(_vehiculo);
            return Ok("Valor actualizado");
        }
        /// <summary>
        /// Elimina el vehiculo mediante el codigo
        /// </summary>
        /// <param name="id">codigo unico del vehiculo</param>
        /// <returns>Cliente eliminado</returns>

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id == 0)
                {
                    return NotFound("Debe especificar un id de vehiculo");
                }
                await tcr.Delete(id);
                return Ok("Cliente eliminado");
            }
            catch (Exception ex)
            {
                return BadRequest("Se produjo una excepcion. Mensaje: " + ex.InnerException);
            }
        }
    }
}
