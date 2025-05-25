// Evento.cs
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using CalendarioApp;
using Microsoft.Data.SqlClient;

namespace ProyectoFinal.Calendario
{
    public class Evento
    {
        public int IdEvento { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public TimeSpan? Hora { get; set; }
        public Color? ColorPersonalizado { get; set; }

        public Evento(DateTime fecha, string descripcion, TimeSpan? hora = null, Color? color = null)
        {
            Fecha = fecha.Date;
            Descripcion = descripcion;
            Hora = hora;
            ColorPersonalizado = color;
        }

        public Evento(int idEvento, DateTime fecha, string descripcion, TimeSpan? hora, Color? color = null)
        {
            IdEvento = idEvento;
            Fecha = fecha.Date;
            Descripcion = descripcion;
            Hora = hora;
            ColorPersonalizado = color;
        }

        public override string ToString()
        {
            if (Hora.HasValue)
            {
                return $"{Hora.Value:hh\\:mm} - {Descripcion}";
            }
            return Descripcion;
        }

        public static int CrearEvento(Evento evento)
        {
            int retorna = 0;
            try
            {
                using (Microsoft.Data.SqlClient.SqlConnection conexion = conexionSql.ObtenerConexion())
                {
                    // CAMBIO AQUÍ: Se usa ColorEvento en lugar de ColorEventos
                    string query = @"
                INSERT INTO Eventos (IdUsuario, Descripcion, Fecha, Hora, ColorEvento)
                VALUES (@idUsuario, @descripcion, @fecha, @hora, @color)";

                    using (Microsoft.Data.SqlClient.SqlCommand comando = new Microsoft.Data.SqlClient.SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@idUsuario", SesionActual.IdUsuario);
                        comando.Parameters.AddWithValue("@descripcion", evento.Descripcion);
                        comando.Parameters.AddWithValue("@fecha", evento.Fecha.Date);
                        comando.Parameters.AddWithValue("@hora", (object)evento.Hora ?? DBNull.Value);

                        if (evento.ColorPersonalizado.HasValue)
                        {
                            Color c = evento.ColorPersonalizado.Value;
                            comando.Parameters.AddWithValue("@color", $"{c.A},{c.R},{c.G},{c.B}");
                        }
                        else
                        {
                            comando.Parameters.AddWithValue("@color", DBNull.Value);
                        }

                        retorna = comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Microsoft.Data.SqlClient.SqlException ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
            return retorna;
        }

        public static List<Evento> ObtenerEventosExistentes(DateTime fecha)
        {
            List<Evento> eventos = new List<Evento>();

            using (Microsoft.Data.SqlClient.SqlConnection conexion = conexionSql.ObtenerConexion())
            {
                // CAMBIO AQUÍ: Se usa ColorEvento en lugar de ColorEventos
                string query = "SELECT IdEvento, Descripcion, Hora, ColorEvento FROM Eventos WHERE CONVERT(date, Fecha) = @fecha AND IdUsuario = @IdUsuario AND Activo = 1";
                using (Microsoft.Data.SqlClient.SqlCommand comando = new Microsoft.Data.SqlClient.SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@fecha", fecha.Date);
                    comando.Parameters.AddWithValue("@IdUsuario", SesionActual.IdUsuario);

                    using (Microsoft.Data.SqlClient.SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Color? colorEvento = null;
                            // CAMBIO AQUÍ: Se lee de ColorEvento
                            if (reader["ColorEvento"] != DBNull.Value)
                            {
                                // CAMBIO AQUÍ: Se lee de ColorEvento
                                string colorString = reader["ColorEvento"].ToString();
                                string[] parts = colorString.Split(',');
                                if (parts.Length == 4)
                                {
                                    try
                                    {
                                        colorEvento = Color.FromArgb(int.Parse(parts[0]), int.Parse(parts[1]), int.Parse(parts[2]), int.Parse(parts[3]));
                                    }
                                    catch (FormatException ex)
                                    {
                                        Console.WriteLine($"Error al parsear color: {colorString} - {ex.Message}");
                                        colorEvento = null;
                                    }
                                }
                            }

                            Evento evento = new Evento(
                                Convert.ToInt32(reader["IdEvento"]),
                                fecha,
                                reader["Descripcion"].ToString(),
                                reader["Hora"] != DBNull.Value ? (TimeSpan?)reader["Hora"] : null,
                                colorEvento
                            );
                            eventos.Add(evento);
                        }
                    }
                }
            }
            return eventos;
        }

        public static int ActualizarEvento(Evento evento)
        {
            int retorna = 0;
            using (Microsoft.Data.SqlClient.SqlConnection conexion = conexionSql.ObtenerConexion())
            {
                // CAMBIO AQUÍ: Se usa ColorEvento en lugar de ColorEventos
                string query = "UPDATE Eventos SET Descripcion = @Descripcion, Hora = @Hora, ColorEvento = @Color WHERE IdEvento = @IdEvento";
                using (Microsoft.Data.SqlClient.SqlCommand comando = new Microsoft.Data.SqlClient.SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@IdEvento", evento.IdEvento);
                    comando.Parameters.AddWithValue("@Descripcion", evento.Descripcion);
                    comando.Parameters.AddWithValue("@Hora", (object)evento.Hora ?? DBNull.Value);

                    if (evento.ColorPersonalizado.HasValue)
                    {
                        Color c = evento.ColorPersonalizado.Value;
                        comando.Parameters.AddWithValue("@Color", $"{c.A},{c.R},{c.G},{c.B}");
                    }
                    else
                    {
                        comando.Parameters.AddWithValue("@Color", DBNull.Value);
                    }
                    retorna = comando.ExecuteNonQuery();
                }
            }
            return retorna;
        }

        public static int EliminarEvento(Evento evento)
        {
            int retorna = 0;
            using (Microsoft.Data.SqlClient.SqlConnection conexion = conexionSql.ObtenerConexion())
            {
                string query = "UPDATE Eventos SET Activo = 0 WHERE IdEvento = @IdEvento";
                using (Microsoft.Data.SqlClient.SqlCommand comando = new Microsoft.Data.SqlClient.SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@IdEvento", evento.IdEvento);
                    retorna = comando.ExecuteNonQuery();
                }
            }
            return retorna;
        }

        public static async Task<string> MostrarEventoDescripcion()
        {
            await Task.CompletedTask;
            return "Función MostrarEventoDescripcion necesita ser refactorizada.";
        }
    }
}