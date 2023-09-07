using System.Windows.Input;

namespace LivreLand.View;

public partial class BibliothequeView : ContentPage
{
    public ICommand FiltreAuteurCommand { get; private set; }

	public BibliothequeView()
	{
		InitializeComponent();

        //Commandes navigation temporaires
        FiltreAuteurCommand = new Command(
            execute: () =>
            {
                App.Current.MainPage.Navigation.PushAsync(new FiltrageAuteurView());
            },
            canExecute: () =>
            {
                return true;
            });
    }
}