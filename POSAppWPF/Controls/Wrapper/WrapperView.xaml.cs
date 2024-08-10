using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace POSAppWPF
{
    /// <summary>
    /// Interaction logic for WrapperView.xaml
    /// </summary>
    public partial class WrapperView : UserControl
    {
        public WrapperView()
        {
            InitializeComponent();
		}

        public SolidColorBrush Background
        {
            get { return (SolidColorBrush)GetValue(BackgroundProperty); }
            set { SetValue(BackgroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BackgroundProperty =
            DependencyProperty.Register("Background", typeof(SolidColorBrush), typeof(WrapperView), new PropertyMetadata(null));



        public double Opacity
        {
            get { return (double)GetValue(OpacityProperty); }
            set { SetValue(OpacityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Opacity.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OpacityProperty =
            DependencyProperty.Register("Opacity", typeof(double), typeof(WrapperView), new PropertyMetadata(0.1));




    }
}
