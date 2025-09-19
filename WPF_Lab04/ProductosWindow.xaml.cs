using Data;
using System.Windows;

namespace WPF_Lab04
{
    public partial class ProductosWindow : Window
    {
        ProductoData productoData = new ProductoData();

        public ProductosWindow()
        {
            InitializeComponent();
        }

        // Botón Buscar → recarga productos
        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            dgProductos.ItemsSource = productoData.GetProductos();
        }

        // Botón Ir a Proveedores → abre la otra vista
        private void BtnIrProveedores_Click(object sender, RoutedEventArgs e)
        {
            var win = new ProveedoresWindow();
            win.Show();                        
        }
    }
}
