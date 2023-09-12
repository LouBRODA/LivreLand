using Microsoft.Maui.Graphics;

namespace LivreLand.View.ContentViews;

public partial class HomeButtonView : ContentView
{
    public static readonly BindableProperty ButtonTitleProperty = BindableProperty.Create(nameof(ButtonTitle), typeof(string), typeof(HomeButtonView), string.Empty);
    public string ButtonTitle
    {
        get => (string)GetValue(HomeButtonView.ButtonTitleProperty);
        set => SetValue(HomeButtonView.ButtonTitleProperty, value);
    }

    public static readonly BindableProperty ButtonIconProperty = BindableProperty.Create(nameof(ButtonIcon), typeof(string), typeof(HomeButtonView), string.Empty);
    public string ButtonIcon
    {
        get => (string)GetValue(HomeButtonView.ButtonIconProperty);
        set => SetValue(HomeButtonView.ButtonIconProperty, value);
    }

    public static readonly BindableProperty ButtonNumberProperty = BindableProperty.Create(nameof(ButtonNumber), typeof(string), typeof(HomeButtonView), string.Empty);
    public string ButtonNumber
    {
        get => (string)GetValue(HomeButtonView.ButtonNumberProperty);
        set => SetValue(HomeButtonView.ButtonNumberProperty, value);
    }

    public static readonly BindableProperty ButtonIconColorProperty = BindableProperty.Create(nameof(ButtonIconColor), typeof(Color), typeof(HomeButtonView), Colors.Black);
    public Color ButtonIconColor
    {
        get => (Color)GetValue(HomeButtonView.ButtonIconColorProperty);
        set => SetValue(HomeButtonView.ButtonIconColorProperty, value);
    }

    public static readonly BindableProperty ButtonCommandProperty = BindableProperty.Create(nameof(ButtonCommand), typeof(Command), typeof(HomeButtonView));
    public Command ButtonCommand
    {
        get => (Command)GetValue(HomeButtonView.ButtonCommandProperty);
        set => SetValue(HomeButtonView.ButtonCommandProperty, value);
    }

    public HomeButtonView()
    {
        InitializeComponent();
    }
}