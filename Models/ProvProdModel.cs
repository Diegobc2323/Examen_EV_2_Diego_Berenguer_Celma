namespace Examen_EV_2_Diego_Berenguer_Celma.Models
{
    public class ProvProdModel
    {
        public int ID { get; set; }

        public int proveedorID { get; set; }

        public ProveedoresModel proveedor { get; set; }

        public int productoID { get; set; }
    
        public ProductosModel producto { get; set; }

        
    }
}
