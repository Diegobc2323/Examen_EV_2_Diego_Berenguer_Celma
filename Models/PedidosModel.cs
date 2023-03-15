using System.ComponentModel.DataAnnotations.Schema;

namespace Examen_EV_2_Diego_Berenguer_Celma.Models
{
    public class PedidosModel
    {
        public int ID { get; set; }

        public string fechaPedido { get; set; }

        public int proveedorID { get; set; }

        public ProveedoresModel proveedor { get; set; }

        [NotMapped]
        public List<int> listaProductos { get; set; }

        public List<PedidosProductosModel> pedidosProductos { get; set; }
    }
}
