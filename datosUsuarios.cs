using System;
using System.Collections.Generic;
// using System.Globalization; // No se usa directamente en este código Lo borrarmos xd
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// using System.Windows.Forms; // No se usa directamente en este código x2
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
            public bool ModoOscuro { get; set; } // Necesario para la preferencia de tema

            public Persona()
            {
                ModoOscuro = true; // Valor por defecto (ej. modo oscuro activado)
            }

            // Constructor actualizado
            public Persona(int id, string usuario, string nombre, string ePass, string correo, bool modoOscuro)
            {
                this.id = id;
                this.usuario = usuario;
                this.nombre = nombre;
                this.ePass = ePass;
                this.correo = correo;
                this.ModoOscuro = modoOscuro;
            }
        }

        // Crea usuario nuevo en la base de datos fadfdsdfdfd
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
                throw; // O maneja el error de otra forma
            }
            return retorna;
        }

        // Actualizar datos de usuario
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

        // --- ESTE ES EL MÉTODO QUE TE ESTÁ DANDO ERROR ---
        // --- ASEGÚRATE DE QUE ESTÉ EXACTAMENTE ASÍ EN TU ARCHIVO ---
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
                        throw; // O manejar el error
                    }
                }
            }
            return retorna;
        }
        // --- FIN DEL MÉTODO ActualizarPreferenciasTema ---

        public static bool ObtenerPreferenciasTema(int idUsuario)
        {
            bool modoOscuro = true; // Valor por defecto si no se encuentra o hay error
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
                string query = ("DELETE FROM usuarios WHERE id = @id");
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
                string query = @"
                    SELECT u.Id, u.usuario, u.nombre, u.ePass, u.ModoOscuro, ce.CorreoElectronico
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
                                    usuario = reader["usuario"].ToString(), // Tomar de la BD para consistencia
                                    nombre = reader["nombre"].ToString(),
                                    ePass = reader["ePass"].ToString(),
                                    ModoOscuro = reader["ModoOscuro"] != DBNull.Value ? Convert.ToBoolean(reader["ModoOscuro"]) : true,
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
                    catch (Exception ex)
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
                string query = "SELECT COUNT(*) FROM usuarios WHERE usuario COLLATE Latin1_General_CS_AS = @usuario";
                using (Microsoft.Data.SqlClient.SqlCommand comando = new Microsoft.Data.SqlClient.SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@usuario", persona.usuario);
                    try
                    {
                        int count = (int)comando.ExecuteScalar();
                        retorna = (count == 0) ? 1 : 0; // 1 = no existe, 0 = sí existe
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
                        retorna = (count == 0) ? 1 : 0; // 1 = no existe, 0 = sí existe
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