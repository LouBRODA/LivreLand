using LivreLand.Model;

namespace LivreLand.View;

public partial class FavorisView : ContentPage
{
    public List<BookModel> FavorisBooks { get; set; } = new List<BookModel>()
    {
        new BookModel("La zone du dehors","Alain Damasio","Termin�", 0),
        new BookModel("Le probl�me � trois corps","Cixin Liu","Termin�", 0)
    };

    public FavorisView()
	{
        BindingContext = this;
        InitializeComponent();
	}

    void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        //App.Current.MainPage.Navigation.PushAsync(new DetailsLivreView());
    }
}