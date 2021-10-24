using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace NASA.Views
{
    /// <summary>
    /// Interaction logic for AboutUsView.xaml
    /// </summary>
    public partial class AboutUsView : UserControl
    {
        public AboutUsView()
        {
            InitializeComponent();
        }
        private void orFacebookClick(object sender, RoutedEventArgs e)
        {
            Process.Start("explorer.exe", "https://www.facebook.com/or.vazana.1");
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
