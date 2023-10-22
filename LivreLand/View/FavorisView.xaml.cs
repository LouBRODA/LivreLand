using LivreLand.Model;
using LivreLand.ViewModel;

namespace LivreLand.View;

public partial class FavorisView : ContentPage
{
    #region Properties

    public FavorisVM FavorisVM { get; set; }

    #endregion

    #region Constructor

    public FavorisView(FavorisVM favorisVM)
	{
        FavorisVM = favorisVM;
        InitializeComponent();
        BindingContext = this;
    }

    #endregion

    #region Methods

    #endregion
}