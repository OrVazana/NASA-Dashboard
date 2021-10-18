using NASA.Tools;
using System.Windows;
using System.Windows.Controls;
using System;
using System.Windows.Shapes;
using System.Windows.Media;
using NASA.ViewModels;
using NASA.BE;

namespace NASA.Views
{
    /// <summary>
    /// Interaction logic for SolarSystemView.xaml
    /// </summary>
    public partial class SolarSystemView : UserControl
    {
        public SolarSystemVM VM = new SolarSystemVM(); 
        public SolarSystemView()
        {
            InitializeComponent();
            
            DataContext = VM;
            _carouselDABRadioStations.SelectionChanged += _carouselDABRadioStations_SelectionChanged;
        }

        private void _carouselDABRadioStations_SelectionChanged(FrameworkElement selectedElement)
        {
            var viewModel = DataContext as ViewModels.SolarSystemVM;
            if (viewModel == null)
            {
                return;
            }

            viewModel.SelectedPlanet = selectedElement.DataContext as Planet;
        }

        private void _buttonLeftArrow_Click(object sender, RoutedEventArgs e)
        {
            _carouselDABRadioStations.RotateRight();
        }

        private void _buttonRightArrow_Click(object sender, RoutedEventArgs e)
        {
            _carouselDABRadioStations.RotateLeft();
        }

        private void _checkBoxVerticalCarousel_Click(object sender, RoutedEventArgs e)
        {
            _carouselDABRadioStations.VerticalOrientation = _checkBoxVerticalCarousel.IsChecked.HasValue ? _checkBoxVerticalCarousel.IsChecked.Value : false;
        }

        private void _buttonLeftManyArrow_Click(object sender, RoutedEventArgs e)
        {
            _carouselDABRadioStations.RotateIncrement(-5);
        }

        private void _buttonRightManyArrow_Click(object sender, RoutedEventArgs e)
        {
            _carouselDABRadioStations.RotateIncrement(5);
        }
    }
}
