using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using System.Net.Mime;

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
        public static void EnviarCodigo(string correo)
        {
            string email = "yoempresa123@gmail.com";
            string password = "oquq imcw fjys lwhd";
            string toEmail = correo;
            string asunto = "Codigo de confirmacion";
        
            Random rand = new Random();
            int a = rand.Next(1000, 9000);
            
            CodigoEnviado = a.ToString();

            string html = $"<!DOCTYPE html>\r\n<html lang=\"en\">\r\n  <head>\r\n    <meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\">\r\n    <meta name=\"format-detection\" content=\"telephone=no\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n    <meta http-equiv=\"X-UA-Compatible\" content=\"IE=9; IE=8; IE=7; IE=EDGE\">\r\n    <meta name=\"x-apple-disable-message-reformatting\">\r\n  </head>\r\n  <body style=\"background-size: cover; background-attachment: fixed; background-repeat: no-repeat; font-family: -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, Helvetica, Arial, sans-serif, 'Apple Color Emoji', 'Segoe UI Emoji', 'Segoe UI Symbol'; box-sizing: border-box; background-color: #f6f4ef; color: #142d6f; height: 100%; line-height: 1.4; margin: 0; width: 100% !important; padding: 0;\">\r\n    <style>\r\n      body {{\r\n        padding: 0;\r\n        background-color: #F1F1F6;\r\n        background-size: cover;\r\n        background-attachment: fixed;\r\n        background-repeat: no-repeat;\r\n      }}\r\n      code {{\r\n        overflow: hidden;\r\n      }}\r\n      @media only screen and (max-width: 600px) {{\r\n        .inner-body {{\r\n          width: 100% !important;\r\n        }}\r\n        .content-cell {{\r\n          padding-left: 16px !important;\r\n          padding-right: 16px !important;\r\n        }}\r\n        .footer {{\r\n          width: 100% !important;\r\n        }}\r\n        .card-class {{\r\n          font-size: 16px !important;\r\n        }}\r\n        .card-message {{\r\n          font-size: 16px !important;\r\n        }}\r\n        .code-wrap {{\r\n          max-width: 100% !important;\r\n        }}\r\n        .code {{\r\n          font-size: 9px !important;\r\n        }}\r\n      }}\r\n      @media only screen and (max-width: 500px) {{\r\n        .button {{\r\n          width: 100% !important;\r\n        }}\r\n      }}\r\n    </style>\r\n    <table class=\"wrapper\" width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" role=\"presentation\" style=\"font-family: -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, Helvetica, Arial, sans-serif, 'Apple Color Emoji', 'Segoe UI Emoji', 'Segoe UI Symbol'; box-sizing: border-box; background-color: #f6f4ef; margin: 0; padding: 50px 0; width: 100%; -premailer-cellpadding: 0; -premailer-cellspacing: 0; -premailer-width: 100%;\">\r\n      <tr>\r\n        <td align=\"center\" style=\"font-family: -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, Helvetica, Arial, sans-serif, 'Apple Color Emoji', 'Segoe UI Emoji', 'Segoe UI Symbol'; box-sizing: border-box;\">\r\n          <table class=\"content\" style=\"font-family: -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, Helvetica, Arial, sans-serif, 'Apple Color Emoji', 'Segoe UI Emoji', 'Segoe UI Symbol'; box-sizing: border-box; margin: 0; padding: 0; width: 100%; -premailer-cellpadding: 0; -premailer-cellspacing: 0; -premailer-width: 100%; position: relative;\" width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" role=\"presentation\">\r\n            <tr>\r\n              <table class=\"header\" align=\"center\" width=\"570\" cellpadding=\"0\" cellspacing=\"0\" role=\"presentation\" style=\"font-family: -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, Helvetica, Arial, sans-serif, 'Apple Color Emoji', 'Segoe UI Emoji', 'Segoe UI Symbol'; box-sizing: border-box; padding: 0;\">\r\n              </table>\r\n            </tr>\r\n\r\n            <!-- Email Body -->\r\n            <tr>\r\n              <td style=\"font-family: -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, Helvetica, Arial, sans-serif, 'Apple Color Emoji', 'Segoe UI Emoji', 'Segoe UI Symbol'; box-sizing: border-box;\">\r\n                <table class=\"body\" align=\"center\" width=\"570\" cellpadding=\"0\" cellspacing=\"0\" role=\"presentation\" style=\"font-family: -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, Helvetica, Arial, sans-serif, 'Apple Color Emoji', 'Segoe UI Emoji', 'Segoe UI Symbol'; box-sizing: border-box; margin: 0 auto; padding: 0; text-align: center; width: 570px; -premailer-cellpadding: 0; -premailer-cellspacing: 0; -premailer-width: 570px; background-color: #ffffff; border-radius: 36px;\">\r\n                  <tr>\r\n                    <td class=\"content-cell\" style=\"font-family: -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, Helvetica, Arial, sans-serif, 'Apple Color Emoji', 'Segoe UI Emoji', 'Segoe UI Symbol'; box-sizing: border-box; padding: 35px;\">\r\n                      <p style=\"font-family: -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, Helvetica, Arial, sans-serif, 'Apple Color Emoji', 'Segoe UI Emoji', 'Segoe UI Symbol'; box-sizing: border-box; color: #142d6f; font-size: 16px; line-height: 1.5em; margin-top: 0; text-align: left;\">Bienvendio a la Agenda de evento. Para poder usar nuestros servicios solo debes de confirmar tu servicio con el codigo de segirudad.</p>\r\n                      <p style=\"font-family: -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, Helvetica, Arial, sans-serif, 'Apple Color Emoji', 'Segoe UI Emoji', 'Segoe UI Symbol'; box-sizing: border-box; color: #142d6f; font-size: 16px; line-height: 1.5em; margin-top: 0; text-align: left;\">El codigo es: {CodigoEnviado}</p>\r\n                      <p style=\"font-family: -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, Helvetica, Arial, sans-serif, 'Apple Color Emoji', 'Segoe UI Emoji', 'Segoe UI Symbol'; box-sizing: border-box; color: #142d6f; font-size: 16px; line-height: 1.5em; margin-top: 0; text-align: left;\">Los usos apicables de la agenda son el poder visualiar los eventos de un dia selecionadao el agregar eliminar y actualizar tus enventos en tiempo real gracias a nuestra base de datos en la nube puedes usar tu usuario desde cualquier computadora si tiense una duda no dudes en escribirnos para solucionarla. Si no has generado este codigo solo borra el email.</p>\r\n                     \r\n                    </td>\r\n                  </tr>\r\n                </table>\r\n              </td>\r\n            </tr>\r\n            <tr>\r\n              <td style=\"font-family: -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, Helvetica, Arial, sans-serif, 'Apple Color Emoji', 'Segoe UI Emoji', 'Segoe UI Symbol'; box-sizing: border-box;\">\r\n                <table class=\"footer\" align=\"center\" width=\"570\" cellpadding=\"0\" cellspacing=\"0\" role=\"presentation\" style=\"font-family: -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, Helvetica, Arial, sans-serif, 'Apple Color Emoji', 'Segoe UI Emoji', 'Segoe UI Symbol'; box-sizing: border-box; margin: 0 auto; padding: 0; text-align: center; width: 570px; -premailer-cellpadding: 0; -premailer-cellspacing: 0; -premailer-width: 570px;\">\r\n                  <tr>\r\n                    <td class=\"content-cell text-gray-500 text-12\" style=\"font-family: -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, Helvetica, Arial, sans-serif, 'Apple Color Emoji', 'Segoe UI Emoji', 'Segoe UI Symbol'; box-sizing: border-box; padding: 35px; padding-top: 16px;\" align=\"center\">\r\n                      <p style=\"font-family: -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, Helvetica, Arial, sans-serif, 'Apple Color Emoji', 'Segoe UI Emoji', 'Segoe UI Symbol'; box-sizing: border-box; line-height: 1.5em; margin-top: 0; color: #131c2e; font-size: 12px; text-align: center;\">\r\n                        © 2025 TecnoVision\r\n                        by <a href=\"https://spatie.be\" target=\"_blank\" style=\"font-family: -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, Helvetica, Arial, sans-serif, 'Apple Color Emoji', 'Segoe UI Emoji', 'Segoe UI Symbol'; box-sizing: border-box; color: #131c2e; text-decoration: underline;\">Grupo 5</a>\r\n                      </p>\r\n                    </td>\r\n                  </tr>\r\n                </table>\r\n              </td>\r\n            </tr>\r\n          </table>\r\n        </td>\r\n      </tr>\r\n    </table>\r\n  </body>\r\n</html>";

            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(html, Encoding.UTF8, MediaTypeNames.Text.Html);

            MailMessage mail = new MailMessage();
            mail.AlternateViews.Add(htmlView);
            mail.From = new MailAddress(email);
            mail.To.Add(toEmail); 
            mail.Subject = asunto;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587); 
            smtp.Credentials = new NetworkCredential(email, password);
            smtp.EnableSsl = true;
            smtp.Send(mail);
            
            
        }

    }
}
