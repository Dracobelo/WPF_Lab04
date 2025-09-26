using Data;
using System.Windows;

namespace WPF_Lab04
{
    public partial class ClienteWindow : Window
    {
        ClienteData clienteData = new ClienteData();

        public ClienteWindow()
        {
            InitializeComponent();
        }

        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            dgClientes.ItemsSource = clienteData.GetClientes();
        }

        private void BtnInsertar_Click(object sender, RoutedEventArgs e)
        {
            var cliente = new Cliente
            {
                idCliente = txtId.Text,
                NombreCompañia = txtCompania.Text,
                NombreContacto = txtContacto.Text,
                CargoContacto = txtCargo.Text,
                Direccion = txtDireccion.Text,
                Ciudad = txtCiudad.Text,
                Region = txtRegion.Text,
                CodPostal = txtCodPostal.Text,
                Pais = txtPais.Text,
                Telefono = txtTelefono.Text,
                Fax = txtFax.Text
            };

            clienteData.InsertCliente(cliente);
            MessageBox.Show("Cliente insertado correctamente");
            BtnBuscar_Click(null, null);
        }

        private void BtnActualizar_Click(object sender, RoutedEventArgs e)
        {
            var cliente = (Cliente)dgClientes.SelectedItem;
            if (cliente != null)
            {
                cliente.NombreCompañia = txtCompania.Text;
                cliente.NombreContacto = txtContacto.Text;
                cliente.CargoContacto = txtCargo.Text;
                cliente.Direccion = txtDireccion.Text;
                cliente.Ciudad = txtCiudad.Text;
                cliente.Region = txtRegion.Text;
                cliente.CodPostal = txtCodPostal.Text;
                cliente.Pais = txtPais.Text;
                cliente.Telefono = txtTelefono.Text;
                cliente.Fax = txtFax.Text;

                clienteData.UpdateCliente(cliente);
                MessageBox.Show("Cliente actualizado correctamente");
                BtnBuscar_Click(null, null);
            }
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            var cliente = (Cliente)dgClientes.SelectedItem;
            if (cliente != null)
            {
                clienteData.DeleteCliente(cliente.idCliente);
                MessageBox.Show("Cliente eliminado correctamente");
                BtnBuscar_Click(null, null);
            }
        }

        private void dgClientes_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (dgClientes.SelectedItem is Cliente cliente)
            {
                txtId.Text = cliente.idCliente;
                txtCompania.Text = cliente.NombreCompañia;
                txtContacto.Text = cliente.NombreContacto;
                txtCargo.Text = cliente.CargoContacto;
                txtDireccion.Text = cliente.Direccion;
                txtCiudad.Text = cliente.Ciudad;
                txtRegion.Text = cliente.Region;
                txtCodPostal.Text = cliente.CodPostal;
                txtPais.Text = cliente.Pais;
                txtTelefono.Text = cliente.Telefono;
                txtFax.Text = cliente.Fax;
            }
        }
        private void BtnBuscarPorNombre_Click(object sender, RoutedEventArgs e)
        {
            string nombre = txtBuscar.Text.Trim();
            dgClientes.ItemsSource = clienteData.GetClientesForName(nombre);
        }


    }
}
