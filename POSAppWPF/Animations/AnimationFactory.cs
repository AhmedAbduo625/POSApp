
using System.Windows.Media.Animation;
using System.Windows.Media.Media3D;
using System.Windows;
using System;

namespace POSAppWPF
{
    public class AnimationFactory
    {
        public static AnimationTimeline CreateAnimation(AnimationProperties targetProperty, double duration, double beginTime, params object[] animationProps)
        {
            AnimationTimeline animation = null;
            string targetPropertyName = "";

            switch (targetProperty)
            {
                case AnimationProperties.Opacity:
                    {
                        animation = new DoubleAnimation()
                        {
                            BeginTime = TimeSpan.FromSeconds(beginTime),
                            Duration = new Duration(TimeSpan.FromSeconds(duration)),
                            From = (double)animationProps[0],
                            To = (double)animationProps[1],

                        };
                        targetPropertyName = targetProperty.ToString();
                        break;
                    }
				case AnimationProperties.Margin:
                    {
                        animation = new ThicknessAnimation()
                        {
                            BeginTime = TimeSpan.FromSeconds(beginTime),
                            Duration = new Duration(TimeSpan.FromSeconds(duration)),
                            From = (Thickness)animationProps[0],
                            To = (Thickness)animationProps[1],
                            DecelerationRatio = 0.9
                        };
                        targetPropertyName = targetProperty.ToString();
                        break;
                    }
                case AnimationProperties.ScaleX:
                    {
                        animation = new DoubleAnimation()
                        {
                            BeginTime = TimeSpan.FromSeconds(beginTime),
                            Duration = new Duration(TimeSpan.FromSeconds(duration)),
                            From = (double)animationProps[0],
                            To = (double)animationProps[1],
                            DecelerationRatio = 0.9
                        };
                        targetPropertyName = "(RenderTransform).(ScaleTransform.ScaleX)";
                        break;
                    }
                case AnimationProperties.ScaleY:
                    {
                        animation = new DoubleAnimation()
                        {
                            BeginTime = TimeSpan.FromSeconds(beginTime),
                            Duration = new Duration(TimeSpan.FromSeconds(duration)),
                            From = (double)animationProps[0],
                            To = (double)animationProps[1],
                            DecelerationRatio = 0.9
                        };
                        targetPropertyName = "(RenderTransform).(ScaleTransform.ScaleY)";
                        break;
                    }
                case AnimationProperties.Rotate3D:
                    {
                        animation = new Rotation3DAnimation()
                        {
                            BeginTime = TimeSpan.FromSeconds(beginTime),
                            Duration = new Duration(TimeSpan.FromSeconds(duration)),
                            From = (AxisAngleRotation3D)animationProps[0],
                            To = (AxisAngleRotation3D)animationProps[1],
                        };
                        targetPropertyName = "(Viewport2DVisual3D.Transform).(RotateTransform3D.Rotation)";
                        break;
                    }
            }

            Storyboard.SetTargetProperty(animation, new PropertyPath(targetPropertyName));

            if (animationProps.Length == 3)
                Storyboard.SetTargetName(animation, animationProps[2].ToString());

            return animation;
        }
    }
}
