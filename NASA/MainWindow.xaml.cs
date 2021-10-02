using MaterialDesignThemes.Wpf;
using NASA.ViewsModels;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace NASA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly PaletteHelper _paletteHelper = new PaletteHelper();
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainViewModel();
        }
        #region top Bar buttons 
        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void ButtonMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void ButtonMaximaize_Click(object sender, RoutedEventArgs e)
        {
            Window window = Application.Current.MainWindow;
            if (window.WindowState == System.Windows.WindowState.Maximized)
                window.WindowState = System.Windows.WindowState.Normal;
            else
                window.WindowState = System.Windows.WindowState.Maximized;
        }
        private void ButtunTheme_Click(object sender, RoutedEventArgs e)
        {
            {
                ITheme theme = _paletteHelper.GetTheme();
                IBaseTheme baseTheme = (bool)(sender as ToggleButton).IsChecked ? new MaterialDesignDarkTheme() : new MaterialDesignLightTheme();
                theme.SetBaseTheme(baseTheme);
                _paletteHelper.SetTheme(theme);
            }

        }
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        #endregion

    }
}
