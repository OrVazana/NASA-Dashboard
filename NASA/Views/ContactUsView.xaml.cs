using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace NASA.Views
{
    /// <summary>
    /// Interaction logic for ContactUsView.xaml
    /// </summary>
    public partial class ContactUsView : UserControl
    {
        public ContactUsView()
        {
            InitializeComponent();
        }

        private void orFacebookClick(object sender, RoutedEventArgs e)
        {
            Process.Start("explorer.exe","https://www.facebook.com/or.vazana.1");
        }
        private void orGithubClick(object sender, RoutedEventArgs e)
        {
            Process.Start("explorer.exe", "https://www.github.com/OrVazana");
        }
        private void orLinkedinClick(object sender, RoutedEventArgs e)
        {
            Process.Start("explorer.exe", "https://www.linkedin.com/in/OrVazana/");
        }
    }
}
