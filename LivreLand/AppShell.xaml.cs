using LivreLand.View;

namespace LivreLand;

public partial class AppShell : Shell
{
	public AppShell()
	{
		Routing.RegisterRoute("library/tous/", typeof(TousView));
		Routing.RegisterRoute("library/pret/", typeof(EmpruntsPretsView));
		Routing.RegisterRoute("library/later/", typeof(ALirePlusTardView));
		Routing.RegisterRoute("library/statut/", typeof(StatutLectureView));
		Routing.RegisterRoute("library/favoris/", typeof(FavorisView));
		Routing.RegisterRoute("library/auteur/", typeof(FiltrageAuteurView));
		Routing.RegisterRoute("library/date/", typeof(FiltrageDateView));
		Routing.RegisterRoute("library/note/", typeof(FiltrageNoteView));
        Routing.RegisterRoute("library/tous/details/", typeof(DetailsLivreView));
        InitializeComponent();
	}
}
