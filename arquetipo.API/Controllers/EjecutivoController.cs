using arquetipo.Entity.Models;
using Microsoft.AspNetCore.Mvc;

namespace arquetipo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EjecutivoController : ControllerBase
    {
        private readonly Domain.Interfaces.IEjecutivo tcr;
        public EjecutivoController(Domain.Interfaces.IEjecutivo context)
        {
            tcr = context;
        }
        /// <summary>
        /// Obtiene la infromacion del ejecutivo mediante busqueda por cedula
        /// </summary>
        /// <param name="cedula">numero de cedula</param>
        /// <returns>todas las columnas de la tabla ejecutivo</returns>
        [HttpGet("{cedula}")]
        public async Task<IEnumerable<Ejecutivo>> GetCliente(string cedula)
        {
            return await tcr.GetEjecutivo(cedula);
        }
        /// <summary>
        /// Importa los datos de los ejecutivos mediante un rchivo csv
        /// </summary>
        /// <param name="rutacsv">Se envia la ruta del csv para convertirlo en tabla y validar duplicidad de de datos</param>
        /// <returns>valor creado o datos duplicados</returns>
        [HttpPost("ImportarEjecutivos")]
        public async Task<ActionResult> ImportarEjecutivos(string rutacsv)
        {
            try
            {
                string mensaje = "";
                mensaje = await tcr.Import(@"C:\Users\Diego Torres\Documents\ejecutivo.csv");
                return Ok(mensaje);
            }
            catch (Exception ex)
            {
                return BadRequest("Mensaje : " + ex.Message);
            }
        }
        /// <summary>
        /// Crea ejecutivos validando que no existan duplicados validando por numero de cedula
        /// </summary>
        /// <param name="_cliente">recibe la estructura de clientes</param>
        /// <returns>Cliente creado o ejecutivo ya existe</returns>
        [HttpPost]
        public async Task<ActionResult> Create(Ejecutivo _ejecutivo)
        {
            try
            {
                if (_ejecutivo == null)
                {
                    return NotFound("Los valores a crear son nulos");
                }

                bool creado = await tcr.Create(_ejecutivo);
                if (creado)
                    return Ok("Cliente creado exitosamente");
                else
                    return BadRequest("Ejecutivo ya existe");
            }
            catch (Exception ex)
            {
                return BadRequest("Se produjo una excepcion en la llamada al metodo create. Mensaje : " + ex.Message);
            }
        }
        /// <summary>
        /// Actualiza los datos de un ejecutivo mediante el codigo
        /// </summary>
        /// <param name="_cliente">Se recibe como parametros la estructura del ejecutivo</param>
        /// <returns>Valor modificado</returns>

        [HttpPut]
        public async Task<ActionResult> Put(Ejecutivo _ejecutivo)
        {
            if (_ejecutivo == null)
            {
                return NotFound("No hay datos para actualizar");
            }

            await tcr.Update(_ejecutivo);
            return Ok("Valor actualizado");
        }
        /// <summary>
        /// Elimina el ejecutivo mediante el codigo
        /// </summary>
        /// <param name="id">codigo unico del cliente</param>
        /// <returns>ejecutivo eliminado</returns>

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id == 0)
                {
                    return NotFound("Debe especificar un id de ejecutivo");
                }
                await tcr.Delete(id);
                return Ok("Ejecutivo eliminado");
            }
            catch (Exception)
            {
                return BadRequest("ERROR: El ejecutivo no puede ser eliminado, tiene infromacion asociada.");
            }
        }

    }
}
