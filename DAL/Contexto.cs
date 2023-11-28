using DulceriaMABB.Shared;
using Microsoft.EntityFrameworkCore;

namespace DulceriaMABB.DAL
{
    public class Contexto:DbContext
    {
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Recepciones> Recepciones { get; set; }
        public DbSet<Ventas> Ventas { get; set; }

        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }
    }
}
