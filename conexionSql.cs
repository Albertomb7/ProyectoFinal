using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace ProyectoFinal
{
    public class conexionSql
    {
        public static Microsoft.Data.SqlClient.SqlConnection ObtenerConexion()
        {
            Microsoft.Data.SqlClient.SqlConnection conexion = new Microsoft.Data.SqlClient.SqlConnection("Server=tcp:mcabrera23.database.windows.net,1433;Initial Catalog=proyectoFinalProgra1;Persist Security Info=False;User ID=administrador;Password=Proyecto2025;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            conexion.Open();
            return conexion;
        }
    }
}
