using arquetipo.Entity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult>Create(string rutacsv)
        {
            try
            {
                string mensaje = "";
                mensaje = await tcr.Import(@"C:\Users\Diego Torres\Documents\cliente.csv");
                return  Ok(mensaje);
            }
            catch (Exception ex)
            {
                return BadRequest("Mensaje : " +  ex.Message);
            }
        }
    }
}
