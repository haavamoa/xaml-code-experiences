# Animations
When working with WPF and animations you quickly realize that animations does not work the same way as they do in `Xamarin.Forms`. In `Xamarin.Forms` you can easily use animations in the code behind by calling extension methods for any view, and whats nice is that these animations are awaitable. This means that you can queue up animations that wait for eachother quite easily. 

In WPF you have to work with [Storyboards](https://docs.microsoft.com/en-us/dotnet/desktop/wpf/graphics-multimedia/storyboards-overview?view=netframeworkdesktop-4.8) and the [Animation](https://docs.microsoft.com/en-us/dotnet/desktop/wpf/graphics-multimedia/animation-overview?view=netframeworkdesktop-4.8) class. These can be a bit overwhelming and I find it quiet useful to try to move towards the same approach as `Xamarin.Forms` for simplicity.

[Below is a static `AnimationExtensions` class that I tend to import to my projects. This class has `FadeTo`, `ColorTo` and `TranslateTo`.](AnimationExtensions.cs)

```csharp
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

        public static Task TranslateToY(this FrameworkElement frameworkElement, double y, long length = 250, IEasingFunction? easingFunction = null)
        {
            var tsc = new TaskCompletionSource<bool>();
            var transform = new TranslateTransform(0, 0);
            frameworkElement.RenderTransform = transform;

            var doubleAnimation = new DoubleAnimation() { To = y, Duration = TimeSpan.FromMilliseconds(length) };
            doubleAnimation.EasingFunction = easingFunction;

            var sb = new Storyboard();
            sb.Children.Add(doubleAnimation);

            Storyboard.SetTarget(sb, frameworkElement);
            Storyboard.SetTargetProperty(sb, new PropertyPath("RenderTransform.(TranslateTransform.Y)"));

            sb.Begin();
            sb.Completed += (s, e) =>
            {
                tsc.SetResult(true);
            };
            sb.Begin();

            return tsc.Task;
        }

        public static Task TranslateToX(this FrameworkElement frameworkElement, double x, long length = 250, IEasingFunction? easingFunction = null)
        {
            var tsc = new TaskCompletionSource<bool>();
            var transform = new TranslateTransform(0, 0);
            frameworkElement.RenderTransform = transform;

            var doubleAnimation = new DoubleAnimation() { To = x, Duration = TimeSpan.FromMilliseconds(length) };
            doubleAnimation.EasingFunction = easingFunction;

            var sb = new Storyboard();
            sb.Children.Add(doubleAnimation);

            Storyboard.SetTarget(sb, frameworkElement);
            Storyboard.SetTargetProperty(sb, new PropertyPath("RenderTransform.(TranslateTransform.X)"));

            sb.Begin();
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
```

This can be consumed like so in any code behind file:

```csharp
private async void OnMyButtonClicked(object sender, EventArgs e)
        {
            if (!(sender is FrameworkElement frameworkElement))
                return;

            await frameworkElement.TranslateTo(
                -frameworkElement.ActualHeight,
                -frameworkElement.ActualWidth,
                500, 
                new BackEase() { EasingMode = EasingMode.EaseIn, Amplitude = 0.3 });
        }
```

This means that a button that I click will move from it's position to `X / Y = height of button`. This makes no sense, but it proves that the button can be moved. It also has a nice easing to it for a sliding effect.
