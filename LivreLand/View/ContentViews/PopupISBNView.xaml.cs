using CommunityToolkit.Maui.Views;
using LivreLand.ViewModel;

namespace LivreLand.View.ContentViews;

public partial class PopupISBNView : Popup
{
	public PopupISBNView(PopupISBNVM popupISBNVM)
	{
		InitializeComponent();
		BindingContext = popupISBNVM;
        Size = new Size(0.8 * (DeviceDisplay.Current.MainDisplayInfo.Width / DeviceDisplay.Current.MainDisplayInfo.Density), 0.5 * (DeviceDisplay.Current.MainDisplayInfo.Width / DeviceDisplay.Current.MainDisplayInfo.Density));
    }
}