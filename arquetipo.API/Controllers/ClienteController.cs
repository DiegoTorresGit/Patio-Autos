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
        /// 

        //[HttpGet ("{cedula}")]
        //public  async Task<IEnumerable<Cliente>> GetCliente(string cedula)
        //{
        //    return await tcr.GetClientes(cedula);
        //}
        [HttpGet("")]
        public async Task<ActionResult> GetCliente()
        {
            var result = await tcr.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        /// <summary>
        /// Importa los datos de los clientes mediante un rchivo csv
        /// </summary>
        /// <param name="rutacsv">Se envia la ruta del csv para convertirlo en tabla y validar duplicidad de de datos</param>
        /// <returns>valor creado o datos duplicados</returns>
        [HttpPost("ImportarClientes")]
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
                return BadRequest(ex.Message);
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
                if (ModelState.IsValid)
                {
                    var result = await tcr.Create(_cliente);
                    if (result.Success)
                    {
                        return Ok(result);
                    }
                    return BadRequest(result);
                }
                return BadRequest(ModelState.ValidationState);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
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
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await tcr.Update(_cliente);
                    if (result.Success)
                    {
                        return Ok(result);
                    }
                    return BadRequest(result);
                }
                return BadRequest(ModelState.ValidationState);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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
                    var result= await tcr.Delete(id);
                    if (result.Success)
                    {
                        return Ok(result);
                    }
                    return BadRequest(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
