using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace ProyectoFinal
{
    public class datosUsuarios
    {
        public class Persona
        {
            public int id { get; set; }
            public string usuario { get; set; }
            public string contraseña { get; set; }
            public Persona() { }

            public Persona(int id, string usuario, string contraseña)
            {
                this.id = id;
                this.usuario = usuario;
                this.contraseña = contraseña;
            }
        }

        public static int CrearUsuario(Persona persona)
        {
            int retorna = 0;
            using (Microsoft.Data.SqlClient.SqlConnection conexion = conexionSql.ObtenerConexion())
            {
                string query = ("Insert into usuarios values('"+persona.usuario+ "','"+persona.contraseña+"')");
                Microsoft.Data.SqlClient.SqlCommand comando = new Microsoft.Data.SqlClient.SqlCommand(query, conexion);
                retorna = comando.ExecuteNonQuery();
            }
                return retorna;
        }

        public static int ActualizarUsuario(Persona persona)
        {
            int retorna = 0;
            using (Microsoft.Data.SqlClient.SqlConnection conexion = conexionSql.ObtenerConexion())
            {
                string query = ("update usuarios set usuario = '"+persona.usuario+"', contraseña = '"+persona.contraseña+"' where id = "+persona.id+"");
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



    }
}
