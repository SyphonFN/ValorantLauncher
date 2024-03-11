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

namespace RiotLauncher
{
    public partial class UserNameChange : Page
    {
        private readonly MainWindow mainWindow;

        public UserNameChange(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            Loaded += UserNameChange_Loaded;
            UserName.Text = Properties.Settings.Default.Name;
        }

        private void UserNameChange_Loaded(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;

            if (mainWindow != null && mainWindow.UserNameChangeFrame != null)
            {
                mainWindow.UserNameChangeFrame.IsHitTestVisible = true;
            }
        }

        private void Username_Changed(object sender, RoutedEventArgs e)
        {
            if(UserName.Text.Length > 14)
            {
                MessageBox.Show("Too long");
            }
            else
            {
                Properties.Settings.Default.Name = UserName.Text;
                Properties.Settings.Default.Save();
            }

        }

        private void ChangeUsername_Click(object sender, RoutedEventArgs e)
        {
            if (mainWindow != null)
            {
                mainWindow.Avatar.IsHitTestVisible = true;
                mainWindow.UserNameChangeFrame.IsHitTestVisible = false;
                mainWindow.MainFrame.IsHitTestVisible = true;
                mainWindow.UserNameChangeFrame.Content = null;
                mainWindow.OverlayGrid.Visibility = Visibility.Hidden;
            }
            else
            {
            }
        }

    }
}
