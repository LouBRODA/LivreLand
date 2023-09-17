using CommunityToolkit.Maui.Views;

namespace LivreLand.View.ContentViews;

public partial class PopupHomePlusButtonView : Popup
{
	public PopupHomePlusButtonView()
	{
		InitializeComponent();
		Size = new Size(0.8 * (DeviceDisplay.Current.MainDisplayInfo.Width / DeviceDisplay.Current.MainDisplayInfo.Density), 0.5 * (DeviceDisplay.Current.MainDisplayInfo.Width / DeviceDisplay.Current.MainDisplayInfo.Density));
	}
}