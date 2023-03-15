using Microsoft.EntityFrameworkCore;

namespace Examen_EV_2_Diego_Berenguer_Celma.Models
{
    public class Contexto : DbContext
    {

        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }

        public DbSet<PedidosModel> Pedidos { get; set; }

        public DbSet<PedidosProductosModel> PedidosProductos { get; set; }

        public DbSet<ProductosModel> Productos { get; set; }

        public DbSet<ProveedoresModel> Proveedores { get; set; }

        public DbSet<ProvProdModel> ProvProd { get; set; }

    }
}
