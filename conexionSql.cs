using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace ProyectoFinal
{
    internal class conexionSql
    {
        public static void ObtenerConexion()
        {
            Microsoft.Data.SqlClient.SqlConnection conexion = new Microsoft.Data.SqlClient.SqlConnection("Server=tcp:mcabrera23.database.windows.net,1433;Initial Catalog=proyectoFinalProgra1;Persist Security Info=False;User ID=administrador;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            conexion.Open();
        }
    }
}
