using CommunityToolkit.Maui.Views;

namespace LivreLand.View.ContentViews;

public partial class PopupLetterView : Popup
{
    public PopupLetterView(string letter)
	{
        InitializeComponent();
        letterText.Text = letter;
    }
}