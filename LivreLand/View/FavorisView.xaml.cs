using LivreLand.Model;

namespace LivreLand.View;

public partial class FavorisView : ContentPage
{
    public List<BookModel> FavorisBooks { get; set; } = new List<BookModel>()
    {
        new BookModel("La zone du dehors","Alain Damasio","Terminé", 0),
        new BookModel("Le problème à trois corps","Cixin Liu","Terminé", 0)
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