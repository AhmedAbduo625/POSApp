using System.Windows.Threading;
using System.Windows;
using System;
using System.Windows.Controls;

namespace POSAppWPF
{
    public abstract class FrameworkElementAnimationAttachedProperties<Parent> : BaseAttachedProperty<Parent, bool> where Parent : BaseAttachedProperty<Parent, bool>, new()
    {
        public override void ValueChangedHandler(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

        }
        public override void ValueUpdatedHandler(DependencyObject d, object baseValue)
        {
            if (!(d is FrameworkElement element))
                return;

            if (element.IsLoaded && (bool)d.GetValue(ValueProperty) != (bool)baseValue)
            {
                DoAnimation(element, (bool)baseValue, false);
            }
            else
            {
                RoutedEventHandler onLoadedHandelr = null;
                onLoadedHandelr = (ss, ee) =>
                {
                    var requredFullyLoading = element.GetValue(RequiredFullyLoadingProperty.ValueProperty);
                    element.Loaded -= onLoadedHandelr;
                    if ((bool)requredFullyLoading)
                        element.Dispatcher.BeginInvoke(DispatcherPriority.Loaded, new Action(() => { DoAnimation(element, (bool)baseValue, true); }));
                    else
                        DoAnimation(element, (bool)baseValue, true);

                };
                element.Loaded += onLoadedHandelr;
            }
        }

        protected virtual async void DoAnimation(FrameworkElement element, bool value, bool isFirstLoad) { }
    }

    public class FadingAnimationProperty : FrameworkElementAnimationAttachedProperties<FadingAnimationProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value, bool isFirstLoad)
        {
            if (value)
                await element.FadingInAsync(isFirstLoad ? 0 : 0.4, 0);
            else
                await element.FadingOutAsync(isFirstLoad ? 0 : 0.4, 0);
        }
    }

    public class OverlayAnimationProperty : FrameworkElementAnimationAttachedProperties<OverlayAnimationProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value, bool isFirstLoad)
        {
            if (value)
                await element.FadingInAsync(isFirstLoad ? 0 : 0.4, 0, 0, 0.5);
            else
                await element.FadingOutAsync(isFirstLoad ? 0 : 0.4, 0, 0.5, 0);
        }
    }

    public class ScaleAnimationProperty : FrameworkElementAnimationAttachedProperties<ScaleAnimationProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value, bool isFirstLoad)
        {
            if (value)
                await element.ScaleUpAsync(isFirstLoad ? 0 : 0.3, 0, 0.7, 0.7, 1, 1);
            else
                await element.ScaleDownAsync(isFirstLoad ? 0 : 0.3, 0, 1, 1, 0.7, 0.7);
        }
    }


}
