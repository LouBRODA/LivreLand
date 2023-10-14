using LivreLand.ViewModel;

namespace LivreLand.View;

public partial class FiltrageAuteurView : ContentPage
{
    #region Properties

    public FiltrageAuteurVM FiltrageAuteurVM { get; set; }

    #endregion

    #region Constructor

    public FiltrageAuteurView(FiltrageAuteurVM filtrageAuteurVM)
	{
        FiltrageAuteurVM = filtrageAuteurVM;
		InitializeComponent();
		BindingContext = this;
	}

    #endregion

    #region Methods

    #endregion
}