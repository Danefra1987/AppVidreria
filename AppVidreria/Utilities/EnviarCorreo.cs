using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVidreria.Utilities
{
    internal class EnviarCorreo
    {
        public EnviarCorreo() { 
        
        }

        public async void EnviarCorreoCotizacion(string strSubjet, string strBody, string[] strCorreos)
        {
            if (Email.Default.IsComposeSupported)
            {

                string subject = "Hello friends!";
                string body = "Esto es una prueba de envio de correo";
                string[] recipients = new[] { "daneframetal@hotmail.com", "esneider_98@outlook.com" };

                var message = new EmailMessage
                {
                    Subject = subject,
                    Body = body,
                    BodyFormat = EmailBodyFormat.PlainText,
                    To = new List<string>(recipients)
                };

                ///Poner aqui el nombre del archivo pdf 
                string picturePath = Path.Combine(FileSystem.CacheDirectory, "memories.jpg");

                message.Attachments.Add(new EmailAttachment(picturePath));

                await Email.Default.ComposeAsync(message);
            }
        }
    }
}
