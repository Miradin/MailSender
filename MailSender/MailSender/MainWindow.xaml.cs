using System;
using System.Windows;


namespace MailSender
{
    public partial class MainWindow
    {
        public MainWindow() => InitializeComponent();
        public string Subject { get { return Subject_TextBox.Text; } }
        public string EmailBody { get { return EmailBody_TextBox.Text; } }

        private void SendButton_OnClick(object sender, RoutedEventArgs e)
        {
            string answer = EmailSendServiceClass.SendEmail(UserName_TextBox.Text, Password_PasswordBox.SecurePassword);
            if (answer != "Ok")
            {
                var errdlg = new ShowError(answer);
                errdlg.Owner = this;
                errdlg.ShowDialog();
            }
            else
            {
                //MessageBox.Show("Почта отправлена успешно", "MailSender", MessageBoxButton.OK,
                //    MessageBoxImage.Information);
                var dlg = new SendCompleteDialog();
                dlg.Owner = this;
                dlg.ShowDialog();
            }
        }
    }    
}
