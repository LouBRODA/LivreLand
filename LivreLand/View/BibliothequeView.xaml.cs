using LivreLand.ViewModel;
using System.Windows.Input;

namespace LivreLand.View;

public partial class BibliothequeView : ContentPage
{
    #region Properties

    public BibliothequeVM BibliothequeVM { get; set; }

    #endregion

    #region Constructor

    public BibliothequeView(BibliothequeVM bibliothequeVM)
	{
        BibliothequeVM = bibliothequeVM;
        InitializeComponent();
        BindingContext = this;
    }

    #endregion

    #region Methods

    protected override void OnAppearing()
    {
        base.OnAppearing();

        BibliothequeVM.Manager.GetBooksFromCollectionCommand.Execute(null);
    }

    #endregion

}