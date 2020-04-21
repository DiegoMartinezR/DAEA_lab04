using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class DetallePedido
    {
        public Pedido Pedido { get; set; }

        public int IdPedido { get; set; }

    

        public int Cantidad { get; set; }

        public decimal PrecioUnidad { get; set; }

        public decimal Descuento { get; set; }
    }
}
