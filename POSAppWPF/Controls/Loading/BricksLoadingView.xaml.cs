
using System.Windows;
using System.Windows.Controls;

namespace POSAppWPF
{
    /// <summary>
    /// Interaction logic for BricksLoadingView.xaml
    /// </summary>
    public partial class BricksLoadingView : UserControl
    {
        public BricksLoadingView()
        {
            InitializeComponent();
        }
		public bool IsVisible
		{
			get { return (bool)GetValue(IsVisibleProperty); }
			set { SetValue(IsVisibleProperty, value); }
		}

		// Using a DependencyProperty as the backing store for IsVisible.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty IsVisibleProperty =
			DependencyProperty.Register("IsVisible", typeof(bool), typeof(BricksLoadingView), new PropertyMetadata(false));
	}
}
