using Microsoft.EntityFrameworkCore;
using proyect_prestamo.Modelos;

namespace proyect_prestamo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Definición de la tabla (DbSet) para los usuarios
        public DbSet<Usuarios> Usuarios { get; set; }
    

    }
}
