using System.Threading.Tasks;
using System.Windows.Media.Animation;
using System.Windows.Media.Media3D;
using System.Windows;

namespace POSAppWPF
{
    public static class AnimationServices
    {
        public static async Task SlideInWithFadingAsync(this FrameworkElement element, double duration, double beginTime, Thickness fromThickness, Thickness toThickness, double fromOpacity = 0, double toOpacity = 1)
        {
            var storyboard = new Storyboard();

            var fadeAnimation = AnimationFactory.CreateAnimation(AnimationProperties.Opacity, duration, beginTime, fromOpacity, toOpacity);
            var slideAnimation = AnimationFactory.CreateAnimation(AnimationProperties.Margin, duration, beginTime, fromThickness, toThickness);

            storyboard.Children.Add(fadeAnimation);
            storyboard.Children.Add(slideAnimation);

            element.Visibility = Visibility.Visible;
            storyboard.Begin(element);
            await Task.Delay((int)((duration + beginTime) * 1000));
        }
        public static async Task SlideOutWithFadingAsync(this FrameworkElement element, double duration, double beginTime, Thickness fromThickness, Thickness toThickness, double fromOpacity = 1, double toOpacity = 0)
        {
            var storyboard = new Storyboard();

            var fadeAnimation = AnimationFactory.CreateAnimation(AnimationProperties.Opacity, duration, beginTime, fromOpacity, toOpacity);
            var slideAnimation = AnimationFactory.CreateAnimation(AnimationProperties.Margin, duration, beginTime, fromThickness, toThickness);

            storyboard.Children.Add(fadeAnimation);
            storyboard.Children.Add(slideAnimation);

            storyboard.Begin(element);
            await Task.Delay((int)((duration + beginTime) * 1000));
            element.Visibility = Visibility.Hidden;
        }

        public static async Task SlideInAsync(this FrameworkElement element, double duration, double beginTime, Thickness fromThickness, Thickness toThickness)
        {
            var storyboard = new Storyboard();

            var slideAnimation = AnimationFactory.CreateAnimation(AnimationProperties.Margin, duration, beginTime, fromThickness, toThickness);
            storyboard.Children.Add(slideAnimation);

            element.Visibility = Visibility.Visible;
            storyboard.Begin(element);
            await Task.Delay((int)((duration + beginTime) * 1000));
        }
        public static async Task SlideOutAsync(this FrameworkElement element, double duration, double beginTime, Thickness fromThickness, Thickness toThickness, bool collapse = true)
        {
            var storyboard = new Storyboard();

            var slideAnimation = AnimationFactory.CreateAnimation(AnimationProperties.Margin, duration, beginTime, fromThickness, toThickness);
            storyboard.Children.Add(slideAnimation);

            storyboard.Begin(element);
            await Task.Delay((int)((duration + beginTime) * 1000));

            if (collapse)
                element.Visibility = Visibility.Collapsed;
        }

        public static async Task FadingInAsync(this FrameworkElement element, double duration, double beginTime, double fromOpacity = 0, double toOpacity = 1)
        {
            var storyboard = new Storyboard();

            var fadeAnimation = AnimationFactory.CreateAnimation(AnimationProperties.Opacity, duration, beginTime, fromOpacity, toOpacity);

            storyboard.Children.Add(fadeAnimation);

            element.Visibility = Visibility.Visible;
            storyboard.Begin(element);
            await Task.Delay((int)((duration + beginTime) * 1000));
        }
        public static async Task FadingOutAsync(this FrameworkElement element, double duration, double beginTime, double fromOpacity = 1, double toOpacity = 0)
        {
            var storyboard = new Storyboard();

            var fadeAnimation = AnimationFactory.CreateAnimation(AnimationProperties.Opacity, duration, beginTime, fromOpacity, toOpacity);

            storyboard.Children.Add(fadeAnimation);

            storyboard.Begin(element);
            await Task.Delay((int)((duration + beginTime) * 1000));
            element.Visibility = Visibility.Hidden;
        }

        public static async Task ScaleUpAsync(this FrameworkElement element, double duration, double beginTime, double fromScaleX = 1, double fromScaleY = 1, double toScaleX = 1.1, double toScaleY = 1.1)
        {
            var storyboard = new Storyboard();

            var scaleXAnimation = AnimationFactory.CreateAnimation(AnimationProperties.ScaleX, duration, beginTime, fromScaleX, toScaleX);
            var scaleYAnimation = AnimationFactory.CreateAnimation(AnimationProperties.ScaleY, duration, beginTime, fromScaleY, toScaleY);
            var fadeAnimation = AnimationFactory.CreateAnimation(AnimationProperties.Opacity, duration, beginTime, 0.0, 1.0);

            storyboard.Children.Add(scaleXAnimation);
            storyboard.Children.Add(scaleYAnimation);
            storyboard.Children.Add(fadeAnimation);

            element.Visibility = Visibility.Visible;
            storyboard.Begin(element);
            await Task.Delay((int)((duration + beginTime) * 1000));
        }
        public static async Task ScaleDownAsync(this FrameworkElement element, double duration, double beginTime, double fromScaleX = 1.1, double fromScaleY = 1.1, double toScaleX = 1, double toScaleY = 1)
        {
            var storyboard = new Storyboard();

            var scaleXAnimation = AnimationFactory.CreateAnimation(AnimationProperties.ScaleX, duration, beginTime, fromScaleX, toScaleX);
            var scaleYAnimation = AnimationFactory.CreateAnimation(AnimationProperties.ScaleY, duration, beginTime, fromScaleY, toScaleY);
            var fadeAnimation = AnimationFactory.CreateAnimation(AnimationProperties.Opacity, duration, beginTime, 1.0, 0.0);

            storyboard.Children.Add(scaleXAnimation);
            storyboard.Children.Add(scaleYAnimation);
            storyboard.Children.Add(fadeAnimation);

            storyboard.Begin(element);
            await Task.Delay((int)((duration + beginTime) * 1000));
            element.Visibility = Visibility.Hidden;
        }


        public static async Task RotateFrontCardAsync(this FrameworkElement element, double duration, double beginTime, AxisAngleRotation3D fromFrontAngle, AxisAngleRotation3D toFrontAngle, AxisAngleRotation3D fromBackAngle, AxisAngleRotation3D toBackAngle)
        {
            var storyboard = new Storyboard();

            var frontSideAnimation = AnimationFactory.CreateAnimation(AnimationProperties.Opacity, 0, beginTime, 1.0, 0.0, "Front_Side");
            storyboard.Children.Add(frontSideAnimation);

            var backSideAnimation = AnimationFactory.CreateAnimation(AnimationProperties.Opacity, 0, beginTime, 0.0, 1.0, "Back_Side");
            storyboard.Children.Add(backSideAnimation);

            var rotaetAnimationInForward = AnimationFactory.CreateAnimation(AnimationProperties.Rotate3D, duration, 0, fromFrontAngle, toFrontAngle, "ViewPort");
            storyboard.Children.Add(rotaetAnimationInForward);

            var rotaetAnimationInBackward = AnimationFactory.CreateAnimation(AnimationProperties.Rotate3D, duration, beginTime, fromBackAngle, toBackAngle, "ViewPort");
            storyboard.Children.Add(rotaetAnimationInBackward);

            storyboard.Begin(element);
            await Task.Delay((int)((duration + beginTime) * 1000));
        }
        public static async Task RotateBackCardAsync(this FrameworkElement element, double duration, double beginTime, AxisAngleRotation3D fromFrontAngle, AxisAngleRotation3D toFrontAngle, AxisAngleRotation3D fromBackAngle, AxisAngleRotation3D toBackAngle)
        {
            var storyboard = new Storyboard();

            var backSideAnimation = AnimationFactory.CreateAnimation(AnimationProperties.Opacity, 0, beginTime, 1.0, 0.0, "Back_Side");
            storyboard.Children.Add(backSideAnimation);

            var frontSideAnimation = AnimationFactory.CreateAnimation(AnimationProperties.Opacity, 0, beginTime, 0.0, 1.0, "Front_Side");
            storyboard.Children.Add(frontSideAnimation);

            var rotaetAnimationInBackward = AnimationFactory.CreateAnimation(AnimationProperties.Rotate3D, duration, 0, fromBackAngle, toBackAngle, "ViewPort");
            storyboard.Children.Add(rotaetAnimationInBackward);

            var rotaetAnimationInForward = AnimationFactory.CreateAnimation(AnimationProperties.Rotate3D, duration, beginTime, fromFrontAngle, toFrontAngle, "ViewPort");
            storyboard.Children.Add(rotaetAnimationInForward);

            storyboard.Begin(element);
            await Task.Delay((int)((duration + beginTime) * 1000));

        }


	}
}
