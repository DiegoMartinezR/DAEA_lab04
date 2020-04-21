using Business;
using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Semana03
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnConsultar_Click(object sender, RoutedEventArgs e)
        {
            BPedido bPedido = null;
            try
            {
               bPedido = new BPedido();
                dgvPedido.ItemsSource = bPedido.GetPedidosEntreFechas(
               Convert.ToDateTime(textFechaInicio.Text),
               Convert.ToDateTime(textFechaFin.Text));
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        private void DgvPedido_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                BDetallePedido detallePedido = new BDetallePedido();
                int idPedido;
                var item = (Pedido)dgvPedido.SelectedItem;
                if (item == null) return;
                idPedido = Convert.ToInt32(item.IdPedido);
                dgvDetallePedido.ItemsSource = detallePedido.GetPedidosEntreFechas(idPedido);
                textTotal.Text = Convert.ToString(detallePedido.GetDetalleTotalPorId(idPedido));

            }
            catch (Exception ex)
            {

                //throw;
            }
        }
    }
}
