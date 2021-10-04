using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NASA.Tools
{
    /// <summary>
    /// Interaction logic for SphereControl.xaml
    /// </summary>
    public partial class SphereControl
    {
        public SphereControl()
        {
            this.InitializeComponent();
        }

        public Color InnerColorBrush
        {
            get { return InnerColor.Color; }
            set { InnerColor.Color = value; }
        }
        public Color OuterColorBrush
        {
            get { return OuterColor.Color; }
            set { OuterColor.Color = value; }
        }
        public Brush SphereFill
        {
            get { return Ellipse.Fill; }
        }
    }
}
