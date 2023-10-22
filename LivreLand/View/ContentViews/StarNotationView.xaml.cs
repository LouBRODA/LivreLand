using LivreLand.ViewModel;

namespace LivreLand.View.ContentViews;

public partial class StarNotationView : ContentView
{
    #region Properties

    public static readonly BindableProperty StarNotationProperty = BindableProperty.Create(nameof(StarNotation), typeof(StarNotationVM), typeof(StarNotationView), Application.Current.Handler.MauiContext.Services.GetService<StarNotationVM>());

    public StarNotationVM StarNotation
    {
        get { return (StarNotationVM)GetValue(StarNotationProperty); }
        set { SetValue(StarNotationProperty, value); }
    }

    public StarNotationVM StarNotationVM { get; private set; }

    #endregion

    #region Constructor

    public StarNotationView()
	{
        StarNotationVM = StarNotation;
		InitializeComponent();
	}

    #endregion
}