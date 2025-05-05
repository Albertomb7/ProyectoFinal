using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;


namespace ProyectoFinal
{
    public class datosUsuarios
    {
        public class Persona
        {
            public int id { get; set; }
            public string usuario { get; set; }
            public string nombre { get; set; }
            public string ePass { get; set; }
            public Persona() { }

            public Persona(int id, string usuario, string nombre, string ePass)
            {
                this.id = id;
                this.usuario = usuario;
                this.nombre = nombre;
                this.ePass = ePass;
            }
        }

        public static int CrearUsuario(Persona persona)
        {
            int retorna = 0;
            try
            {
                using (Microsoft.Data.SqlClient.SqlConnection conexion = conexionSql.ObtenerConexion())
                {
                    string query = ("Insert into usuarios values('" + persona.usuario + "', '" + persona.nombre + "','" + persona.ePass + "')");
                    Microsoft.Data.SqlClient.SqlCommand comando = new Microsoft.Data.SqlClient.SqlCommand(query, conexion);
                    retorna = comando.ExecuteNonQuery();
                }
            }
            catch (Microsoft.Data.SqlClient.SqlException )
            {
                throw;
            }
            return retorna;
        }

        public static int ActualizarUsuario(Persona persona)
        {
            int retorna = 0;
            using (Microsoft.Data.SqlClient.SqlConnection conexion = conexionSql.ObtenerConexion())
            {
                string query = ("update usuarios set usuario = '"+persona.usuario+ "',nombre = '"+persona.nombre+ "', ePass = '" + persona.ePass+"',  where id = "+persona.id+"");
                Microsoft.Data.SqlClient.SqlCommand comando = new Microsoft.Data.SqlClient.SqlCommand(query, conexion);
                retorna = comando.ExecuteNonQuery();
            }
            return retorna;
        }

        public static int EliminarUsuario(Persona persona)
        {
            int retorna = 0;
            using (Microsoft.Data.SqlClient.SqlConnection conexion = conexionSql.ObtenerConexion())
            {
                string query = ("delete from usuarios where id = "+persona.id+"");
                Microsoft.Data.SqlClient.SqlCommand comando = new Microsoft.Data.SqlClient.SqlCommand(query, conexion);
                retorna = comando.ExecuteNonQuery();
            }
            return retorna;
        }

        public static int IniciarSesion(Persona persona)
        {
            int retorna = 0;
            using (Microsoft.Data.SqlClient.SqlConnection conexion = conexionSql.ObtenerConexion())
            {
                string query = "SELECT ePass FROM usuarios WHERE usuario = @usuario";
                using (Microsoft.Data.SqlClient.SqlCommand comando = new Microsoft.Data.SqlClient.SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@usuario", persona.usuario);

                    using (Microsoft.Data.SqlClient.SqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {

                            persona.ePass = reader.GetString(0);
                            retorna = 1; 
                        }
                    }
                }
            }
            return retorna;

        }


    }
}
