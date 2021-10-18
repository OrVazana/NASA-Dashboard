using MaterialDesignThemes.Wpf;
using NASA.ViewModels;
using System.Windows;
using System.Windows.Controls;
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
            try
            {
                Button b = (Button)this.FindName("ButtonMaximize");
                Window window = Application.Current.MainWindow;
                PackIcon packIcon = new();
                if (window.WindowState == WindowState.Maximized)
                {
                    window.WindowState = WindowState.Normal;
                    packIcon.Kind = PackIconKind.WindowMaximize;
                    //window.ResizeMode = ResizeMode.CanResize;
                }
                else
                {
                    window.WindowState = WindowState.Maximized;
                    packIcon.Kind = PackIconKind.WindowRestore;
                    //window.ResizeMode = ResizeMode.NoResize;
                }
                b.Content = packIcon;
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
                ButtonMaximaize_Click(sender,e);
        }
        #endregion
    }
}
