using System;
using System.Net;
using System.Net.Mail;
using System.Security;


namespace MailSender
{
    public static class EmailSendServiceClass
    {
        public static string SendEmail(string User, SecureString Password)
        {
            //TODO: Rewrite Exception handler. Pass exception to call function.
            try
            {
                using (var email = new MailMessage(Info.EmailFrom, Info.EmailTo))
                {
                    email.Subject = Info.EmailSubject;
                    email.Body = Info.EmailBody;

                    using (var client = new SmtpClient(Info.SMTPServerName))
                    {
                        var user = User;
                        var password = Password;
                        client.Credentials = new NetworkCredential(user, password);
                        client.EnableSsl = true;

                        client.Send(email);
                    }
                }
            }
            catch (Exception error)
            {
                return error.Message;
            }
            return "Ok";
        }
    }
}
