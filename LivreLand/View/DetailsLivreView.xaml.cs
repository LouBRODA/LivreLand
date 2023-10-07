using LivreLand.ViewModel;

namespace LivreLand.View;

public partial class DetailsLivreView : ContentPage
{
    #region Properties

    public DetailsLivreVM DetailsLivreVM { get; set; }

    #endregion

    #region Constructor

    public DetailsLivreView(DetailsLivreVM detailsLivreVM)
	{
		DetailsLivreVM = detailsLivreVM;
		InitializeComponent();
		BindingContext = this;
	}

    #endregion
}