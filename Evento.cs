// Evento.cs
using System;

namespace ProyectoFinal.Calendario // OJO: Si pusiste Evento.cs en otra carpeta, ajusta este namespace
{
    public class Evento
    {
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public TimeSpan? Hora { get; set; } // Opcional: para la hora del evento

        // Constructor
        public Evento(DateTime fecha, string descripcion, TimeSpan? hora = null)
        {
            Fecha = fecha.Date; // Guardamos solo la fecha, sin la hora, para comparaciones más sencillas
            Descripcion = descripcion;
            Hora = hora;
        }

        public override string ToString()
        {
            if (Hora.HasValue)
            {
                return $"{Hora.Value:hh\\:mm} - {Descripcion}";
            }
            return Descripcion;
        }
    }
}