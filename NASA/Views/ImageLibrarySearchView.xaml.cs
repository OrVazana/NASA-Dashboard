using System.Windows.Controls;
using NASA.ViewModels;

namespace NASA.Views
{
    /// <summary>
    /// Interaction logic for ImageLibrarySearchView.xaml
    /// </summary>
    public partial class ImageLibrarySearchView : UserControl
    {
        public ImageLibrarySearchView()
        {
            InitializeComponent();
            DataContext = new ImageLibrarySearchVM();
        }
    }
}
