using NASA.ViewModels;
using System.Windows.Controls;

namespace NASA.Views
{
    /// <summary>
    /// Interaction logic for AsteroidsView.xaml
    /// </summary>
    public partial class AsteroidsView : UserControl
    {
        public AsteroidsView()
        {
            InitializeComponent();
            DataContext = new AsteroidsVM();
        }
    }
}
