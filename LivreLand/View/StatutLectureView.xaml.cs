using LivreLand.Model;

namespace LivreLand.View;

public partial class StatutLectureView : ContentPage
{
    public List<BookModel> NonLuBooks { get; set; } = new List<BookModel>()
    {
        new BookModel("La horde du contrevent","Alain Damasio","Non lu", 0),
    };

    public List<BookModel> TermineBooks { get; set; } = new List<BookModel>()
    {
        new BookModel("La zone du dehors","Alain Damasio","Terminé", 0),
        new BookModel("L'équateur d'Einstein","Cixin Liu","Terminé", 0),
        new BookModel("La forêt sombre","Cixin Liu","Terminé", 0),
        new BookModel("Le problème à trois corps","Cixin Liu","Terminé", 0)
    };

    public StatutLectureView()
	{
        BindingContext = this;
        InitializeComponent();
	}

    void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        App.Current.MainPage.Navigation.PushAsync(new DetailsLivreView());
    }
}