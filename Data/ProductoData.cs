using Microsoft.Data.SqlClient;
namespace Data
{
    public class ProductoData
    {
        private readonly string connectionString = "Server=LAB1502-009\\SQLEXPRESS;Database=NeptunoDBB;User Id=draco;Password=hola1234;Encrypt=True;TrustServerCertificate=True;";

        public List<Producto> GetProductos()
        {
            List<Producto> lista = new List<Producto>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GETPRODUCTOS", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new Producto
                    {
                        ProductoID = Convert.ToInt32(dr["idproducto"]),
                        NombreProducto = dr["NombreProducto"].ToString(),
                        Precio = Convert.ToDecimal(dr["precioUnidad"]),
                        Stock = Convert.ToInt32(dr["unidadesEnExistencia"])
                    });
                }
            }
            return lista;
        }
    }

    public class Producto
    {
        public int ProductoID { get; set; }
        public string NombreProducto { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
    }
}
