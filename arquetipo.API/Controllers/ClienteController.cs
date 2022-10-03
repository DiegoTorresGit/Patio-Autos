using arquetipo.Entity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace arquetipo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly Domain.Interfaces.ICliente tcr;
        public ClienteController(Domain.Interfaces.ICliente context)
        {
            tcr = context;
        }
        /// <summary>
        /// Obtiene la infromacion del cliente mediante busqueda por cedula
        /// </summary>
        /// <param name="cedula">numero de cedula</param>
        /// <returns>todas las columnas de la tabla cliente</returns>
        [HttpGet ("{cedula}")]
        public  async Task<IEnumerable<Cliente>> GetCliente(string cedula)
        {
            return await tcr.GetClientes(cedula);
        }
        /// <summary>
        /// Importa los datos de los clientes mediante un rchivo csv
        /// </summary>
        /// <param name="rutacsv">Se envia la ruta del csv para convertirlo en tabla y validar duplicidad de de datos</param>
        /// <returns>valor creado o datos duplicados</returns>
        [HttpPost ("ImportarClientes")]
        public async Task<ActionResult> ImportarClientes(string rutacsv)
        {
            try
            {
                string mensaje = "";
                mensaje = await tcr.Import(@"C:\Users\Diego Torres\Documents\cliente.csv");
                return Ok(mensaje);
            }
            catch (Exception ex)
            {
                return BadRequest("Mensaje : " + ex.Message);
            }
        }
        /// <summary>
        /// Crea clientes validando que no existan duplicados validando por numero de cedula
        /// </summary>
        /// <param name="_cliente">recibe la estructura de clientes</param>
        /// <returns>Cliente creado o cliente ya existe</returns>
        [HttpPost]
        public async Task<ActionResult> Create(Cliente _cliente)
        {
            try
            {
                if (_cliente == null)
                {
                    return NotFound("Los valores a crear son nulos");
                }
                
                bool creado = await tcr.Create(_cliente);
                if (creado)
                    return Ok("Cliente creado exitosamente");
                else
                    return BadRequest("Cliente ya existe");
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
        public async Task<ActionResult> Put(Cliente _cliente)
        {
            if (_cliente == null)
            {
                return NotFound("No hay datos para actualizar");
            }

            await tcr.Update(_cliente);
            return Ok("Valor actualizado");
        }
        /// <summary>
        /// Elimina el cliente mediante el codigo
        /// </summary>
        /// <param name="id">codigo unico del cliente</param>
        /// <returns>Cliente eliminado</returns>

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id == 0)
                {
                    return NotFound("Debe especificar un id de cliente");
                }
                await tcr.Delete(id);
                return Ok("Cliente eliminado");
            }
            catch (Exception)
            {
                return BadRequest("ERROR: El cliente no puede ser eliminado, tiene infromacion asociada.");
            }
        }
    }
}
