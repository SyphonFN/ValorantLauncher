using System.Diagnostics;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace RiotLauncher
{
    public partial class Avatar : Page
    {
        private readonly MainWindow mainWindow;

        public Avatar(MainWindow mainWindow)
        {
            InitializeComponent();
            if(Properties.Settings.Default.Name != "")
            {
                UserNameText.Text = Properties.Settings.Default.Name;
            }
            this.mainWindow = mainWindow;

        }

        private void AccountDetailsButton_Click(object sender, RoutedEventArgs e)
        {
            string url = "https://authenticate.riotgames.com/?client_id=accountodactyl-prod&method=riot_identity&platform=web&redirect_uri=https%3A%2F%2Fauth.riotgames.com%2Fauthorize%3Facr_values%3Durn%253Ariot%253Agold%26client_id%3Daccountodactyl-prod%26redirect_uri%3Dhttps%253A%252F%252Faccount.riotgames.com%252Foauth2%252Flog-in%26response_type%3Dcode%26scope%3Dopenid%2520email%2520profile%2520riot%253A%252F%252Friot.atlas%252Faccounts.edit%2520riot%253A%252F%252Friot.atlas%252Faccounts%252Fpassword.edit%2520riot%253A%252F%252Friot.atlas%252Faccounts%252Femail.edit%2520riot%253A%252F%252Friot.atlas%252Faccounts.auth%2520riot%253A%252F%252Fthird_party.revoke%2520riot%253A%252F%252Fthird_party.query%2520riot%253A%252F%252Fforgetme%252Fnotify.write%2520riot%253A%252F%252Friot.authenticator%252Fauth.code%2520riot%253A%252F%252Friot.authenticator%252Fauthz.edit%2520riot%253A%252F%252Frso%252Fmfa%252Fdevice.write%2520riot%253A%252F%252Friot.authenticator%252Fidentity.add%26state%3D56a86975-af3b-4c01-9d50-e5e77d2dd64b&security_profile=high";

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

        private void AccountSecurityButton_Click(object sender, RoutedEventArgs e)
        {
            string url = "https://authenticate.riotgames.com/?client_id=accountodactyl-prod&method=riot_identity&platform=web&redirect_uri=https%3A%2F%2Fauth.riotgames.com%2Fauthorize%3Facr_values%3Durn%253Ariot%253Agold%26client_id%3Daccountodactyl-prod%26redirect_uri%3Dhttps%253A%252F%252Faccount.riotgames.com%252Foauth2%252Flog-in%26response_type%3Dcode%26scope%3Dopenid%2520email%2520profile%2520riot%253A%252F%252Friot.atlas%252Faccounts.edit%2520riot%253A%252F%252Friot.atlas%252Faccounts%252Fpassword.edit%2520riot%253A%252F%252Friot.atlas%252Faccounts%252Femail.edit%2520riot%253A%252F%252Friot.atlas%252Faccounts.auth%2520riot%253A%252F%252Fthird_party.revoke%2520riot%253A%252F%252Fthird_party.query%2520riot%253A%252F%252Fforgetme%252Fnotify.write%2520riot%253A%252F%252Friot.authenticator%252Fauth.code%2520riot%253A%252F%252Friot.authenticator%252Fauthz.edit%2520riot%253A%252F%252Frso%252Fmfa%252Fdevice.write%2520riot%253A%252F%252Friot.authenticator%252Fidentity.add%26state%3D67d1bd2e-a3f0-43ee-8c27-96faa2044c5b&security_profile=high";

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

        private void UsernameChange_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.MainFrame.Content = null;
            mainWindow.OverlayGrid.Visibility = Visibility.Visible;
            mainWindow.Avatar.IsHitTestVisible = false;
            mainWindow.MainFrame.IsHitTestVisible = false;


            if (mainWindow != null && mainWindow.UserNameChangeFrame != null)
            {
                mainWindow.UserNameChangeFrame.Navigate(new UserNameChange(mainWindow));
            }
        }
        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.MainFrame.Content = null;
            mainWindow.OverlayGrid.Visibility = Visibility.Visible;
            mainWindow.Avatar.IsHitTestVisible = false;
            mainWindow.MainFrame.IsHitTestVisible = false;


            if (mainWindow != null && mainWindow.SettingsFrame != null)
            {
                mainWindow.SettingsFrame.Navigate(new SettingsPage(mainWindow));
            }
        }

        private void SIGNOUTBUTTON_Click(object sender, RoutedEventArgs e)
        {
             MessageBox.Show("This feature is not available yet.");
        }

        private void EXITBUTTON_Click(object sender, RoutedEventArgs e)
        {
               Application.Current.Shutdown();
        }


    }

    public class MarginFromWidthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double width)
            {
                double offset = 5; 
                return new Thickness(width + offset, 21, 100, 250);
            }

            return new Thickness(95, 21, 100, 250); 
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
