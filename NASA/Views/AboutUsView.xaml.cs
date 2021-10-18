using System;
using System.Collections.Generic;
using System.Diagnostics;
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
