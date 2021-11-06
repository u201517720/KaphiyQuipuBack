using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;

namespace WebGYM.Common
{
    public class EmailManager
    {
        public bool SendEmailBienvenida(string path, string asunto, string nombre, string correo, string usuario, string clave, string url, string from, string logo)
        {
            var html = File.ReadAllText(path);

            string cuerpo = html.Replace("{nombre}", nombre);
            string cuerpo2 = cuerpo.Replace("{usuario}", usuario);
            string cuerpo3 = cuerpo2.Replace("{clave}", clave);
            string cuerpo4 = cuerpo3.Replace("{url}", url);
            string cuerpo5 = cuerpo4.Replace("{logo}", url + logo);

            return enviarCorreo(correo, asunto, cuerpo5, from);
        }

        public bool enviarCorreo(string correo, string asunto, string cuerpo, string from, List<string> Attachments = null)
        {
            bool response = false;
            MailMessage mm = new MailMessage();

            try
            {
                if (Attachments != null)
                {
                    Attachments.ForEach(x => mm.Attachments.Add(new Attachment(x)));
                }

                SmtpClient smpt = new SmtpClient();
                mm.From = new MailAddress(from);
                mm.To.Add(correo);
                mm.Subject = asunto;
                mm.IsBodyHtml = true;
                mm.Body = cuerpo;
                smpt.Host = "smtp.ethereal.email";
                smpt.Port = 587;
                smpt.Credentials = new System.Net.NetworkCredential("kiel.ferry89@ethereal.email", "RfdnYn1BzDugkPv6fP");
                smpt.EnableSsl = false;
                smpt.Send(mm);
                response = true;
            }
            catch (Exception ex)
            {
                response = false;
            }
            return response;
        }
    }
}
