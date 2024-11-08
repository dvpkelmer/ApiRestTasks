using ApiRestTask.Application.Interfaces;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;

namespace ApiRestTask.Application.Services
{

    public class EmailService : IEmailService
    {
        MailSettings Mail_Settings = null;
        public EmailService(IOptions<MailSettings> options)
        {
            Mail_Settings = options.Value;
        }
        public async Task<bool> SendMail(MailData Mail_Data)
        {

            try
            {
                var emailMessage = new MimeMessage();
                emailMessage.From.Add(new MailboxAddress(Mail_Settings.Name, Mail_Settings.EmailId));
                emailMessage.To.Add(new MailboxAddress(Mail_Data.EmailToName, Mail_Data.EmailToId));
                emailMessage.Subject = Mail_Data.EmailSubject;
                emailMessage.Body = new TextPart("plain") { Text = Mail_Data.EmailBody };

                using (var client = new SmtpClient())
                {
                    client.CheckCertificateRevocation = false;

                    await client.ConnectAsync(Mail_Settings.Host, Mail_Settings.Port, MailKit.Security.SecureSocketOptions.StartTlsWhenAvailable);
                    await client.AuthenticateAsync(Mail_Settings.UserName, Mail_Settings.Password);

                    await client.SendAsync(emailMessage);
                    await client.DisconnectAsync(true);
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"exception : {ex}");
                return false;
            }
        }
    }
}