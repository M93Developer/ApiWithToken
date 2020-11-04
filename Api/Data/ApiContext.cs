using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Data
{
    public class ApiContext : DbContext
    {
        //cambiar por línea conectada para usar conección de 
        //public ApiContext (DbContextOptions<ApiContext> options) : base(options)
        //public ApiContext () : base("EvolutionDb")
        public ApiContext() : base("EvolutionDb")
        {

        }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
    }
}
