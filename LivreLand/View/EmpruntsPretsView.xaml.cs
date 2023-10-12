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

    void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        //App.Current.MainPage.Navigation.PushAsync(new DetailsLivreView());
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        EmpruntsPretsVM.Manager.GetCurrentLoansCommand.Execute(null);
        EmpruntsPretsVM.Manager.GetCurrentBorrowingsCommand.Execute(null);
    }

    #endregion
}