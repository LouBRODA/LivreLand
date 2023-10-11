using LivreLand.Model;
using LivreLand.ViewModel;

namespace LivreLand.View;

public partial class StatutLectureView : ContentPage
{
    #region Properties

    public StatutLectureVM StatutLectureVM { get; set; }

    #endregion

    #region Constructor

    public StatutLectureView(StatutLectureVM statutLectureVM)
	{
        StatutLectureVM = statutLectureVM;
        InitializeComponent();
        BindingContext = this;
	}

    #endregion

    #region Methods

    protected override void OnAppearing()
    {
        base.OnAppearing();

        StatutLectureVM.Manager.GetBooksFromCollectionCommand.Execute(null);
    }

    void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        //App.Current.MainPage.Navigation.PushAsync(new DetailsLivreView());
    }

    #endregion
}