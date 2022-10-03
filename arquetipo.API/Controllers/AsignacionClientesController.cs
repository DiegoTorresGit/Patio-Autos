using arquetipo.Entity.Models;
using Microsoft.AspNetCore.Mvc;

namespace arquetipo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsignacionClientesController : Controller
    {
        private readonly Domain.Interfaces.IAsignacion tcr;
        public AsignacionClientesController(Domain.Interfaces.IAsignacion context)
        {
            tcr = context;
        }
        /// <summary>
        /// Obtiene la infromacion de la asignacion mediante busqueda por cedula
        /// </summary>
        /// <param name="cedula">numero de cedula</param>
        /// <returns>todas las columnas de la tabla</returns>
        [HttpGet("{cedula}")]
        public async Task<IEnumerable<Asignacion>> GetAsignacion(int cedula)
        {
            return await tcr.GetAsignacion(cedula);
        }
        /// <summary>
        /// Crea clientes validando que no existan duplicados validando por numero de cedula
        /// </summary>
        /// <param name="_cliente">recibe la estructura de clientes</param>
        /// <returns>Cliente creado o cliente ya existe</returns>
        [HttpPost]
        public async Task<ActionResult> Create(Asignacion _asignacion)
        {
            try
            {
                if (_asignacion == null)
                {
                    return NotFound("Los valores a crear son nulos");
                }

                bool creado = await tcr.Create(_asignacion);
                if (creado)
                    return Ok("Asignacion creada exitosamente");
                else
                    return BadRequest("Asignacion ya existe");
            }
            catch (Exception ex)
            {
                return BadRequest("Se produjo una excepcion en la llamada al metodo create. Mensaje : " + ex.Message);
            }
        }
        /// <summary>
        /// Actualiza los datos de un cliente mediante el codigo
        /// </summary>
        /// <param name="_cliente">Se recibe como parametros la estructura del cliente</param>
        /// <returns>Valor modificado</returns>

        [HttpPut]
        public async Task<ActionResult> Put(Asignacion _asignacion)
        {
            if (_asignacion == null)
            {
                return NotFound("No hay datos para actualizar");
            }

            await tcr.Update(_asignacion);
            return Ok("Valor actualizado");
        }
        /// <summary>
        /// Elimina la asignacion mediante el codigo
        /// </summary>
        /// <param name="id">codigo unico de la asignacion</param>
        /// <returns>asignacion eliminada</returns>

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id == 0)
                {
                    return NotFound("Debe especificar un id de asignacion");
                }
                await tcr.Delete(id);
                return Ok("Asignacion eliminada");
            }
            catch (Exception ex)
            {
                return BadRequest("Se produjo una excepcion. Mensaje: " + ex.Message);
            }
        }
    }
}
