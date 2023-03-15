using System.ComponentModel.DataAnnotations.Schema;

namespace Examen_EV_2_Diego_Berenguer_Celma.Models
{
    public class ProveedoresModel
    {

        public int ID { get; set; }

        public string nomProveedor { get; set; }

        [NotMapped]
        public List<int> listaPedidos { get; set; }

        public List<PedidosModel> pedidos { get; set; }

        public List<ProvProdModel> propProv { get; set; }
    }
}
