using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DDetallePedido
    {
        public List<DetallePedido> GetDetallePedido(DetallePedido detallePedido)
        {
            SqlParameter[] parameters = null;
            string comandText = string.Empty;
            List<DetallePedido> detallePedidos = null;

            try
            {
                comandText = "USP_DETALLEPEDIDO";
                parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@idPedido", SqlDbType.Int);
                parameters[0].Value = detallePedido.Pedido.IdPedido;
                detallePedidos = new List<DetallePedido>();

                using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.Connection, "USP_DETALLEPEDIDO"
                    , CommandType.StoredProcedure, parameters))
                {
                    while (reader.Read())
                    {
                        detallePedidos.Add(new DetallePedido
                        {
                            Pedido = new Pedido { IdPedido = reader["idpedido"] != null ? Convert.ToInt32(reader["idpedido"]) : 0 },
                            IdPedido = reader["idproducto"] != null ? Convert.ToInt32(reader["idproducto"]) : 0,
                            PrecioUnidad = reader["preciounidad"] != null ? Convert.ToDecimal(reader["preciounidad"]) : 0,
                            Cantidad = reader["cantidad"] != null ? Convert.ToInt32(reader["cantidad"]) : 0,
                            Descuento = reader["descuento"] != null ? Convert.ToDecimal(reader["descuento"]) : 0,
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return detallePedidos;
        }
    }
}
