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

    public HomeButtonView()
    {
        InitializeComponent();
    }
}