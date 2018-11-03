using System;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;



namespace EmailSendLib
{
    public class MailService
    {
        private string _Login;
        private string _Password;

        private string _ServerAddress;
        private int _Port;

        private string _Body;
        private string _Subject;

        public MailService(string Login, string Password, string ServerAddress, int Port)
        {
            _Login = Login;
            _Password = Password;
            _ServerAddress = ServerAddress;
            _Port = Port;
        }

        public void MailText(string Subject, string Body)
        {
            _Subject = Subject;
            _Body = Body;
        }

        public void SendMail(string Mail, string Name)
        {
            try
            {
                using (var message = new MailMessage(Name, Mail)
                {
                    Subject = _Subject,
                    Body = _Body,
                    IsBodyHtml = false
                })
                {
                    using (var client = new SmtpClient(_ServerAddress, _Port)
                    {
                        EnableSsl = true,
                        Credentials = new NetworkCredential(_Login, _Password)
                    })
                    {
                        client.Send(message);
                    }
                }
            }
            catch (Exception error)
            {
                Trace.WriteLine(error.ToString());
                throw new InvalidOperationException("Ошибка отправки почты", error);
            }
        }
    }
}
