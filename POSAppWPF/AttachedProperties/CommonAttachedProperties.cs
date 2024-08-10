

using POSAppCore;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows;
using System.Windows.Media;

namespace POSAppWPF
{
    /* Normal attached properties */
    public class DoubleDataTypeProperty : BaseAttachedProperty<DoubleDataTypeProperty, double>
    {
        public override void ValueChangedHandler(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

        }

        public override void ValueUpdatedHandler(DependencyObject d, object baseValue)
        {

        }
    }
    public class CornerRaduisDataTypeProperty : BaseAttachedProperty<CornerRaduisDataTypeProperty, CornerRadius>
    {
        public override void ValueChangedHandler(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

        }

        public override void ValueUpdatedHandler(DependencyObject d, object baseValue)
        {

        }
    }
	public class GridLenghtDataTypeProperty : BaseAttachedProperty<GridLenghtDataTypeProperty, GridLength>
	{
		public override void ValueChangedHandler(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{

		}

		public override void ValueUpdatedHandler(DependencyObject d, object baseValue)
		{

		}
	}
	public class SolidColorBrushDataTypeProperty : BaseAttachedProperty<SolidColorBrushDataTypeProperty, SolidColorBrush>
	{
		public override void ValueChangedHandler(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{

		}

		public override void ValueUpdatedHandler(DependencyObject d, object baseValue)
		{

		}
	}
	public class BoolDataTypeProperty : BaseAttachedProperty<BoolDataTypeProperty, bool>
    {
        public override void ValueChangedHandler(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

        }

        public override void ValueUpdatedHandler(DependencyObject d, object baseValue)
        {

        }
    }
    public class IconPropoperty : BaseAttachedProperty<IconPropoperty, Icons>
    {
        public override void ValueChangedHandler(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

        }

        public override void ValueUpdatedHandler(DependencyObject d, object baseValue)
        {

        }
    }


    /* Special attached properties */
    public class RequiredFullyLoadingProperty : BaseAttachedProperty<RequiredFullyLoadingProperty, bool>
    {
        public override void ValueChangedHandler(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

        }

        public override void ValueUpdatedHandler(DependencyObject d, object baseValue)
        {

        }
    }
    public class ClearPageFrameHistoryProperty : BaseAttachedProperty<ClearPageFrameHistoryProperty, bool>
    {
        public override void ValueChangedHandler(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Frame frame)
            {
                if ((bool)e.NewValue)
                {
                    frame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
                    frame.Navigated += Frame_Navigated;
                }
            }
        }

        private void Frame_Navigated(object sender, NavigationEventArgs e) => ((Frame)sender).NavigationService.RemoveBackEntry();

        public override void ValueUpdatedHandler(DependencyObject d, object baseValue)
        {

        }
    }
    public class FocusAndSelectProperty : BaseAttachedProperty<FocusAndSelectProperty, bool>
    {
        public override void ValueChangedHandler(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is TextBox textBox)
            {
                if ((bool)e.NewValue)
                {
                    textBox.Loaded += (ss, ee) =>
                    {
                        ((TextBox)ss).Focus();
                        ((TextBox)ss).SelectAll();
                    };
                }
            }
        }

        public override void ValueUpdatedHandler(DependencyObject d, object baseValue)
        {

        }
    }
	public class BorderedRadioButtonWidthProperty : BaseAttachedProperty<BorderedRadioButtonWidthProperty, double>
	{
		public override void ValueChangedHandler(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{

		}

		public override void ValueUpdatedHandler(DependencyObject d, object baseValue)
		{

		}
	}

}
