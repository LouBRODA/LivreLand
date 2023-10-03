using LivreLand.Model;
using LivreLand.ViewModel;
using ViewModels;

namespace LivreLand.View;

public partial class TousView : ContentPage
{

    #region Properties

    public List<BookModel> DamasioBooks { get; set; } = new List<BookModel>()
	{
		new BookModel("La horde du contrevent","Alain Damasio","Non lu", 0),
		new BookModel("La zone du dehors","Alain Damasio","Terminé", 0),
    };

    public List<BookModel> LiuBooks { get; set; } = new List<BookModel>()
    {
        new BookModel("L'équateur d'Einstein","Cixin Liu","Terminé", 0),
        new BookModel("La forêt sombre","Cixin Liu","Terminé", 0),
        new BookModel("Le problème à trois corps","Cixin Liu","Terminé", 0)
    };

    #endregion

    #region Constructor

    public TousView(TousVM tousVM)
	{
		InitializeComponent();
        BindingContext = this;
    }

    #endregion

    #region Methods

    void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		App.Current.MainPage.Navigation.PushAsync(new DetailsLivreView());
	}

    #endregion
}