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
        public SolarSystemVM VM = new();
        public SolarSystemView()
        {
            InitializeComponent();
            
            DataContext = VM;
            _carouselPlanets.SelectionChanged += _carouselPlanets_SelectionChanged;
        }

        private void _carouselPlanets_SelectionChanged(FrameworkElement selectedElement)
        {
            var viewModel = DataContext as SolarSystemVM;
            if (viewModel == null)
            {
                return;
            }

            viewModel.SelectedPlanet = selectedElement.DataContext as Planet;
        }

        private void _buttonLeftArrow_Click(object sender, RoutedEventArgs e)
        {
            _carouselPlanets.RotateRight();
        }

        private void _buttonRightArrow_Click(object sender, RoutedEventArgs e)
        {
            _carouselPlanets.RotateLeft();
        }

        //private void _checkBoxVerticalCarousel_Click(object sender, RoutedEventArgs e)
        //{
        //    _carouselPlanets.VerticalOrientation = _checkBoxVerticalCarousel.IsChecked.HasValue ? _checkBoxVerticalCarousel.IsChecked.Value : false;
        //}

        private void _buttonLeftManyArrow_Click(object sender, RoutedEventArgs e)
        {
            _carouselPlanets.RotateIncrement(-5);
        }

        private void _buttonRightManyArrow_Click(object sender, RoutedEventArgs e)
        {
            _carouselPlanets.RotateIncrement(5);
        }
    }
}
