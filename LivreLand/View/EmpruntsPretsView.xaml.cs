using LivreLand.Model;
using LivreLand.ViewModel;

namespace LivreLand.View;

public partial class EmpruntsPretsView : ContentPage
{
    #region Properties

    public EmpruntsPretsVM EmpruntsPretsVM { get; set; }

    #endregion

    #region Constructor

    public EmpruntsPretsView(EmpruntsPretsVM empruntsPretsVM)
	{
        EmpruntsPretsVM = empruntsPretsVM;
        InitializeComponent();
        BindingContext = this;
	}

    #endregion

    #region Methods

    #endregion
}