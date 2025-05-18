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
            public string correo { get; set; }
            public Persona() { }

            public Persona(int id, string usuario, string nombre, string ePass, string correo)
            {
                this.id = id;
                this.usuario = usuario;
                this.nombre = nombre;
                this.correo = correo;
                this.ePass = ePass;

            }
        }


        //Crea usuario nuevo en la base de datos
        public static int CrearUsuario(Persona persona)
        {
            int retorna = 0;
            try
            {
                using (Microsoft.Data.SqlClient.SqlConnection conexion = conexionSql.ObtenerConexion())
                {

                    //Transaccion para hacer las dos acciones
                    Microsoft.Data.SqlClient.SqlTransaction transaccion = conexion.BeginTransaction();

                    string query1 = ("Insert into usuarios values('" + persona.usuario + "', '" + persona.nombre + "','" + persona.ePass + "'); SELECT SCOPE_IDENTITY();");

                    Microsoft.Data.SqlClient.SqlCommand comando1 = new Microsoft.Data.SqlClient.SqlCommand(query1, conexion, transaccion);


                    //Almacena el id del nuevo usuario creado
                    int IdNuevoUsuario = Convert.ToInt32(comando1.ExecuteScalar());

                    string query2 = ("Insert into CorreosElectronicos values('" + IdNuevoUsuario + "', '" + persona.correo + "')");

                    Microsoft.Data.SqlClient.SqlCommand comando2 = new Microsoft.Data.SqlClient.SqlCommand(query2, conexion, transaccion);

                    retorna = comando2.ExecuteNonQuery();

                    transaccion.Commit();
                }
            }
            catch (Microsoft.Data.SqlClient.SqlException)
            {
                throw;
            }
            return retorna;
        }


        //Actualizar datos de usuario
        public static int ActualizarUsuario(Persona persona)
        {
            int retorna = 0;
            using (Microsoft.Data.SqlClient.SqlConnection conexion = conexionSql.ObtenerConexion())
            {
                string query = ("update usuarios set usuario = '" + persona.usuario + "',nombre = '" + persona.nombre + "', ePass = '" + persona.ePass + "',  where id = " + persona.id + "");
                Microsoft.Data.SqlClient.SqlCommand comando = new Microsoft.Data.SqlClient.SqlCommand(query, conexion);
                retorna = comando.ExecuteNonQuery();
            }
            return retorna;
        }


        //Eliminar usuario de la base de datos
        public static int EliminarUsuario(Persona persona)
        {
            int retorna = 0;
            using (Microsoft.Data.SqlClient.SqlConnection conexion = conexionSql.ObtenerConexion())
            {
                string query = ("delete from usuarios where id = " + persona.id + "");
                Microsoft.Data.SqlClient.SqlCommand comando = new Microsoft.Data.SqlClient.SqlCommand(query, conexion);
                retorna = comando.ExecuteNonQuery();
            }
            return retorna;
        }

        //Obtiene la contraseña para comparar con la ingresada
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

        public static int VerificarUsuarioExistente(Persona persona)
        {
            int retorna = 0;
            using (Microsoft.Data.SqlClient.SqlConnection conexion = conexionSql.ObtenerConexion())
            {
                string query = "SELECT * FROM usuarios WHERE usuario = @usuario";
                using (Microsoft.Data.SqlClient.SqlCommand comando = new Microsoft.Data.SqlClient.SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@usuario", persona.usuario);

                    using (Microsoft.Data.SqlClient.SqlDataReader reader = comando.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            retorna = 1;
                        }
                        else
                        {
                            retorna = 0;
                        }
                    }
                }
            }
            return retorna;

        }

        public static int VerificarCorreoExistente(Persona persona)
        {
            int retorna = 0;
            using (Microsoft.Data.SqlClient.SqlConnection conexion = conexionSql.ObtenerConexion())
            {
                string query = "SELECT * FROM CorreosElectronicos WHERE CorreoElectronico = @CorreoElectronico";
                using (Microsoft.Data.SqlClient.SqlCommand comando = new Microsoft.Data.SqlClient.SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@CorreoElectronico", persona.correo);

                    using (Microsoft.Data.SqlClient.SqlDataReader reader = comando.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            retorna = 1;
                        }
                        else
                        {
                            retorna = 0;
                        }
                    }
                }
            }
            return retorna;

        }

        public static int ObtenerInformacionSesion(string usuario)
        {
            int IdUsuario = -1;
            using (Microsoft.Data.SqlClient.SqlConnection conexion = conexionSql.ObtenerConexion())
            {
                string query = "SELECT Id FROM usuarios WHERE usuario = @usuario";
                using (Microsoft.Data.SqlClient.SqlCommand comando = new Microsoft.Data.SqlClient.SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@usuario", usuario);

                    object resultado = comando.ExecuteScalar();

                    if (resultado != null)
                    {
                        IdUsuario = Convert.ToInt32(resultado);
                    }
                }
            }
            return IdUsuario;
        }
    }
}
