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

    void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
	{
        if (e.CurrentSelection.FirstOrDefault() is BookVM)
        {
            var result = new DetailsLivreVM(TousVM.Manager, TousVM.Navigator, e.CurrentSelection.FirstOrDefault() as BookVM);
            App.Current.MainPage.Navigation.PushAsync(new DetailsLivreView(result));
        }
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

        TousVM.Manager.GetBooksFromCollectionCommand.Execute(null);
    }

    #endregion
}