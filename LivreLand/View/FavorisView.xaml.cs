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

    void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        //App.Current.MainPage.Navigation.PushAsync(new DetailsLivreView());
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        FavorisVM.Manager.GetFavoriteBooksCommand.Execute(null);
    }

    #endregion
}