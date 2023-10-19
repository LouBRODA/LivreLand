using LivreLand.Model;
using LivreLand.ViewModel;

namespace LivreLand.View;

public partial class ALirePlusTardView : ContentPage
{
    #region Properties

    public ALirePlusTardVM ALirePlusTardVM { get; set; }

    #endregion

    #region Constructor

    public ALirePlusTardView(ALirePlusTardVM aLirePlusTardVM)
	{
        ALirePlusTardVM = aLirePlusTardVM;
        InitializeComponent();
        BindingContext = this;
	}

    #endregion

    #region Methods

    #endregion
}