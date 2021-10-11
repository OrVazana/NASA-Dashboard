using NASA.Tools;
using System.Windows;
using System.Windows.Controls;
using System;
using System.Windows.Shapes;
using System.Windows.Media;
using NASA.ViewModels;

namespace NASA.Views
{
    /// <summary>
    /// Interaction logic for SolarSystemView.xaml
    /// </summary>
    public partial class SolarSystemView : UserControl
    {
        public SolarSystemView()
        {
            InitializeComponent();
            DataContext = new SolarSystemVM();
        }
        #region Carousel
        //private void CarouselSpeedSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        //{
        //    ExampleCarouselControl.RotationSpeed = e.NewValue;
        //}

        //private void LookdownOffsetSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        //{
        //    ExampleCarouselControl.LookDownOffset = e.NewValue;
        //    ExampleCarouselControl.SetElementPositions();
        //}

        //private void CarouselFadeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        //{
        //    ExampleCarouselControl.Fade = e.NewValue;
        //    ExampleCarouselControl.SetElementPositions();
        //}

        //private void CarouselScaleSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        //{
        //    ExampleCarouselControl.Scale = e.NewValue;
        //    ExampleCarouselControl.SetElementPositions();
        //}

        //private void VerticalOrientationRadioButton_Checked(object sender, RoutedEventArgs e)
        //{
        //    ExampleCarouselControl.Width = 0;
        //    ExampleCarouselControl.Height = 600;
        //    ExampleCarouselControl.ReInitialize();
        //}

        private void HorizontalOrientationRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            ExampleCarouselControl.Width = 600;
            ExampleCarouselControl.Height = 0;
            ExampleCarouselControl.ReInitialize();
        }

        private void ExampleCarouselControl_OnElementSelected(object sender)
        {
            SphereControl selected = ExampleCarouselControl.CurrentlySelected as SphereControl;
            if ((CurrentlySelectedNameTextBlock != null))
            {
                //selectedDescription.Text = SolarSystemVM().getSelectedPlanet(selected.Name);
                CurrentlySelectedNameTextBlock.Foreground = selected.SphereFill;
                CurrentlySelectedNameTextBlock.Text = selected.Name;
            }
        }
        #endregion

        private void Image_Click(object sender, RoutedEventArgs e)
        {
            SphereControl selected = ExampleCarouselControl.CurrentlySelected as SphereControl;
            //selected.Name
            //selectedDescription.Text = selected.Name;
        }
    }
}
