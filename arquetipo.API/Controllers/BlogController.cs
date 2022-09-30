using Microsoft.AspNetCore.Mvc;

using arquetipo.Entity.Models;
using arquetipo.Infrastructure.Services;
using arquetipo.Domain.Interfaces;

namespace arquetipo.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        //private object servicio;

        private readonly IPost servicio;

        public BlogController(IPost _servicio){

           servicio = _servicio;

        }

        // GET: api/Blog
        [HttpGet]
        public async Task<IEnumerable<Post>> GetPosts()
        {
            return await servicio.GetPosts();
        }
        
    }
}