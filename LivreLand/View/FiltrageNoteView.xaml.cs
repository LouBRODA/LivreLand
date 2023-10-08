using LivreLand.ViewModel;

namespace LivreLand.View;

public partial class FiltrageNoteView : ContentPage
{
    #region Properties

    public FiltrageNoteVM FiltrageNoteVM { get; set; }

    #endregion

    #region Constructor

    public FiltrageNoteView(FiltrageNoteVM filtrageNoteVM)
    {
        FiltrageNoteVM = filtrageNoteVM;
        InitializeComponent();
        BindingContext = this;
    }

    #endregion

    #region Methods

    protected override void OnAppearing()
    {
        base.OnAppearing();

        FiltrageNoteVM.Manager.GetAllRatingsCommand.Execute(null);
    }

    #endregion
}