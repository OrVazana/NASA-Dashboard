using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using NASA.ViewModels;

namespace NASA.Views
{
    /// <summary>
    /// Interaction logic for ImageLibrarySearchView.xaml
    /// </summary>
    public partial class ImageLibrarySearchView : UserControl
    {
        ImageLibrarySearchVM Current { get; set; }
        public ImageLibrarySearchView()
        {
            InitializeComponent();
            Current = new ImageLibrarySearchVM();
            DataContext = Current;
        }
        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            string search = searchBox.Text;
            Current.search(search);
        }
    }
}
