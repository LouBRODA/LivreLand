using LivreLand.Model;
using LivreLand.ViewModel;
using ViewModels;

namespace LivreLand.View;

public partial class TousView : ContentPage
{

    #region Properties

    public TousVM TousVM { get; set; }

    #endregion

    #region Constructor

    public TousView(TousVM tousVM)
	{
        TousVM = tousVM;
		InitializeComponent();
        BindingContext = this;
    }

    #endregion

    #region Methods

    #endregion
}