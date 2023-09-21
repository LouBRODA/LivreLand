using LivreLand.ViewModel;
using System.Windows.Input;

namespace LivreLand.View;

public partial class HeaderHome : ContentView
{

    #region Properties

    public NavigatorVM Navigator { get; private set; }

    public static readonly BindableProperty ButtonTappedCommandProperty = BindableProperty.Create(nameof(ButtonTappedCommand), typeof(ICommand), typeof(HeaderPage));
    public ICommand ButtonTappedCommand
    {
        get { return (ICommand)GetValue(ButtonTappedCommandProperty); }
        set { SetValue(ButtonTappedCommandProperty, value); }
    }

    #endregion

    #region Constructor

    public HeaderHome()
	{
        InitializeComponent();
    }

    #endregion
}