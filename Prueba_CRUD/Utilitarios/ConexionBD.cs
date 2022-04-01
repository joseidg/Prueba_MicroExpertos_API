using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_API.Utilitarios
{
    public class ConexionBD
    {
        public static DataSet ListarUsuarios(string sqlsource, int timeout = -1)
        {
            DataSet dsResult = new DataSet();
            DataTable dtQuery = new DataTable();
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=db_crud;user id = test; password =test2022;Integrated Security=SSPI;"))
            {
                con.Open();
                SqlCommand command = new SqlCommand(sqlsource, con);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    dtQuery.Load(reader);
                    dsResult.Tables.Add(dtQuery);
                }
            }
            return dsResult;
        }

        public static bool Consultas(string sqlsource, int timeout = -1)
        {
            bool resultado = false;
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=db_crud;user id = test; password =test2022;Integrated Security=SSPI;"))
            {
                con.Open();
                SqlCommand command = new SqlCommand(sqlsource, con);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    resultado = true;
                }
            }

            return resultado;
        }
    }
}
