// Evento.cs
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CalendarioApp; // agrege este nuevo using, deja usar los colores 


namespace ProyectoFinal.Calendario // OJO: Si pusiste Evento.cs en otra carpeta, ajusta este namespace
{
    public class Evento
    {
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public TimeSpan? Hora { get; set; } // Opcional: para la hora del evento
        public Color? ColorPersonalizado { get; set; } // color xd

        // Constructor
        public Evento(DateTime fecha, string descripcion, TimeSpan? hora = null, Color? color = null)
        {
            Fecha = fecha; // Guardamos solo la fecha, sin la hora, para comparaciones más sencillas
            Descripcion = descripcion;
            Hora = hora;
            ColorPersonalizado = color; 
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

                    string query = ("Insert into Eventos values('" + SesionActual.IdUsuario + "', '" + evento.Descripcion + "', '" + evento.Fecha + "','" + evento.Hora + "', '" + "activo" + "')");
                    Microsoft.Data.SqlClient.SqlCommand comando = new Microsoft.Data.SqlClient.SqlCommand(query, conexion);
                    retorna = comando.ExecuteNonQuery();

                    
                }
            }
            catch (Microsoft.Data.SqlClient.SqlException)
            {
                throw;
            }
            return retorna;
        }


        

        }
    }
