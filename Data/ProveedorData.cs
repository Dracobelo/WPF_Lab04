using Microsoft.Data.SqlClient;

namespace Data
{
    public class ProveedorData
    {
        private readonly string connectionString = "Server=LAB1502-009\\SQLEXPRESS;Database=Neptuno_DBB;User Id=userHugo;Password=hola1234;Encrypt=True;TrustServerCertificate=True;";

        public List<Proveedor> GetProveedores(string nombreContacto, string ciudad)
        {
            List<Proveedor> lista = new List<Proveedor>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("USP_LISTARPROVEEDORESCONTACTOCIUDAD", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre_contacto", nombreContacto ?? "");
                cmd.Parameters.AddWithValue("@ciudad", ciudad ?? "");
                conn.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new Proveedor
                    {
                        ProveedorID = (int)dr["idProveedor"],
                        NombreCompañia = dr["nombreCompañia"].ToString(),
                        NombreContacto = dr["nombrecontacto"].ToString(),
                        Ciudad = dr["ciudad"].ToString(),
                        Pais = dr["pais"].ToString(),
                        Telefono = dr["telefono"].ToString()
                    });
                }
            }
            return lista;
        }
    }

    public class Proveedor
    {
        public int ProveedorID { get; set; }
        public string NombreCompañia { get; set; }
        public string NombreContacto { get; set; }
        public string Ciudad { get; set; }
        public string Pais { get; set; }
        public string Telefono { get; set; }
    }
}
