using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SpamLib;
using System.Diagnostics;


namespace MailSenderGUI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Sender.ToolBarName.Text = "Получатели";
            Sender.Source.ItemsSource = Senders.Items;
            Sender.Source.SelectedIndex = 0;

            Server.ToolBarName.Text = "Сервер";
            Server.Source.ItemsSource = Servers.Items;
            Server.Source.SelectedIndex = 0;
            
        }


        private void OnExitClick(object Sender, RoutedEventArgs E)
        {
            Close();
        }

        private void GoToPlannerButton_OnClick(object Sender, RoutedEventArgs E)
        {
            MainTabControl.SelectedItem = TimePlannerTab;
        }

        private void OnNextPressed(object Sender, EventArgs E)
        {
            if (MainTabControl.SelectedIndex < MainTabControl.Items.Count - 1)
                MainTabControl.SelectedIndex++;
        }

        private void OnPrevPressed(object Sender, EventArgs E)
        {
            if (MainTabControl.SelectedIndex > 0)
                MainTabControl.SelectedIndex--;
        }

        private void OnAddServer(object Sender, EventArgs E)
        {
            Trace.WriteLine("Add Server button");
        }

        private void OnDeleteServer(object Sender, EventArgs E)
        {
            Trace.WriteLine("Delete Server button");
        }

        private void OnEditServer(object Sender, EventArgs E)
        {
            Trace.WriteLine("Edit Server button");
        }

        private void OnAddRecipient(object Sender, EventArgs E)
        {
            Trace.WriteLine("Add Recipient button");
        }

        private void OnDeleteRecipient(object Sender, EventArgs E)
        {
            Trace.WriteLine("Delete Recipient button");
        }

        private void OnEditRecipient(object Sender, EventArgs E)
        {
            Trace.WriteLine("Edit Recipient button");
        }

    }
}
