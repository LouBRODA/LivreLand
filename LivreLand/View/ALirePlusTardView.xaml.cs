using LivreLand.Model;

namespace LivreLand.View;

public partial class ALirePlusTardView : ContentPage
{
    public List<BookModel> ALirePlusTardBooks { get; set; } = new List<BookModel>()
    {
        new BookModel("La horde du contrevent","Alain Damasio","Non lu", 0),
    };

    public ALirePlusTardView()
	{
        BindingContext = this;
        InitializeComponent();
	}

    void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        //App.Current.MainPage.Navigation.PushAsync(new DetailsLivreView());
    }
}