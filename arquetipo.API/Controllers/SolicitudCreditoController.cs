using arquetipo.Entity.Models;
using Microsoft.AspNetCore.Mvc;

namespace arquetipo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitudCreditoController : Controller
    {
        private readonly Domain.Interfaces.ISolicitudCredito tcr;
        public SolicitudCreditoController(Domain.Interfaces.ISolicitudCredito context)
        {
            tcr = context;
        }
        /// <summary>
        /// Obtiene la infromacion del vehiculo mediante busqueda por cedula
        /// </summary>
        /// <param name="cedula">numero de placa</param>
        /// <returns>todas las columnas de la tabla cliente</returns>
        [HttpGet("{cliente}")]
        public async Task<IEnumerable<Solicitud_Credito>> Get(string criterio)
        {
            return await tcr.Get(criterio);
        }
        /// <summary>
        /// Crea vehiculo validando que no existan duplicados validando por placa
        /// </summary>
        /// <param name="_vehiculo">recibe la estructura de vehiculo</param>
        /// <returns>Cliente creado o vehiculo ya existe</returns>
        [HttpPost]
        public async Task<ActionResult> Create(Solicitud_Credito _entity)
        {
            try
            {
                if (_entity == null)
                {
                    return NotFound("Los valores a crear son nulos");
                }

                bool creado = await tcr.Create(_entity);
                if (creado)
                    return Ok("Creado exitosamente");
                else
                    return BadRequest("Ya existe");
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
        public async Task<ActionResult> Put(Solicitud_Credito _entity)
        {
            if (_entity == null)
            {
                return NotFound("No hay datos para actualizar");
            }

            await tcr.Update(_entity);
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
                    return NotFound("Debe especificar un id");
                }
                await tcr.Delete(id);
                return Ok("Registro eliminado.");
            }
            catch (Exception ex)
            {
                return BadRequest("Se produjo una excepcion. Mensaje: " + ex.InnerException);
            }
        }
    }
}
