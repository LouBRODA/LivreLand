using LivreLand.Model;

namespace LivreLand.View;

public partial class TousView : ContentPage
{
	public List<BookModel> DamasioBooks { get; set; } = new List<BookModel>()
	{
		new BookModel("La horde du contrevent","Alain Damasio","Non lu", 0),
		new BookModel("La zone du dehors","Alain Damasio","Termin�", 0),
    };

    public List<BookModel> LiuBooks { get; set; } = new List<BookModel>()
    {
        new BookModel("L'�quateur d'Einstein","Cixin Liu","Termin�", 0),
        new BookModel("La for�t sombre","Cixin Liu","Termin�", 0),
        new BookModel("Le probl�me � trois corps","Cixin Liu","Termin�", 0)
    };

    public TousView()
	{
		BindingContext = this;
		InitializeComponent();
	}

	void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		App.Current.MainPage.Navigation.PushAsync(new DetailsLivreView());
	}
}