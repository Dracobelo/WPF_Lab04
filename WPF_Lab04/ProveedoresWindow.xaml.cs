using Data;
using System;
using System.Collections.Generic;
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

namespace WPF_Lab04
{
    /// <summary>
    /// Lógica de interacción para ProveedoresWindow.xaml
    /// </summary>
    public partial class ProveedoresWindow : Window
    {
        ProveedorData proveedorData = new ProveedorData();

        public ProveedoresWindow()
        {
            InitializeComponent();
        }
        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            string contacto = txtContacto.Text;
            string ciudad = txtCiudad.Text;

            dgProveedores.ItemsSource = proveedorData.GetProveedores(contacto, ciudad);
        }
    }
}
