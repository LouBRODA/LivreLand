using CommunityToolkit.Maui.Views;
using LivreLand.View.ContentViews;

namespace LivreLand.View;

public partial class HeaderHome : ContentView
{
	public HeaderHome()
	{
		InitializeComponent();
	}

    public void OnPlusClicked(object sender, EventArgs e)
    {
        var plusPopup = new PopupHomePlusButtonView();
        App.Current.MainPage.ShowPopup(plusPopup);
    }
}