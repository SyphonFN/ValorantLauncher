using Microsoft.Win32;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace RiotLauncher
{

    public partial class SettingsPage : Page
    {
        private readonly MainWindow mainWindow;

        public SettingsPage(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            Loaded += SettingsPage_Loaded;
            EmailTextBox.Text = Properties.Settings.Default.Email;
            PasswordTextBox.Password = Properties.Settings.Default.Password;
            Path.Content = Properties.Settings.Default.Path;

        }

        private void SettingsPage_Loaded(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;

            if (mainWindow != null && mainWindow.SettingsFrame != null)
            {
                mainWindow.SettingsFrame.IsHitTestVisible = true;
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            TranslateTransform translateTransform = new TranslateTransform(0, 100);

            this.RenderTransform = translateTransform;

            DoubleAnimation translateYAnimation = new DoubleAnimation
            {
                To = 0,
                Duration = TimeSpan.FromMilliseconds(200)
            };

            DoubleAnimation opacityAnimation = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromMilliseconds(200)
            };

            translateTransform.BeginAnimation(TranslateTransform.YProperty, translateYAnimation);
            this.BeginAnimation(UIElement.OpacityProperty, opacityAnimation);
        }

        private void CloseButton_CLick(object sender, RoutedEventArgs e)
        {
            if (mainWindow != null)
            {
                mainWindow.Avatar.IsHitTestVisible = true;
                mainWindow.SettingsFrame.IsHitTestVisible = false;
                mainWindow.MainFrame.IsHitTestVisible = true;
                mainWindow.SettingsFrame.Content = null;
                mainWindow.OverlayGrid.Visibility = Visibility.Hidden;
            }
            else
            {
            }
        }

        private void Email_TextChanged(object sender, TextChangedEventArgs e)
        {
            Properties.Settings.Default.Email = EmailTextBox.Text;
            Properties.Settings.Default.Save();
        }

        private void Password_PasswordChanged(object sender, TextChangedEventArgs e)
        {
            Properties.Settings.Default.Password = PasswordTextBox.Password;
            Properties.Settings.Default.Save();
        }

        private void ImportBuild_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                ValidateNames = false,
                CheckFileExists = false,
                CheckPathExists = true,
                FileName = "Select a Folder",
                Filter = ""
            };

            if (openFileDialog.ShowDialog() == true)
            {
                Properties.Settings.Default.Path = System.IO.Path.GetDirectoryName(openFileDialog.FileName);
                Properties.Settings.Default.Save();
            }
            Path.Content = Properties.Settings.Default.Path;
        }

        private void OPENREDIRECTPATH_Click(object sender, RoutedEventArgs e)
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string riotLauncherPath = System.IO.Path.Combine(appDataPath, "RiotLauncher");

            if (Directory.Exists(riotLauncherPath))
            {
                Process.Start("explorer.exe", riotLauncherPath);
            }
            else
            {
                MessageBox.Show("RiotLauncher directory not found.");
            }
        }

    }
}
