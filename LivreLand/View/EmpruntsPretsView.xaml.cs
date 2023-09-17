using LivreLand.Model;

namespace LivreLand.View;

public partial class EmpruntsPretsView : ContentPage
{
    public List<BookModel> AntoineBooks { get; set; } = new List<BookModel>()
    {
        new BookModel("The Wake","Scott Snyder","Terminé", 0),
    };

    public List<BookModel> AudreyPoucletBooks { get; set; } = new List<BookModel>()
    {
        new BookModel("Les feux de Cibola","James S. A. Corey","Terminé", 0),
    };

    public EmpruntsPretsView()
	{
        BindingContext = this;
        InitializeComponent();
	}

    void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        App.Current.MainPage.Navigation.PushAsync(new DetailsLivreView());
    }
}