using arquetipo.Entity.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace arquetipo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
      
        private readonly Domain.Interfaces.IMarca _Imarca;

        public MarcaController(Domain.Interfaces.IMarca context)
        {
            _Imarca = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Marca>> Get()
        {
            return await _Imarca.GetMarca();
        }

        [HttpPost]
        public async Task<ActionResult> Create(string rutacsv)
        {
            try
            {
                string mensaje = "";
                mensaje = await _Imarca.Import(@"C:\Users\Diego Torres\Documents\marca.csv");
                return Ok(mensaje);
            }
            catch (Exception ex)
            {
                return BadRequest("Mensaje : " + ex.Message);
            }
        }

    }
}
