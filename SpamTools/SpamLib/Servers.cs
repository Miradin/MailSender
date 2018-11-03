using System;
using System.Collections.ObjectModel;
using PasswordLib;

namespace SpamLib
{
    public class Servers
    {
            public static readonly ObservableCollection<Server> Items =
            new ObservableCollection<Server>(new[]
            {
                new Server{ Name = "mail.ru", Domain = "smtp.mail.ru", Port = 25},
                new Server{ Name = "yandex.ru", Domain = "smtp.yandex.ru", Port = 25},
                new Server{ Name = "mail.com", Domain = "smtp.mail.com", Port = 25},
            });
    }

    public class Server
    {
        public string Name { get; set; }
        public string Domain { get; set; }
        public int Port { get; set; }
    }
}
