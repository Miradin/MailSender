using System;

namespace MailSender
{
    static class Info
    {
        //public static int GetServerPort() { return 465; }
        public static int ServerPort = 465;
        public static string SMTPServerName = "smtp.yandex.ru";
        public static string EmailFrom = "shmachilin@yandex.ru";
        public static string EmailTo = "shmachilin@gmail.com";
        public static string EmailSubject = "Greetings";
        public static string EmailBody = "Hello, I am your new letter.";
        public static string ErrorCantSend = "Error!";
    }
}
