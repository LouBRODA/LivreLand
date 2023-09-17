using CommunityToolkit.Maui.Views;

namespace LivreLand.View.ContentViews;

public partial class LetterVerticalMenuView : ContentView
{
    public static readonly BindableProperty ButtonLetterProperty = BindableProperty.Create(nameof(ButtonLetter), typeof(string), typeof(LetterVerticalMenuView), string.Empty);
    public string ButtonLetter
    {
        get => (string)GetValue(LetterVerticalMenuView.ButtonLetterProperty);
        set => SetValue(LetterVerticalMenuView.ButtonLetterProperty, value);
    }

    public LetterVerticalMenuView()
	{
		InitializeComponent();
	}

    public void OnLetterTapped(object sender, TappedEventArgs e)
    {
        var plusPopup = new PopupLetterView(letterText.Text);
        App.Current.MainPage.ShowPopup(plusPopup);
    }
}