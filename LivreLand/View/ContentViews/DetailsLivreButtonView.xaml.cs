using System.Windows.Input;
using ViewModels;

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

    public static readonly BindableProperty ButtonCommandProperty = BindableProperty.Create(nameof(ButtonCommand), typeof(ICommand), typeof(DetailsLivreButtonView));
    public ICommand ButtonCommand
    {
        get => (ICommand)GetValue(DetailsLivreButtonView.ButtonCommandProperty);
        set => SetValue(DetailsLivreButtonView.ButtonCommandProperty, value);
    }

    public static readonly BindableProperty ButtonCommandParameterProperty = BindableProperty.Create(nameof(ButtonCommandParameter), typeof(object), typeof(DetailsLivreButtonView));
    public object ButtonCommandParameter
    {
        get => (object)GetValue(DetailsLivreButtonView.ButtonCommandParameterProperty);
        set => SetValue(DetailsLivreButtonView.ButtonCommandParameterProperty, value);
    }

    public DetailsLivreButtonView()
	{
		InitializeComponent();
	}
}