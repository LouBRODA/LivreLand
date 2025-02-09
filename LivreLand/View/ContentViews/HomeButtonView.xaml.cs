using Microsoft.Maui.Graphics;
using System.Windows.Input;

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

    public static readonly BindableProperty ButtonRedIconVisibleProperty = BindableProperty.Create(nameof(ButtonRedIconVisible), typeof(Boolean), typeof(HomeButtonView), true);
    public Boolean ButtonRedIconVisible
    {
        get => (Boolean)GetValue(HomeButtonView.ButtonRedIconVisibleProperty);
        set => SetValue(HomeButtonView.ButtonRedIconVisibleProperty, value);
    }

    public static readonly BindableProperty ButtonBlackIconVisibleProperty = BindableProperty.Create(nameof(ButtonBlackIconVisible), typeof(Boolean), typeof(HomeButtonView), true);
    public Boolean ButtonBlackIconVisible
    {
        get => (Boolean)GetValue(HomeButtonView.ButtonBlackIconVisibleProperty);
        set => SetValue(HomeButtonView.ButtonBlackIconVisibleProperty, value);
    }

    public static readonly BindableProperty ButtonTappedCommandProperty = BindableProperty.Create(nameof(ButtonTappedCommand), typeof(ICommand), typeof(HomeButtonView));
    public ICommand ButtonTappedCommand
    {
        get { return (ICommand)GetValue(ButtonTappedCommandProperty); }
        set { SetValue(ButtonTappedCommandProperty, value); }
    }

    public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(nameof(CommandParameter), typeof(string), typeof(HomeButtonView));
    public string CommandParameter
    {
        get { return (string)GetValue(CommandParameterProperty); }
        set { SetValue(CommandParameterProperty, value); }
    }

    public HomeButtonView()
    {
        InitializeComponent();
    }
}