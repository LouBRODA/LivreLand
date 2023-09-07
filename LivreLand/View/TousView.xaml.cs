using LivreLand.Model;

namespace LivreLand.View;

public partial class TousView : ContentPage
{
	public List<BookModel> AllBooks { get; set; } = new List<BookModel>()
	{
		new BookModel("La horde du contrevent","Alain Damasio","Non lu", 0),
		new BookModel("La zone du dehors","Alain Damasio","Termin�", 0),
		new BookModel("L'�quateur d'Einstein","Cixin Liu","Non lu", 0)
    };

    public TousView()
	{
		BindingContext = this;
		InitializeComponent();
	}
}