using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace ProyectoFinal
{
    public class enviarCodigo
    {
        //Variable publica para compararla en el formulario
        public static string CodigoEnviado;
        

        //Creacion del atributo codigo
        public class CodigoVerificacion { 
        public string codigo { get; set; }

            public CodigoVerificacion() { }
               
        public CodigoVerificacion(string codigo)
        {
            this.codigo = codigo;
        }

        }


        //Funcion que envia el correo
        public static void EnviarCorreo(string correo)
        {
            string email = "yoempresa123@gmail.com";
            string password = "oquq imcw fjys lwhd";
            string toEmail = correo;
            string asunto = "Codigo de confirmacion";
        
            Random rand = new Random();
            int a = rand.Next(1000, 9000);
            
            CodigoEnviado = a.ToString();

            string body = $"El codigo es {CodigoEnviado}";

            MailMessage mail = new MailMessage(); 
            mail.From = new MailAddress(email);
            mail.To.Add(toEmail); 
            mail.Subject = asunto; 
            mail.Body = body;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587); 
            smtp.Credentials = new NetworkCredential(email, password);
            smtp.EnableSsl = true;
            smtp.Send(mail);
            
            
        }

    }
}
