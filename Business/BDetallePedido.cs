using Data;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class BDetallePedido
    {
        private DDetallePedido DetallePedido = null;

        public List<DetallePedido> GetPedidosEntreFechas(int IdPedido)
        {
            List<DetallePedido> detallePedidos = null;
            try
            {
                DetallePedido = new DDetallePedido();
                detallePedidos = DetallePedido.GetDetallePedido(new DetallePedido { Pedido = new Pedido { IdPedido = IdPedido } });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return detallePedidos;
        }

        public decimal GetDetalleTotalPorId(int IdPedido)
        {
            List<DetallePedido> detallePedidos = null;
            decimal total = 0;
            try
            {
                DetallePedido = new DDetallePedido();
                detallePedidos = DetallePedido.GetDetallePedido(new DetallePedido { Pedido = new Pedido { IdPedido = IdPedido } });

                foreach (var item in detallePedidos)
                {
                    total = total + item.Cantidad * item.PrecioUnidad - item.Descuento;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                detallePedidos = null;
            }
            return total;
        }
    }
}
