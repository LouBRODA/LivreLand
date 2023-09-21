using CommunityToolkit.Maui.Views;
using LivreLand.ViewModel;

namespace LivreLand.View.ContentViews;

public partial class PopupHomePlusButtonView : Popup
{

    #region Properties

    public NavigatorVM Navigator { get; private set; }

    #endregion


    #region Constructor

    public PopupHomePlusButtonView(NavigatorVM navigatorVM)
	{
        Navigator = navigatorVM;
        InitializeComponent();
		Size = new Size(0.8 * (DeviceDisplay.Current.MainDisplayInfo.Width / DeviceDisplay.Current.MainDisplayInfo.Density), 0.5 * (DeviceDisplay.Current.MainDisplayInfo.Width / DeviceDisplay.Current.MainDisplayInfo.Density));
        BindingContext = this;
    }

    #endregion
}