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
    public class enviarCorreos
    {
        public static void EnviarCorreo(string correo)
        {
            string email = "yoempresa123@gmail.com"; 
            string password = "oquq imcw fjys lwhd"; 
            string toEmail = correo; 
            string asunto = "Codigo de confirmacion"; 
            string body = "El codgio es 12345";

            MailMessage mail = new MailMessage(); 
            mail.From = new MailAddress(email);
            mail.To.Add(toEmail); 
            mail.Subject = asunto; 
            mail.Body = body;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587); 
            smtp.Credentials = new NetworkCredential(email, password);
            smtp.EnableSsl = true;
            smtp.Send(mail);
            codigoDeVerificacion VerificacionForm = new codigoDeVerificacion();
            VerificacionForm.Show();
            
        }

    }
}
