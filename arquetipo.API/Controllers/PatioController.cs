using arquetipo.Entity.Models;
using Microsoft.AspNetCore.Mvc;

namespace arquetipo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatioController : ControllerBase
    {
        private readonly Domain.Interfaces.IPatio tcr;
        public PatioController(Domain.Interfaces.IPatio context)
        {
            tcr = context;
        }
        /// <summary>
        /// Obtiene la infromacion del patio mediante busqueda por cedula
        /// </summary>
        /// <param name="patio">nombre del patio</param>
        /// <returns>todas las columnas de la tabla cliente</returns>
        [HttpGet("{nombre}")]
        public async Task<IEnumerable<Patio>> GetPatio(string nombre)
        {
            return await tcr.Get(nombre);
        }
        /// <summary>
        /// Crea patio validando que no existan duplicados validando por nombre
        /// </summary>
        /// <param name="patio">recibe la estructura de vehiculo</param>
        /// <returns>patio creado o vehiculo ya existe</returns>
        [HttpPost]
        public async Task<ActionResult> Create(Patio _patio)
        {
            try
            {
                if (_patio == null)
                {
                    return NotFound("Los valores a crear son nulos");
                }

                bool creado = await tcr.Create(_patio);
                if (creado)
                    return Ok("Creado");
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
        public async Task<ActionResult> Put(Patio _patio)
        {
            if (_patio == null)
            {
                return NotFound("No hay datos para actualizar");
            }

            await tcr.Update(_patio);
            return Ok("Actualizado");
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
                return Ok("Eliminado");
            }
            catch (Exception)
            {
                return BadRequest("EEROR : El patio tiene infromacion asociada.");
            }
        }
    }
}
