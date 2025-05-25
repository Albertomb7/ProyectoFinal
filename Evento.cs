// Evento.cs
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks; 
using System.Windows.Forms; 
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

        // Constructor para nuevos eventos (sin IdEvento ya que es autoincremental)
        public Evento(DateTime fecha, string descripcion, TimeSpan? hora = null, Color? color = null)
        {
            Fecha = fecha.Date;
            Descripcion = descripcion;
            Hora = hora;
            ColorPersonalizado = color;
        }

        // Constructor para eventos existentes desde la BD (con IdEvento)
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
                Console.WriteLine($"Error SQL en CrearEvento: {ex.Message}"); // Log del error
                throw;
            }
            return retorna;
        }

        // Método para obtener eventos de UN SOLO DÍA
        public static List<Evento> ObtenerEventosExistentes(DateTime fecha)
        {
            List<Evento> eventos = new List<Evento>();
            using (Microsoft.Data.SqlClient.SqlConnection conexion = conexionSql.ObtenerConexion())
            {
                string query = @"SELECT IdEvento, Fecha, Descripcion, Hora, ColorEvento 
                                 FROM Eventos 
                                 WHERE IdUsuario = @IdUsuario 
                                   AND Activo = 1 
                                   AND Notificado = 0
                                   AND CONVERT(date, Fecha) = @FechaDia"; // Asegura de comparar solo la parte de la fecha

                using (Microsoft.Data.SqlClient.SqlCommand comando = new Microsoft.Data.SqlClient.SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@IdUsuario", SesionActual.IdUsuario);
                    comando.Parameters.AddWithValue("@FechaDia", fecha.Date);

                    try
                    {
                        using (Microsoft.Data.SqlClient.SqlDataReader reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Color? colorEvento = null;
                                if (reader["ColorEvento"] != DBNull.Value)
                                {
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
                                DateTime fechaEventoBD = Convert.ToDateTime(reader["Fecha"]);

                                Evento evento = new Evento(
                                    Convert.ToInt32(reader["IdEvento"]),
                                    fechaEventoBD,
                                    reader["Descripcion"].ToString(),
                                    reader["Hora"] != DBNull.Value ? (TimeSpan?)reader["Hora"] : null,
                                    colorEvento
                                );
                                eventos.Add(evento);
                            }
                        }
                    }
                    catch (Microsoft.Data.SqlClient.SqlException ex)
                    {
                        Console.WriteLine($"Error SQL en ObtenerEventosExistentes (un día): {ex.Message}"); // Log del error
                        throw;
                    }
                }
            }
            return eventos;
        }


        // Nuevo método para obtener eventos de un rango de fechas (mes completo)
        public static List<Evento> ObtenerEventosDelMes(int idUsuario, int año, int mes)
        {
            List<Evento> eventos = new List<Evento>();
            DateTime primerDiaDelMes = new DateTime(año, mes, 1);
            DateTime ultimoDiaDelMes = primerDiaDelMes.AddMonths(1).AddDays(-1);

            using (Microsoft.Data.SqlClient.SqlConnection conexion = conexionSql.ObtenerConexion())
            {
                string query = @"SELECT IdEvento, Fecha, Descripcion, Hora, ColorEvento 
                                 FROM Eventos 
                                 WHERE IdUsuario = @IdUsuario 
                                   AND Activo = 1 
                                   AND Fecha >= @PrimerDia 
                                   AND Fecha <= @UltimoDia";

                using (Microsoft.Data.SqlClient.SqlCommand comando = new Microsoft.Data.SqlClient.SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@IdUsuario", idUsuario);
                    comando.Parameters.AddWithValue("@PrimerDia", primerDiaDelMes.Date);
                    comando.Parameters.AddWithValue("@UltimoDia", ultimoDiaDelMes.Date);
                    try
                    {
                        using (Microsoft.Data.SqlClient.SqlDataReader reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Color? colorEvento = null;
                                if (reader["ColorEvento"] != DBNull.Value)
                                {
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
                                DateTime fechaEventoBD = Convert.ToDateTime(reader["Fecha"]);

                                Evento evento = new Evento(
                                    Convert.ToInt32(reader["IdEvento"]),
                                    fechaEventoBD,
                                    reader["Descripcion"].ToString(),
                                    reader["Hora"] != DBNull.Value ? (TimeSpan?)reader["Hora"] : null,
                                    colorEvento
                                );
                                eventos.Add(evento);
                            }
                        }
                    }
                    catch (Microsoft.Data.SqlClient.SqlException ex)
                    {
                        Console.WriteLine($"Error SQL en ObtenerEventosDelMes: {ex.Message}"); // Log del error
                        throw;
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
                string query = @"UPDATE Eventos 
                                 SET Descripcion = @Descripcion, Hora = @Hora, ColorEvento = @Color 
                                 WHERE IdEvento = @IdEvento";
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
                    try
                    {
                        retorna = comando.ExecuteNonQuery();
                    }
                    catch (Microsoft.Data.SqlClient.SqlException ex)
                    {
                        Console.WriteLine($"Error SQL en ActualizarEvento: {ex.Message}"); // Log del error
                        throw;
                    }
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
                    try
                    {
                        retorna = comando.ExecuteNonQuery();
                    }
                    catch (Microsoft.Data.SqlClient.SqlException ex)
                    {
                        Console.WriteLine($"Error SQL en EliminarEvento: {ex.Message}"); // Log del error
                        throw;
                    }
                }
            }
            return retorna;
        }

        // Esta función sigue necesitando una refactorización significativa si la vas a usar.
        // Por ahora, la dejo para que no cause errores de compilación si alguna parte del código la llama.
        public static async Task<string> MostrarEventoDescripcion()
        {
            await Task.CompletedTask; // Evita advertencia de método asíncrono sin await
            Console.WriteLine("Advertencia: La función MostrarEventoDescripcion fue llamada pero necesita ser refactorizada para funcionar correctamente.");
            return "Función MostrarEventoDescripcion necesita ser refactorizada.";
        }
    }
}