// Evento.cs
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using CalendarioApp; // agrege este nuevo using, deja usar los colores 


namespace ProyectoFinal.Calendario // OJO: Si pusiste Evento.cs en otra carpeta, ajusta este namespace
{
    public class Evento
    {
        public int IdEvento { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public TimeSpan? Hora { get; set; } // Opcional: para la hora del evento
        public Color? ColorPersonalizado { get; set; } // color xd

        // Constructor
        public Evento(int IdEvento, DateTime fecha, string descripcion, TimeSpan? hora = null, Color? color = null)
        {
            Fecha = fecha; // Guardamos solo la fecha, sin la hora, para comparaciones más sencillas
            Descripcion = descripcion;
            Hora = hora;
            ColorPersonalizado = color; 
        }

        // Constructor para eventos existentes (con Id)
        public Evento(int idEvento, DateTime fecha, string descripcion, TimeSpan? hora)
        {
            IdEvento = idEvento;
            Fecha = fecha;
            Descripcion = descripcion;
            Hora = hora;

        }

        // Guardamos solo la fecha, sin la hora, para comparaciones más sencillas
        public override string ToString()
        {
            if (Hora.HasValue)
            {
                return $"{Hora.Value:hh\\:mm} - {Descripcion}";
            }
            return Descripcion;
        }


        //Crea un evento nuevo en la base de datos
        public static int CrearEvento(Evento evento)
        {
            int retorna = 0;
            try
            {
                using (Microsoft.Data.SqlClient.SqlConnection conexion = conexionSql.ObtenerConexion())
                {
                    string query = @"
                INSERT INTO Eventos (IdUsuario, Descripcion, Fecha, Hora) 
                VALUES (@idUsuario, @descripcion, @fecha, @hora)";

                    using (Microsoft.Data.SqlClient.SqlCommand comando = new Microsoft.Data.SqlClient.SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@idUsuario", SesionActual.IdUsuario);
                        comando.Parameters.AddWithValue("@descripcion", evento.Descripcion);
                        comando.Parameters.AddWithValue("@fecha", evento.Fecha.Date); //guarda solo la parte de fecha
                        comando.Parameters.AddWithValue("@hora", (object)evento.Hora ?? DBNull.Value);
                       

                        retorna = comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Microsoft.Data.SqlClient.SqlException)
            {
                throw; // o puedes loguearlo si lo prefieres
            }

            return retorna;
        }


        // Leer evento existentes
        public static List<Evento> ObtenerEventosExistentes(DateTime fecha)
        {
            List<Evento> eventos = new List<Evento>();

            using (Microsoft.Data.SqlClient.SqlConnection conexion = conexionSql.ObtenerConexion())
            {
                string query = "SELECT IdEvento, Descripcion, Hora FROM Eventos WHERE CONVERT(date, Fecha) = @fecha AND IdUsuario = @IdUsuario AND Activo = 1";
                using (Microsoft.Data.SqlClient.SqlCommand comando = new Microsoft.Data.SqlClient.SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@fecha", fecha.Date);
                    comando.Parameters.AddWithValue("@IdUsuario", SesionActual.IdUsuario);

                    using (Microsoft.Data.SqlClient.SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Evento evento = new Evento(
                            Convert.ToInt32(reader["IdEvento"]),
                            fecha,
                            reader["Descripcion"].ToString(),
                            reader["Hora"] != DBNull.Value ? (TimeSpan?)reader["Hora"] : null
                            );

                            eventos.Add(evento);
                        }
                    }
                }
            }
            return eventos;
        }


        //FUNCION PARA ACTUALIZAR UN EVENTO EXITOSO A LA BASE DE DATOS
        public static int ActualizarEvento(Evento evento)
        {
            int retorna = 0;
            using (Microsoft.Data.SqlClient.SqlConnection conexion = conexionSql.ObtenerConexion())
            {
                string query = "update Eventos set Descripcion = @Descripcion, Hora = @Hora  where IdEvento = @IdEvento";
                using (Microsoft.Data.SqlClient.SqlCommand comando = new Microsoft.Data.SqlClient.SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@IdEvento", evento.IdEvento);
                    comando.Parameters.AddWithValue("@Descripcion", evento.Descripcion);
                    comando.Parameters.AddWithValue("@Hora", (object)evento.Hora ?? DBNull.Value);
                    retorna = comando.ExecuteNonQuery();
                }
            }
            return retorna;
        }


        //FUNCION PARA ELIMINAR EVENTOS DE LA BASE DE DATOS 
        public static int EliminarEvento(Evento evento)
        {
            int retorna = 0;
            using (Microsoft.Data.SqlClient.SqlConnection conexion = conexionSql.ObtenerConexion())
            {
                string query = "update Eventos set Activo = 0 where IdEvento = @IdEvento";
                using (Microsoft.Data.SqlClient.SqlCommand comando = new Microsoft.Data.SqlClient.SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@IdEvento", evento.IdEvento);
                    retorna = comando.ExecuteNonQuery();
                }
            }
            return retorna;
        }

        //Mostrar solo la descripcion del evento
         public static async Task<string> MostrarEventoDescripcion()
        {
            List<Evento> eventos = new List<Evento>();
            string descripcion = string.Empty;
            string resultado = string.Empty;
            using (Microsoft.Data.SqlClient.SqlConnection conexion = conexionSql.ObtenerConexion())
            {
                
                using (Microsoft.Data.SqlClient.SqlCommand comando = new Microsoft.Data.SqlClient.SqlCommand())
                {
                    string query = "SELECT Descripcion FROM Eventos WHERE '"+SesionActual.IdUsuario+"'";

                    using (Microsoft.Data.SqlClient.SqlDataReader reader = comando.ExecuteReader())
                    {
                        var valor = await reader.ReadAsync();
                        resultado = valor.ToString() ?? string.Empty;
                    }
                }
            }
            return resultado;
        }
    }
}
