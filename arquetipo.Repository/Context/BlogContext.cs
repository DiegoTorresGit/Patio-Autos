using arquetipo.Entity.Models;
using Microsoft.EntityFrameworkCore;



namespace arquetipo.Repository.Context
{
    public class BlogContext : DbContext
    {
        public BlogContext()
        {
        }

        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {
        }

        public virtual DbSet<Post> Post { get; set; } = null!;
        public virtual DbSet<Asignacion> Asignacion { get; set; } = null!;
        public virtual DbSet<Cliente> Cliente { get; set; } = null!;
        public virtual DbSet<Ejecutivo> Ejecutivo { get; set; } = null!;
        public virtual DbSet<Marca> Marca { get; set; } = null!;
        public virtual DbSet<Patio> Patio { get; set; } = null!;
        public virtual DbSet<Solicitud_Credito> Solicitud_Credito { get; set; } = null!;
        public virtual DbSet<Vehiculo> Vehiculo { get; set; } = null!;

    }
}
