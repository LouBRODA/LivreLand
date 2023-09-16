namespace LivreLand.View.ContentViews;

public partial class EmpruntsPretsButtonView : ContentView
{
	public EmpruntsPretsButtonView()
	{
		InitializeComponent();
	}

	public void OnPretsClicked(object sender, EventArgs e)
	{
		pretsClicked.BackgroundColor = Colors.Transparent;
		pretsClicked.IsEnabled = false;
		empruntsButton.BackgroundColor = Colors.White;
		empruntsButton.IsEnabled = true;
	}

    public void OnEmpruntsClicked(object sender, EventArgs e)
    {
        pretsClicked.BackgroundColor = Colors.White;
        pretsClicked.IsEnabled = true;
        empruntsButton.BackgroundColor = Colors.Transparent;
        empruntsButton.IsEnabled = false;
    }
}