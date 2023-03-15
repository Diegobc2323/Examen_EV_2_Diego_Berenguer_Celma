namespace Examen_EV_2_Diego_Berenguer_Celma.Models
{
    public class PedidosProductosModel
    {
        public int ID { get; set; }

        public int pedidoID { get; set; }

        public PedidosModel pedido { get; set; }

        public int productoID { get; set; }

        public ProductosModel producto { get; set; }
    }
}
