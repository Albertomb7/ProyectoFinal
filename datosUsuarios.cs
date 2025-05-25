using System;
using System.Collections.Generic;
using System.Data.SqlClient; 
using System.Globalization;
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
            public bool ModoOscuro { get; set; }

            public Persona()
            {
                ModoOscuro = true; // Default
            }

            public Persona(int id, string usuario, string nombre, string ePass, string correo, bool modoOscuro)
            {
                this.id = id;
                this.usuario = usuario;
                this.nombre = nombre;
                this.correo = correo;
                this.ePass = ePass;
                this.ModoOscuro = modoOscuro;
            }
        }

        public static int CrearUsuario(Persona persona)
        {
            int retorna = 0;
            try
            {
                using (Microsoft.Data.SqlClient.SqlConnection conexion = conexionSql.ObtenerConexion())
                {
                    Microsoft.Data.SqlClient.SqlTransaction transaccion = conexion.BeginTransaction();

                    string query1 = @"
                        INSERT INTO usuarios (usuario, nombre, ePass, ModoOscuro)
                        VALUES (@usuario, @nombre, @ePass, @ModoOscuro);
                        SELECT SCOPE_IDENTITY();";

                    Microsoft.Data.SqlClient.SqlCommand comando1 = new Microsoft.Data.SqlClient.SqlCommand(query1, conexion, transaccion);
                    comando1.Parameters.AddWithValue("@usuario", persona.usuario);
                    comando1.Parameters.AddWithValue("@nombre", persona.nombre);
                    comando1.Parameters.AddWithValue("@ePass", persona.ePass);
                    comando1.Parameters.AddWithValue("@ModoOscuro", persona.ModoOscuro);

                    int IdNuevoUsuario = Convert.ToInt32(comando1.ExecuteScalar());

                    string query2 = "INSERT INTO CorreosElectronicos (IdUsuario, CorreoElectronico) VALUES (@IdUsuario, @CorreoElectronico)";
                    Microsoft.Data.SqlClient.SqlCommand comando2 = new Microsoft.Data.SqlClient.SqlCommand(query2, conexion, transaccion);
                    comando2.Parameters.AddWithValue("@IdUsuario", IdNuevoUsuario);
                    comando2.Parameters.AddWithValue("@CorreoElectronico", persona.correo);

                    retorna = comando2.ExecuteNonQuery();
                    transaccion.Commit();
                }
            }
            catch (Microsoft.Data.SqlClient.SqlException ex)
            {
                Console.WriteLine("Error SQL en CrearUsuario: " + ex.Message + "\n" + ex.StackTrace);
                throw;
            }
            return retorna;
        }

        public static int ActualizarUsuario(Persona persona)
        {
            int retorna = 0;
            using (Microsoft.Data.SqlClient.SqlConnection conexion = conexionSql.ObtenerConexion())
            {
                string query = @"UPDATE usuarios
                                 SET usuario = @usuario, nombre = @nombre, ePass = @ePass, ModoOscuro = @ModoOscuro
                                 WHERE id = @id";
                Microsoft.Data.SqlClient.SqlCommand comando = new Microsoft.Data.SqlClient.SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@usuario", persona.usuario);
                comando.Parameters.AddWithValue("@nombre", persona.nombre);
                comando.Parameters.AddWithValue("@ePass", persona.ePass);
                comando.Parameters.AddWithValue("@ModoOscuro", persona.ModoOscuro);
                comando.Parameters.AddWithValue("@id", persona.id);
                try
                {
                    retorna = comando.ExecuteNonQuery();
                }
                catch (Microsoft.Data.SqlClient.SqlException ex)
                {
                    Console.WriteLine("Error SQL en ActualizarUsuario: " + ex.Message);
                    throw;
                }
            }
            return retorna;
        }

        public static int ActualizarPreferenciasTema(int idUsuario, bool modoOscuro)
        {
            int retorna = 0;
            using (Microsoft.Data.SqlClient.SqlConnection conexion = conexionSql.ObtenerConexion())
            {
                string query = "UPDATE usuarios SET ModoOscuro = @ModoOscuro WHERE Id = @IdUsuario";
                using (Microsoft.Data.SqlClient.SqlCommand comando = new Microsoft.Data.SqlClient.SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@ModoOscuro", modoOscuro);
                    comando.Parameters.AddWithValue("@IdUsuario", idUsuario);
                    try
                    {
                        retorna = comando.ExecuteNonQuery();
                    }
                    catch (Microsoft.Data.SqlClient.SqlException ex)
                    {
                        Console.WriteLine("Error SQL en ActualizarPreferenciasTema: " + ex.Message);
                        throw;
                    }
                }
            }
            return retorna;
        }

        public static bool ObtenerPreferenciasTema(int idUsuario)
        {
            bool modoOscuro = true;
            using (Microsoft.Data.SqlClient.SqlConnection conexion = conexionSql.ObtenerConexion())
            {
                string query = "SELECT ModoOscuro FROM usuarios WHERE Id = @IdUsuario";
                using (Microsoft.Data.SqlClient.SqlCommand comando = new Microsoft.Data.SqlClient.SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@IdUsuario", idUsuario);
                    try
                    {
                        object resultado = comando.ExecuteScalar();
                        if (resultado != null && resultado != DBNull.Value)
                        {
                            modoOscuro = Convert.ToBoolean(resultado);
                        }
                    }
                    catch (Microsoft.Data.SqlClient.SqlException ex)
                    {
                        Console.WriteLine("Error SQL en ObtenerPreferenciasTema: " + ex.Message);
                    }
                }
            }
            return modoOscuro;
        }

        public static int EliminarUsuario(Persona persona)
        {
            int retorna = 0;
            using (Microsoft.Data.SqlClient.SqlConnection conexion = conexionSql.ObtenerConexion())
            {
                string query = ("delete from usuarios where id = @id");
                Microsoft.Data.SqlClient.SqlCommand comando = new Microsoft.Data.SqlClient.SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@id", persona.id);
                try
                {
                    retorna = comando.ExecuteNonQuery();
                }
                catch (Microsoft.Data.SqlClient.SqlException ex)
                {
                    Console.WriteLine("Error SQL en EliminarUsuario: " + ex.Message);
                    throw;
                }
            }
            return retorna;
        }

        public static Persona IniciarSesion(string nombreUsuario)
        {
            Persona personaLogueada = null;
            using (Microsoft.Data.SqlClient.SqlConnection conexion = conexionSql.ObtenerConexion())
            {
                // MODIFICACIÓN AQUÍ: Añadido COLLATE para búsqueda de usuario insensible a mayúsculas/minúsculas
                string query = @"
                    SELECT u.Id, u.ePass, u.ModoOscuro, u.nombre, ce.CorreoElectronico
                    FROM usuarios u
                    LEFT JOIN CorreosElectronicos ce ON u.Id = ce.IdUsuario
                    WHERE u.usuario COLLATE SQL_Latin1_General_CP1_CI_AS = @usuario COLLATE SQL_Latin1_General_CP1_CI_AS";

                using (Microsoft.Data.SqlClient.SqlCommand comando = new Microsoft.Data.SqlClient.SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@usuario", nombreUsuario);
                    try
                    {
                        using (Microsoft.Data.SqlClient.SqlDataReader reader = comando.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                personaLogueada = new Persona
                                {
                                    id = Convert.ToInt32(reader["Id"]),
                                    usuario = nombreUsuario, // Guardamos el usuario como se ingresó, o podríamos leerlo de u.usuario
                                    ePass = reader["ePass"].ToString(),
                                    ModoOscuro = reader["ModoOscuro"] != DBNull.Value ? Convert.ToBoolean(reader["ModoOscuro"]) : true,
                                    nombre = reader["nombre"] != DBNull.Value ? reader["nombre"].ToString() : string.Empty,
                                    correo = reader["CorreoElectronico"] != DBNull.Value ? reader["CorreoElectronico"].ToString() : string.Empty
                                };
                            }
                        }
                    }
                    catch (Microsoft.Data.SqlClient.SqlException ex)
                    {
                        Console.WriteLine("Error SQL en IniciarSesion: " + ex.Message + "\n" + ex.StackTrace);
                        personaLogueada = null;
                    }
                    catch (Exception ex) // Captura general para otros posibles errores durante la lectura
                    {
                        Console.WriteLine("Error general en IniciarSesion al leer datos: " + ex.Message + "\n" + ex.StackTrace);
                        personaLogueada = null;
                    }
                }
            }
            return personaLogueada;
        }

        public static int VerificarUsuarioExistente(Persona persona)
        {
            int retorna = 0;
            using (Microsoft.Data.SqlClient.SqlConnection conexion = conexionSql.ObtenerConexion())
            {
                // COLLATE Latin1_General_CS_AS hace la comparación sensible a mayúsculas/minúsculas
                string query = "SELECT COUNT(*) FROM usuarios WHERE usuario COLLATE Latin1_General_CS_AS = @usuario";
                using (Microsoft.Data.SqlClient.SqlCommand comando = new Microsoft.Data.SqlClient.SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@usuario", persona.usuario);
                    try
                    {
                        int count = (int)comando.ExecuteScalar();
                        if (count == 0)
                        {
                            retorna = 1; // No existe
                        }
                        else
                        {
                            retorna = 0; // Sí existe
                        }
                    }
                    catch (Microsoft.Data.SqlClient.SqlException ex)
                    {
                        Console.WriteLine("Error SQL en VerificarUsuarioExistente: " + ex.Message);
                        retorna = -1; // Indicar error
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
                string query = "SELECT COUNT(*) FROM CorreosElectronicos WHERE CorreoElectronico = @CorreoElectronico";
                using (Microsoft.Data.SqlClient.SqlCommand comando = new Microsoft.Data.SqlClient.SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@CorreoElectronico", persona.correo);
                    try
                    {
                        int count = (int)comando.ExecuteScalar();
                        if (count == 0)
                        {
                            retorna = 1; // No existe
                        }
                        else
                        {
                            retorna = 0; // Sí existe
                        }
                    }
                    catch (Microsoft.Data.SqlClient.SqlException ex)
                    {
                        Console.WriteLine("Error SQL en VerificarCorreoExistente: " + ex.Message);
                        retorna = -1; // Indicar error
                    }
                }
            }
            return retorna;
        }

        public static int ObtenerIdSesionActual(string usuario)
        {
            int IdUsuario = -1;
            using (Microsoft.Data.SqlClient.SqlConnection conexion = conexionSql.ObtenerConexion())
            {
                // Si el login es insensible a mayúsculas, esta búsqueda también debería serlo
                string query = "SELECT Id FROM usuarios WHERE usuario COLLATE SQL_Latin1_General_CP1_CI_AS = @usuario COLLATE SQL_Latin1_General_CP1_CI_AS";
                using (Microsoft.Data.SqlClient.SqlCommand comando = new Microsoft.Data.SqlClient.SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@usuario", usuario);
                    try
                    {
                        object resultado = comando.ExecuteScalar();
                        if (resultado != null && resultado != DBNull.Value)
                        {
                            IdUsuario = Convert.ToInt32(resultado);
                        }
                    }
                    catch (Microsoft.Data.SqlClient.SqlException ex)
                    {
                        Console.WriteLine("Error SQL en ObtenerIdSesionActual: " + ex.Message);
                    }
                }
            }
            return IdUsuario;
        }
    }
}