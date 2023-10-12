using LivreLand.ViewModel;
using System.Windows.Input;

namespace LivreLand.View.ContentViews;

public partial class EmpruntsPretsButtonView : ContentView
{
    #region Properties

    public static readonly BindableProperty PretButtonBackgroundColorProperty = BindableProperty.Create(nameof(PretButtonBackgroundColor), typeof(Color), typeof(EmpruntsPretsButtonView));
    public Color PretButtonBackgroundColor
    {
        get => (Color)GetValue(EmpruntsPretsButtonView.PretButtonBackgroundColorProperty);
        set => SetValue(EmpruntsPretsButtonView.PretButtonBackgroundColorProperty, value);
    }

    public static readonly BindableProperty PretButtonIsEnabledProperty = BindableProperty.Create(nameof(PretButtonIsEnabled), typeof(bool), typeof(EmpruntsPretsButtonView));
    public bool PretButtonIsEnabled
    {
        get => (bool)GetValue(EmpruntsPretsButtonView.PretButtonIsEnabledProperty);
        set => SetValue(EmpruntsPretsButtonView.PretButtonIsEnabledProperty, value);
    }

    public static readonly BindableProperty PretsButtonCommandProperty = BindableProperty.Create(nameof(PretsButtonCommand), typeof(ICommand), typeof(EmpruntsPretsButtonView));
    public ICommand PretsButtonCommand
    {
        get { return (ICommand)GetValue(PretsButtonCommandProperty); }
        set { SetValue(PretsButtonCommandProperty, value); }
    }

    public static readonly BindableProperty EmpruntButtonBackgroundColorProperty = BindableProperty.Create(nameof(EmpruntButtonBackgroundColor), typeof(Color), typeof(EmpruntsPretsButtonView));
    public Color EmpruntButtonBackgroundColor
    {
        get => (Color)GetValue(EmpruntsPretsButtonView.EmpruntButtonBackgroundColorProperty);
        set => SetValue(EmpruntsPretsButtonView.EmpruntButtonBackgroundColorProperty, value);
    }

    public static readonly BindableProperty EmpruntButtonIsEnabledProperty = BindableProperty.Create(nameof(EmpruntButtonIsEnabled), typeof(bool), typeof(EmpruntsPretsButtonView));
    public bool EmpruntButtonIsEnabled
    {
        get => (bool)GetValue(EmpruntsPretsButtonView.EmpruntButtonIsEnabledProperty);
        set => SetValue(EmpruntsPretsButtonView.EmpruntButtonIsEnabledProperty, value);
    }

    public static readonly BindableProperty EmpruntsButtonCommandProperty = BindableProperty.Create(nameof(EmpruntsButtonCommand), typeof(ICommand), typeof(EmpruntsPretsButtonView));
    public ICommand EmpruntsButtonCommand
    {
        get { return (ICommand)GetValue(EmpruntsButtonCommandProperty); }
        set { SetValue(EmpruntsButtonCommandProperty, value); }
    }
    #endregion

    #region Constructor

    public EmpruntsPretsButtonView()
	{
		InitializeComponent();
	}

    #endregion
}