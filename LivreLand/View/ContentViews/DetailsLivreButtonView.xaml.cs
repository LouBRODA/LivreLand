namespace LivreLand.View.ContentViews;

public partial class DetailsLivreButtonView : ContentView
{
    public static readonly BindableProperty ButtonTitleProperty = BindableProperty.Create(nameof(ButtonTitle), typeof(string), typeof(DetailsLivreButtonView), string.Empty);
    public string ButtonTitle
    {
        get => (string)GetValue(DetailsLivreButtonView.ButtonTitleProperty);
        set => SetValue(DetailsLivreButtonView.ButtonTitleProperty, value);
    }

    public static readonly BindableProperty ButtonIconProperty = BindableProperty.Create(nameof(ButtonIcon), typeof(string), typeof(DetailsLivreButtonView), string.Empty);
    public string ButtonIcon
    {
        get => (string)GetValue(DetailsLivreButtonView.ButtonIconProperty);
        set => SetValue(DetailsLivreButtonView.ButtonIconProperty, value);
    }

    public DetailsLivreButtonView()
	{
		InitializeComponent();
	}
}