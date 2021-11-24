using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Email
{
    public interface IEmailService
    {
        Task<bool> SendEmailAsync(ParametroEmail oParametroEmail, string smtp_alias = "");
    }

    public class EmailService : IEmailService
    {
        private string smtpServer;
        private int smtpPort;
        private string smtpPassword;
        private string fromEmailAddress;
        private string fromEmailAlias;
        private string DocumentPath;
        private bool smtpSsl;
        private bool useDefaulCredentials;
        protected MailMessage oMailMessage;
        protected SmtpClient oSmtpClient;

        public EmailService(IConfiguration configuration) 
        {
            this.smtpServer = configuration["Email:SMTP_Server"];
            this.smtpPort = int.Parse(configuration["Email:SMTP_Port"]);
            this.fromEmailAddress = configuration["Email:SMTP_User"];
            this.fromEmailAlias = configuration["Email:SMTP_Alias"];
            this.smtpPassword = configuration["Email:SMTP_Password"];
            this.smtpSsl = bool.Parse(configuration["Email:SMTP_Ssl"]);
            this.useDefaulCredentials = bool.Parse(configuration["Email:SMTP_DefaultCredential"]);
        }

        public async Task<bool> SendEmailAsync(ParametroEmail oParametroEmail, string smtp_alias = "")
        {
            ConfigurarEmail(oParametroEmail, smtp_alias);
            ConfiguracionClienteSmtp();

            return await Task.Run(() => SendEmailAsync());
        }

        public bool SendEmailAsync(ParametroEmail oParametroEmail, Action<ParametroEmail, bool, string> method)
        {
            ConfigurarEmail(oParametroEmail);
            ConfiguracionClienteSmtp();

            oSmtpClient.SendCompleted += (s, e) =>
            {
                SmtpClient_SendCompleted(s, e, method, oParametroEmail);
                Disposed();
            };

            return SendEmailAsync();
        }

        private void SmtpClient_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e, Action<ParametroEmail, bool, string> method, ParametroEmail oEmailParametroDto)
        {
            var flagEnvioCorrecto = (!e.Cancelled && e.Error == null);
            string mensaje = string.Empty;
            if (e.Error != null)
            {
                mensaje = e.Error.Message;
            }

            method.Invoke(oEmailParametroDto, flagEnvioCorrecto, mensaje);
        }

        #region Private Methods

        public void ConfigurarEmail(ParametroEmail oParametroEmail, string smtp_alias = "")
        {
            oMailMessage = new MailMessage();
            oParametroEmail.Para.Split('|').ToList().ForEach(x => oMailMessage.To.Add(x));
            oMailMessage.From = new MailAddress(fromEmailAddress, string.IsNullOrEmpty(smtp_alias) ? fromEmailAlias : smtp_alias);
            oMailMessage.Subject = oParametroEmail.Asunto;
            oMailMessage.Body = oParametroEmail.Mensaje;
            oMailMessage.IsBodyHtml = oParametroEmail.IsHtml;
            oMailMessage.BodyEncoding = Encoding.UTF8;
            oMailMessage.Priority = MailPriority.Normal;
            AdicionarCopia(oMailMessage, oParametroEmail.ConCopia);
        }

        public void AdicionarCopia(MailMessage oMailMessage, string toName)
        {
            if (!String.IsNullOrEmpty(toName))
            {
                if (toName.Contains('|'))
                {
                    foreach (var item in toName.Split('|'))
                    {
                        MailAddress copy = new MailAddress(item);
                        oMailMessage.CC.Add(copy);
                    }
                }
                else
                {
                    MailAddress copy = new MailAddress(toName);
                    oMailMessage.CC.Add(copy);
                }
            }
        }

        public void ConfiguracionClienteSmtp()
        {
            oSmtpClient = new SmtpClient(smtpServer, smtpPort);
            oSmtpClient.UseDefaultCredentials = useDefaulCredentials;

            if (!oSmtpClient.UseDefaultCredentials)
            {
                oSmtpClient.Credentials = new NetworkCredential(fromEmailAddress, smtpPassword);
            }

            if (smtpSsl)
            {
                oSmtpClient.EnableSsl = smtpSsl;
                oSmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            }

        }

        public bool SendEmailAsync()
        {
            try
            {
                oSmtpClient.SendAsync(oMailMessage, null);
                return true;
            }
            catch (Exception EX)
            {
                return false;
            }
        }

        protected void Disposed()
        {
            oSmtpClient.Dispose();
            oMailMessage.Dispose();
        }

        #endregion
    }
}
