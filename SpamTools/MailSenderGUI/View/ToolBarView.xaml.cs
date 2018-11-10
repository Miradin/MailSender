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

namespace MailSenderGUI.View
{
    /// <summary>
    /// Логика взаимодействия для ToolBarView.xaml
    /// </summary>
    public partial class ToolBarView : UserControl
    {
        public event EventHandler OnAddServer;
        public event EventHandler OnDeleteServer;
        public event EventHandler OnEditServer;

        public event EventHandler OnAddRecipient;
        public event EventHandler OnDeleteRecipient;
        public event EventHandler OnEditRecipient;

        public ToolBarView()
        {
            InitializeComponent();
        }

        private void OnButtonclick(object Sender, RoutedEventArgs E)
        {
            if (!(Sender is Button button)) return;

            string c = ToolBarName.Text;
            switch (c)
            {
                case "Сервер":
                    if (button.Name as string == "Add")
                        OnAddServer?.Invoke(this, EventArgs.Empty);

                    if (button.Name as string == "Delete")
                        OnDeleteServer?.Invoke(this, EventArgs.Empty);

                    if (button.Name as string == "Edit")
                        OnEditServer?.Invoke(this, EventArgs.Empty);
                    break;
                case "Получатели":
                    if (button.Name as string == "Add")
                        OnAddRecipient?.Invoke(this, EventArgs.Empty);

                    if (button.Name as string == "Delete")
                        OnDeleteRecipient?.Invoke(this, EventArgs.Empty);

                    if (button.Name as string == "Edit")
                        OnEditRecipient?.Invoke(this, EventArgs.Empty);
                    break;
                default:
                    break;
            }
        }
    }
}
