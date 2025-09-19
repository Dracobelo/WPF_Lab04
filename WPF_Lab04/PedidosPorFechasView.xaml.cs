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
using System.Windows.Shapes;
using Data;

namespace WPF_Lab04
{

    public partial class PedidosPorFechasView : Window
    {
        public PedidosPorFechasView()
        {
            InitializeComponent();
        }

        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            if (dpInicio.SelectedDate == null || dpFin.SelectedDate == null)
            {
                MessageBox.Show("Selecciona ambas fechas.");
                return;
            }

            DateTime fechaInicio = dpInicio.SelectedDate.Value;
            DateTime fechaFin = dpFin.SelectedDate.Value;

            try
            {
                PedidoRepository repo = new PedidoRepository();
                DataTable dt = repo.ListarPedidosPorFechas(fechaInicio, fechaFin);
                dgPedidos.ItemsSource = dt.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
