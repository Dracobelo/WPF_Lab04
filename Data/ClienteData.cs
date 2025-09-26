using Microsoft.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Data
{
    public class ClienteData
    {
        private readonly string connectionString = "Server=LAB1502-009\\SQLEXPRESS;Database=Neptuno_DBB;User Id=userHugo;Password=hola1234;Encrypt=True;TrustServerCertificate=True;";

        public List<Cliente> GetClientes()
        {
            List<Cliente> lista = new List<Cliente>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("USP_ListaClientes", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new Cliente
                    {
                        idCliente = dr["idCliente"].ToString(),
                        NombreCompañia = dr["NombreCompañia"].ToString(),
                        NombreContacto = dr["NombreContacto"].ToString(),
                        CargoContacto = dr["CargoContacto"].ToString(),
                        Direccion = dr["Direccion"].ToString(),
                        Ciudad = dr["Ciudad"].ToString(),
                        Region = dr["Region"].ToString(),
                        CodPostal = dr["CodPostal"].ToString(),
                        Pais = dr["Pais"].ToString(),
                        Telefono = dr["Telefono"].ToString(),
                        Fax = dr["Fax"].ToString()
                    });

                }
                    
            }
            return lista;
        }

        public List<Cliente> GetClientesForName(string nombreCompania)
        {
            List<Cliente> lista = new List<Cliente>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("USP_ListaClientesPorNombre", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@n_compañia", nombreCompania);

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new Cliente
                    {
                        idCliente = dr["idCliente"].ToString(),
                        NombreCompañia = dr["NombreCompañia"].ToString(),
                        NombreContacto = dr["NombreContacto"].ToString(),
                        CargoContacto = dr["CargoContacto"].ToString(),
                        Direccion = dr["Direccion"].ToString(),
                        Ciudad = dr["Ciudad"].ToString(),
                        Region = dr["Region"].ToString(),
                        CodPostal = dr["CodPostal"].ToString(),
                        Pais = dr["Pais"].ToString(),
                        Telefono = dr["Telefono"].ToString(),
                        Fax = dr["Fax"].ToString()
                    });
                }
            }
            return lista;
        }

        public void InsertCliente (Cliente cliente)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("USP_InsertarClientes", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", cliente.idCliente);
                cmd.Parameters.AddWithValue("@n_compañia", cliente.NombreCompañia);
                cmd.Parameters.AddWithValue("@n_contacto", cliente.NombreContacto);
                cmd.Parameters.AddWithValue("@cargo", cliente.CargoContacto);
                cmd.Parameters.AddWithValue("@direccion", cliente.Direccion);
                cmd.Parameters.AddWithValue("@ciudad", cliente.Ciudad);
                cmd.Parameters.AddWithValue("@region", cliente.Region);
                cmd.Parameters.AddWithValue("@postal", cliente.CodPostal);
                cmd.Parameters.AddWithValue("@pais", cliente.Pais);
                cmd.Parameters.AddWithValue("@tlf", cliente.Telefono);
                cmd.Parameters.AddWithValue("@fax", cliente.Fax);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateCliente(Cliente cliente)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("USP_ActualizarCliente", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", cliente.idCliente);
                cmd.Parameters.AddWithValue("@n_compañia", cliente.NombreCompañia);
                cmd.Parameters.AddWithValue("@n_contacto", cliente.NombreContacto);
                cmd.Parameters.AddWithValue("@cargo", cliente.CargoContacto);
                cmd.Parameters.AddWithValue("@direccion", cliente.Direccion);
                cmd.Parameters.AddWithValue("@ciudad", cliente.Ciudad);
                cmd.Parameters.AddWithValue("@region", cliente.Region);
                cmd.Parameters.AddWithValue("@postal", cliente.CodPostal);
                cmd.Parameters.AddWithValue("@pais", cliente.Pais);
                cmd.Parameters.AddWithValue("@tlf", cliente.Telefono);
                cmd.Parameters.AddWithValue("@fax", cliente.Fax);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteCliente(string idCliente)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("USP_DeleteCliente", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", idCliente);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }

    public class Cliente
    {
        public string idCliente { get; set; }
        public string NombreCompañia { get; set; }
        public string NombreContacto { get; set; }
        public string CargoContacto { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public string Region { get; set; }
        public string CodPostal { get; set; }
        public string Pais { get; set; }
        public string Telefono { get; set; }
        public string Fax { get; set; }

    }
}
