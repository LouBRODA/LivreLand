using System.Windows.Input;

namespace LivreLand.View;

public partial class BibliothequeView : ContentPage
{
    public ICommand TousNavigationCommand { get; }
    public ICommand EmpruntsPretsNavigationCommand { get; }
    public ICommand ALirePlusTardNavigationCommand { get; }
    public ICommand StatutLectureNavigationCommand { get; }
    public ICommand FavorisNavigationCommand { get; }
    public ICommand AuteurNavigationCommand { get; }
    public ICommand DatePublicationNavigationCommand { get; }
    public ICommand NoteNavigationCommand { get; }

    public BibliothequeView()
	{
        TousNavigationCommand = new Command(TousNavigation);
        EmpruntsPretsNavigationCommand = new Command(EmpruntsPretsNavigation);
        ALirePlusTardNavigationCommand = new Command(ALirePlusTardNavigation);
        StatutLectureNavigationCommand = new Command(StatutLectureNavigation);
        FavorisNavigationCommand = new Command(FavorisNavigation);
        AuteurNavigationCommand = new Command(AuteurNavigation);
        DatePublicationNavigationCommand = new Command(DatePublicationNavigation);
        NoteNavigationCommand = new Command(NoteNavigation);
        InitializeComponent();
    }

    //Gestion de la navigation temporaire
    private async void TousNavigation()
    {
        await App.Current.MainPage.Navigation.PushAsync(new TousView());
    }

    private async void EmpruntsPretsNavigation()
    {
        await App.Current.MainPage.Navigation.PushAsync(new EmpruntsPretsView());
    }

    private async void ALirePlusTardNavigation()
    {
        await App.Current.MainPage.Navigation.PushAsync(new ALirePlusTardView());
    }

    private async void StatutLectureNavigation()
    {
        await App.Current.MainPage.Navigation.PushAsync(new StatutLectureView());
    }

    private async void AuteurNavigation()
    {
        await App.Current.MainPage.Navigation.PushAsync(new FiltrageAuteurView());
    }

    private async void FavorisNavigation()
    {
        await App.Current.MainPage.Navigation.PushAsync(new FavorisView());
    }

    private async void DatePublicationNavigation()
    {
        await App.Current.MainPage.Navigation.PushAsync(new FiltrageDateView());
    }

    private async void NoteNavigation()
    {
        await App.Current.MainPage.Navigation.PushAsync(new FiltrageNoteView());
    }
}