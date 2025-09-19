using Microsoft.Data.SqlClient;
using System.Data;

namespace Data
{
    public class PedidoRepository
    {
        private readonly string connectionString = "Server=LAB1502-009\\SQLEXPRESS;Database=NeptunoDBB;User Id=draco;Password=hola1234;Encrypt=True;TrustServerCertificate=True;";


        public DataTable ListarPedidosPorFechas(DateTime fechaInicio, DateTime fechaFin)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("USP_LISTARDETALLESPEDIDOSFECHAS", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@fecha_inicio", fechaInicio));
                    cmd.Parameters.Add(new SqlParameter("@fecha_fin", fechaFin));

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    return dt;
                }
            }
        }
    }
}
