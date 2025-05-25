using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal
{
    public static class SesionActual
    {
        public static int IdUsuario { get; set; }
        public static string Usuario { get; set; }
        public static string Correo { get; set; }
        public static string Nombre { get; set; }
        public static bool ModoOscuroPreferido { get; set; }

        public static void LimpiarSesion()
        {
            IdUsuario = 0;
            Usuario = null;
            Correo = null;
            Nombre = null;
            ModoOscuroPreferido = true; // Default al limpiar
        }
    }
}