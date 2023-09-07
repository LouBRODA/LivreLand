using LivreLand.Model;

namespace LivreLand.View;

public partial class TousView : ContentPage
{
	public List<BookModel> AllBooks { get; set; } = new List<BookModel>()
	{
		new BookModel("Alain Damasio","La horde du contrevent","Non lu", 0),
		new BookModel("Alain Damasio",".La zone du dehors","Terminé", 0),
		new BookModel("Cixin Liu","L'équateur d'Einstein","Non lu", 0)
    };

	public TousView()
	{
		BindingContext = this;
		InitializeComponent();
	}
}