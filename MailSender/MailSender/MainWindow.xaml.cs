using System;
using System.Net;
using System.Net.Mail;
using System.Windows;


namespace MailSender
{
    public partial class MainWindow
    {
        public MainWindow() => InitializeComponent();

        private void SendButton_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var email = new MailMessage("shmachilin@yandex.ru", "shmachilin@gmail.com"))
                {
                    email.Subject = "Тема письма";
                    email.Body = "Тело письма";

                    using (var client = new SmtpClient("smtp.yandex.ru"))
                    {
                        var user = UserName_TextBox.Text;
                        var password = Password_PasswordBox.SecurePassword;
                        client.Credentials = new NetworkCredential(user, password);
                        client.EnableSsl = true;

                        client.Send(email);
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error!", MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }

            //MessageBox.Show("Почта отправлена успешно", "MailSender", MessageBoxButton.OK,
            //    MessageBoxImage.Information);
            var dlg = new SendCompleteDialog();
            dlg.Owner = this;
            dlg.ShowDialog();
        }
    }
}
