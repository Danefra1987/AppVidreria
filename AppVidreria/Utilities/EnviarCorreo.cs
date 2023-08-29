using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVidreria.Utilities
{
    public class EnviarCorreo
    {
        public EnviarCorreo() { 
        
        }

        public async void EnviarCorreoCotizacion(string strSubjet, string strBody, string[] strCorreos)
        {
            if (Email.Default.IsComposeSupported)
            {

                string subject = "Cotizacion";
                string body = "Esto es una prueba de envio de correo";
                string[] recipients = strCorreos;

                var message = new EmailMessage
                {
                    Subject = subject,
                    Body = body,
                    BodyFormat = EmailBodyFormat.PlainText,
                    To = new List<string>(recipients)
                };

                ///Poner aqui el nombre del archivo pdf 
                string picturePath = Path.Combine(FileSystem.CacheDirectory, "Cotizacion.pdf");

                message.Attachments.Add(new EmailAttachment(picturePath));

                await Email.Default.ComposeAsync(message);
            }
        }
    }
}
