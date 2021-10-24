using NASA.ViewModels;
using System.Windows.Controls;

namespace NASA.Views
{
    /// <summary>
    /// Interaction logic for TodayPhotoView.xaml
    /// </summary>
    public partial class TodayPhotoView : UserControl
    {
        public TodayPhotoView()
        {
            InitializeComponent();
            DataContext = new TodayPhotoVM();
        }
    }
}
