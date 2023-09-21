using LivreLand.View.ContentViews;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Graphics;
using CommunityToolkit.Maui.Views;
using System.Windows.Input;
using LivreLand.ViewModel;

namespace LivreLand.View;

public partial class HeaderPage : ContentView
{

    #region Properties

    public NavigatorVM Navigator { get; private set; }

    public static readonly BindableProperty HeaderTitleProperty = BindableProperty.Create(nameof(HeaderTitle), typeof(string), typeof(HeaderPage), string.Empty);
    public string HeaderTitle
    {
        get => (string)GetValue(HeaderPage.HeaderTitleProperty);
        set => SetValue(HeaderPage.HeaderTitleProperty, value);
    }

    public static readonly BindableProperty HeaderBackButtonTextProperty = BindableProperty.Create(nameof(HeaderBackButtonText), typeof(string), typeof(HeaderPage), string.Empty);
    public string HeaderBackButtonText
    {
        get => (string)GetValue(HeaderPage.HeaderBackButtonTextProperty);
        set => SetValue(HeaderPage.HeaderBackButtonTextProperty, value);
    }

    public static readonly BindableProperty HeaderPlusButtonVisibleProperty = BindableProperty.Create(nameof(HeaderPlusButtonVisible), typeof(bool), typeof(HeaderPage), true);
    public bool HeaderPlusButtonVisible
    {
        get => (bool)GetValue(HeaderPage.HeaderPlusButtonVisibleProperty);
        set => SetValue(HeaderPage.HeaderPlusButtonVisibleProperty, value);
    }

    public static readonly BindableProperty HeaderSwitchButtonVisibleProperty = BindableProperty.Create(nameof(HeaderSwitchButtonVisible), typeof(bool), typeof(HeaderPage), true);
    public bool HeaderSwitchButtonVisible
    {
        get => (bool)GetValue(HeaderPage.HeaderSwitchButtonVisibleProperty);
        set => SetValue(HeaderPage.HeaderSwitchButtonVisibleProperty, value);
    }

    public static readonly BindableProperty HeaderColorProperty = BindableProperty.Create(nameof(HeaderColor), typeof(Color), typeof(HeaderPage), Colors.White);
    public Color HeaderColor
    {
        get => (Color)GetValue(HeaderPage.HeaderColorProperty);
        set => SetValue(HeaderPage.HeaderColorProperty, value);
    }

    public static readonly BindableProperty ButtonPlusTappedCommandProperty = BindableProperty.Create(nameof(ButtonPlusTappedCommand), typeof(ICommand), typeof(HeaderPage));
    public ICommand ButtonPlusTappedCommand
    {
        get { return (ICommand)GetValue(ButtonPlusTappedCommandProperty); }
        set { SetValue(ButtonPlusTappedCommandProperty, value); }
    }

    public static readonly BindableProperty ButtonBackTappedCommandProperty = BindableProperty.Create(nameof(ButtonBackTappedCommand), typeof(ICommand), typeof(HeaderPage));
    public ICommand ButtonBackTappedCommand
    {
        get { return (ICommand)GetValue(ButtonBackTappedCommandProperty); }
        set { SetValue(ButtonBackTappedCommandProperty, value); }
    }

    #endregion

    #region Constructor

    public HeaderPage()
	{
		InitializeComponent();
	}

    #endregion

}