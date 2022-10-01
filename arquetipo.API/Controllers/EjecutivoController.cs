using arquetipo.Entity.Models;
using Microsoft.AspNetCore.Mvc;

namespace arquetipo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EjecutivoController : ControllerBase
    {
        private readonly Domain.Interfaces.IEjecutivo _IEjecutivo;

        public EjecutivoController(Domain.Interfaces.IEjecutivo context)
        {
            _IEjecutivo = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Ejecutivo>> Get()
        {
            return await _IEjecutivo.GetEjecutivo();
        }

        [HttpPost]
        public async Task<ActionResult> Create(string rutacsv)
        {
            try
            {
                string mensaje = "";
                mensaje = await _IEjecutivo.Import(@"C:\Users\Diego Torres\Documents\ejecutivo.csv");
                return Ok(mensaje);
            }
            catch (Exception ex)
            {
                return BadRequest("Mensaje : " + ex.Message);
            }
        }

    }
}
