using CommunityToolkit.Maui.Views;

namespace LivreLand.View.ContentViews;

public partial class PopupISBNView : Popup
{
	public PopupISBNView()
	{
		InitializeComponent();
        Size = new Size(0.8 * (DeviceDisplay.Current.MainDisplayInfo.Width / DeviceDisplay.Current.MainDisplayInfo.Density), 0.5 * (DeviceDisplay.Current.MainDisplayInfo.Width / DeviceDisplay.Current.MainDisplayInfo.Density));
    }
}