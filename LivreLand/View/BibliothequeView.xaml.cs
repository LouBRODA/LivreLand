using LivreLand.ViewModel;
using System.Windows.Input;

namespace LivreLand.View;

public partial class BibliothequeView : ContentPage
{
    #region Properties

    public NavigatorVM Navigator { get; private set; }

    #endregion

    #region Constructor

    public BibliothequeView(NavigatorVM navigatorVM)
	{
        Navigator = navigatorVM;
        InitializeComponent();
        BindingContext = this;
    }

    #endregion

}