using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace myNameSpace
{
    public static class AnimationExtensions
    {
        public static Task FadeTo(this UIElement uIElement, double toValue, double length = 250, IEasingFunction? easingFunction = null)
        {
            var tcs = new TaskCompletionSource<bool>();
            var animation = new DoubleAnimation();
            animation.To = toValue;
            animation.Duration = TimeSpan.FromMilliseconds(length);
            animation.EasingFunction = easingFunction;

            var sb = new Storyboard();
            sb.Children.Add(animation);

            Storyboard.SetTarget(sb, uIElement);
            Storyboard.SetTargetProperty(sb, new PropertyPath(UIElement.OpacityProperty));
            sb.Completed += (s, e) =>
            {
                tcs.SetResult(true);
            };

            sb.Begin();

            return tcs.Task;
        }

        public static Task ColorTo(this FrameworkElement frameworkElement, DependencyProperty dependencyProperty, Color fromColor, Color toColor, long length = 250, IEasingFunction? easingFunction = null)
        {
            var tsc = new TaskCompletionSource<bool>();
            var sb = new Storyboard();
            var animation = new ColorAnimation(fromColor, toColor, TimeSpan.FromMilliseconds(length));
            animation.EasingFunction = easingFunction;

            Storyboard.SetTarget(animation, frameworkElement);
            Storyboard.SetTargetProperty(animation, new PropertyPath($"({dependencyProperty.Name}).(SolidColorBrush.Color)"));

            sb.Children.Add(animation);
            sb.Completed += (s, e) =>
            {
                tsc.SetResult(true);
            };
            sb.Begin();

            return tsc.Task;
        }

        public static Task TranslateTo(this FrameworkElement frameworkElement, double y, double x, long length = 250, IEasingFunction? easingFunction = null)
        {
            var tsc = new TaskCompletionSource<bool>();
            var transform = new TranslateTransform(0, 0);
            frameworkElement.RenderTransform = transform;

            var yDoubleAnimation = new DoubleAnimation() { To = y, Duration = TimeSpan.FromMilliseconds(length), EasingFunction = easingFunction };
            var xDoubleAnimation = new DoubleAnimation() { To = y, Duration = TimeSpan.FromMilliseconds(length), EasingFunction = easingFunction };

            var sb = new Storyboard();
            sb.Children.Add(yDoubleAnimation);
            sb.Children.Add(xDoubleAnimation);

            Storyboard.SetTarget(sb.Children.ElementAt(0), frameworkElement);
            Storyboard.SetTargetProperty(sb.Children.ElementAt(0), new PropertyPath("RenderTransform.(TranslateTransform.Y)"));

            Storyboard.SetTarget(sb.Children.ElementAt(1), frameworkElement);
            Storyboard.SetTargetProperty(sb.Children.ElementAt(1), new PropertyPath("RenderTransform.(TranslateTransform.X)"));

            sb.Begin();
            sb.Completed += (s, e) =>
            {
                tsc.SetResult(true);
            };
            sb.Begin();

            return tsc.Task;
        }
    }
}
