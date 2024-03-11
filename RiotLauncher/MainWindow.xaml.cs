using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Shapes;

namespace RiotLauncher
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SettingsPage settingsPage = new SettingsPage(this); 
            UserNameChange userNameChange = new UserNameChange(this); 
            PlayButton.FontSize = 25;


        }

        private void EllipseBackground_MouseEnter(object sender, MouseEventArgs e)
        {
            EllipseBackground.Fill = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));
        }

        private void EllipseBackground_MouseLeave(object sender, MouseEventArgs e)
        {
            EllipseBackground.Fill = Brushes.Black;
        }

        private void DynamicScrollBar_Scroll(object sender, EventArgs e)
        {

        }

        private void WatchNow_Click(object sender, RoutedEventArgs e)
        {
           string url = "https://www.youtube.com/watch?v=xKwuJ50EDLc";

            try
            {
                using (Process process = new Process())
                {
                    process.StartInfo.UseShellExecute = true;
                    process.StartInfo.FileName = url;
                    process.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        

        private void LaunchButton_Clicked(object sender, RoutedEventArgs e)
        {
            string path = Properties.Settings.Default.Path;
            string email = Properties.Settings.Default.Email;
            string password = Properties.Settings.Default.Password;

            RiotLauncher.Fortnite.Launch(path, email, password);
        }

        private void PlayButton_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is Button button)
            {
                Ellipse ellipse = button.Template.FindName("HoverEllipse", button) as Ellipse;
                Border border = button.Template.FindName("ButtonBorder", button) as Border;

                if (ellipse != null && border != null)
                {
                    DoubleAnimation animationWidth = new DoubleAnimation
                    {
                        To = 55,
                        Duration = TimeSpan.FromSeconds(0.1)
                    };
                    DoubleAnimation animationHeight = new DoubleAnimation
                    {
                        To = 55,
                        Duration = TimeSpan.FromSeconds(0.1)
                    };
                    ellipse.BeginAnimation(Ellipse.WidthProperty, animationWidth);
                    ellipse.BeginAnimation(Ellipse.HeightProperty, animationHeight);

                    DropShadowEffect dropShadowEffect = new DropShadowEffect
                    {
                        Color = Colors.IndianRed,
                        BlurRadius = 40, 
                        ShadowDepth = 0
                    };

                    border.Effect = dropShadowEffect;

                    DoubleAnimation blurRadiusAnimation = new DoubleAnimation
                    {
                        To = 80, 
                        Duration = TimeSpan.FromSeconds(0.1)
                    };
                    dropShadowEffect.BeginAnimation(DropShadowEffect.BlurRadiusProperty, blurRadiusAnimation);
                }
            }
        }

        private void PlayButton_MouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is Button button)
            {
                Ellipse ellipse = button.Template.FindName("HoverEllipse", button) as Ellipse;
                Border border = button.Template.FindName("ButtonBorder", button) as Border;

                if (ellipse != null && border != null)
                {
                    DoubleAnimation animationWidth = new DoubleAnimation
                    {
                        To = 50,
                        Duration = TimeSpan.FromSeconds(0.1)
                    };
                    DoubleAnimation animationHeight = new DoubleAnimation
                    {
                        To = 50,
                        Duration = TimeSpan.FromSeconds(0.1)
                    };
                    ellipse.BeginAnimation(Ellipse.WidthProperty, animationWidth);
                    ellipse.BeginAnimation(Ellipse.HeightProperty, animationHeight);

                    DropShadowEffect dropShadowEffect = new DropShadowEffect
                    {
                        Color = Colors.IndianRed,
                        BlurRadius = 80, 
                        ShadowDepth = 0
                    };

                    border.Effect = dropShadowEffect;

                    DoubleAnimation blurRadiusAnimation = new DoubleAnimation
                    {
                        To = 40, 
                        Duration = TimeSpan.FromSeconds(0.1)
                    };
                    dropShadowEffect.BeginAnimation(DropShadowEffect.BlurRadiusProperty, blurRadiusAnimation);
                }
            }
        }

        private void Avatar_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrame.Content is Avatar)
            {
                MainFrame.Content = null;
            }
            else
            {
                Avatar avatarPage = new Avatar(this); 
                MainFrame.Navigate(avatarPage);
            }
        }

        private void Gallery_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This feature is not available yet.");
        }

        private void SettingsFrame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            //blablablablablablablablbalbalbalbalbalbalbalb
        }

        private void UserNameChange_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            //blablablablablablablablbalbalbalbalbalbalbalb
        }
    }
}
