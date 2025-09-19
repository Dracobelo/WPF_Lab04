using Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_Lab04
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnProductos_Click(object sender, RoutedEventArgs e)
        {
            ProductosWindow productosView = new ProductosWindow();
            productosView.Show();
        }

        private void btnProveedores_Click(object sender, RoutedEventArgs e)
        {
            ProveedoresWindow proveedoresView = new ProveedoresWindow();
            proveedoresView.Show();
        }

        private void btnPedidosFechas_Click(object sender, RoutedEventArgs e)
        {
            PedidosPorFechasView win = new PedidosPorFechasView();
            win.ShowDialog();
        }
    }

}