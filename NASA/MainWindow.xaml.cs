using MaterialDesignThemes.Wpf;
using NASA.ViewModels;
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
            DataContext = new MainVM();
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
            maxOrDflt();
        }
        private void maxOrDflt()
        {
            try
            {
                Window window = Application.Current.MainWindow;
                if (window.WindowState == System.Windows.WindowState.Maximized)
                    window.WindowState = System.Windows.WindowState.Normal;
                else
                    window.WindowState = System.Windows.WindowState.Maximized;
            }
            catch
            {
            }
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
            try
            {
                DragMove();
            }
            catch
            {
            }
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
                maxOrDflt();
        }
        #endregion
    }
}
