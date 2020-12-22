# Animations
When working with WPF and animations you quickly realize that animations does not work the same way as they do in `Xamarin.Forms`. In `Xamarin.Forms` you can easily use animations in the code behind by calling extension methods for any view, and whats nice is that these animations are awaitable. This means that you can queue up animations that wait for eachother quite easily. 

In WPF you have to work with [Storyboards](https://docs.microsoft.com/en-us/dotnet/desktop/wpf/graphics-multimedia/storyboards-overview?view=netframeworkdesktop-4.8) and the [Animation](https://docs.microsoft.com/en-us/dotnet/desktop/wpf/graphics-multimedia/animation-overview?view=netframeworkdesktop-4.8) class. These can be a bit overwhelming and I find it quiet useful to try to move towards the same approach as `Xamarin.Forms` for simplicity.


## Solution
[Here is a static `AnimationExtensions` class that I tend to import to my projects. This class has `FadeTo`, `ColorTo` and `TranslateTo`.](AnimationExtensions.cs)


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
