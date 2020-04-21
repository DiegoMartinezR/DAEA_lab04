using Data;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class BPedido
    {
        private DPedido dPedido = null;

        public List<Pedido> GetPedidosEntreFechas(DateTime FechaInicio,DateTime FechaFin)
        {
            List<Pedido> pedidos = null;
            try
            {
                dPedido = new DPedido();
                pedidos = dPedido.Get(new Pedido { FechaInicio = FechaInicio ,FechaFin = FechaFin});
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return pedidos;
        }

    }
}
