using LivreLand.ViewModel;

namespace LivreLand.View;

public partial class FiltrageDateView : ContentPage
{
    #region Properties

    public FiltrageDateVM FiltrageDateVM { get; set; }

    #endregion

    #region Constructor

    public FiltrageDateView(FiltrageDateVM filtrageDateVM)
    {
        FiltrageDateVM = filtrageDateVM;
        InitializeComponent();
        BindingContext = this;
    }

    #endregion

    #region Methods

    protected override void OnAppearing()
    {
        base.OnAppearing();

        FiltrageDateVM.Manager.GetAllPublishDatesCommand.Execute(null);
    }

    #endregion
}