using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderGUI.data
{
    public partial class SpamDatabase
    {
        static SpamDatabase() => Database.SetInitializer(new SpamDatabaseInitializer());
    }

    class SpamDatabaseInitializer : DropCreateDatabaseAlways<SpamDatabase>
    {
        protected override void Seed(SpamDatabase context)
        {
            base.Seed(context);
            if (!context.Emails.Any())
            {
                context.Emails.AddOrUpdate(
                    new Email { Title = "Письмо 1", Body = "Текст письма 1" },
                    new Email { Title = "Письмо 2", Body = "Hello World!" },
                    new Email { Title = "Письмо 3", Body = "Текст письма 3" },
                    new Email { Title = "Письмо 4", Body = "Текст письма 4" }
                );
                context.SaveChanges();
            }

            if (!context.Recipients.Any())
            {
                context.Recipients.AddOrUpdate(
                    new Recipient { Name = "Ivanov", Email = "ivanov@mail.ru" },
                    new Recipient { Name = "Petrov", Email = "petrov@mail.ru" },
                    new Recipient { Name = "Sidorov", Email = "sidorov@mail.ru" }
                );
                context.SaveChanges();
            }

            if (!context.Senders.Any())
            {
                context.Senders.AddOrUpdate(
                    new Sender { Name = "Sender1", Email = "sender1@mail.ru", Login = "sender1", Password = "password1" },
                    new Sender { Name = "Sender2", Email = "sender2@yandex.ru", Login = "sender2", Password = "password2" },
                    new Sender { Name = "Sender3", Email = "sender3@google.com", Login = "sender3", Password = "password3" },
                    new Sender { Name = "Sender4", Email = "sender4@ya.ru", Login = "sender4", Password = "password4" }
                    );
                context.SaveChanges();
            }

            if (!context.Servers.Any())
            {
                context.Servers.AddOrUpdate(
                    new Server { Name = "Mail", Address = "smtp.mail.ru", Port = "25", UseSSL = true },
                    new Server { Name = "Яндекс", Address = "smtp.yandex.ru", Port = "25", UseSSL = true },
                    new Server { Name = "gMail", Address = "smtp.gmail.com", Port = "25", UseSSL = true }
                    );
                context.SaveChanges();
            }

            if (!context.MailingLists.Any())
            {
                context.MailingLists.AddOrUpdate(
                    new MailingList
                    {
                        Name = "Mail list to all",
                        Recipients = context.Recipients.ToArray(),
                    },
                    new MailingList
                    {
                        Name = "Ivanov mail list",
                        Recipients = { context.Recipients.First() }
                    });
                context.SaveChanges();
            }

            if (!context.SchedulerTasks.Any())
            {
                context.SchedulerTasks.AddOrUpdate(
                    new SchedulerTask
                    {
                        Name = "Shedlue future 20",
                        Emails = context.Emails.Take(1).ToArray(),
                        MailingList = context.MailingLists.First(),
                        Time = DateTime.Now.Add(TimeSpan.FromMinutes(20)),
                        Server = context.Servers.OrderBy(e => e.Id).First(),
                        Sender = context.Senders.OrderBy(e => e.Id).First()
                    },
                    new SchedulerTask
                    {
                        Name = "Shedlue past 20",
                        Emails = context.Emails.OrderBy(e => e.Id).Skip(1).Take(2).ToArray(),
                        MailingList = context.MailingLists.OrderBy(e => e.Id).Skip(1).First(),
                        Time = DateTime.Now.Subtract(TimeSpan.FromMinutes(20)),
                        Server = context.Servers.OrderBy(e => e.Id).Skip(1).First(),
                        Sender = context.Senders.OrderBy(e => e.Id).Skip(1).First(),
                    },
                    new SchedulerTask
                    {
                        Name = "Shedlue future 5",
                        Emails = context.Emails.OrderBy(e => e.Id).Skip(2).Take(2).ToArray(),
                        MailingList = context.MailingLists.First(),
                        Time = DateTime.Now.Add(TimeSpan.FromMinutes(5)),
                        Server = context.Servers.OrderBy(e => e.Id).Skip(1).First(),
                        Sender = context.Senders.OrderBy(e => e.Id).Skip(2).First(),
                    });
                context.SaveChanges();
            }

        }
    }
}
