using LivreLand.View.ContentViews;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Graphics;
using CommunityToolkit.Maui.Views;

namespace LivreLand.View;

public partial class HeaderPage : ContentView
{
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

    public HeaderPage()
	{
		InitializeComponent();
	}

    public void OnBackButtonTapped(object sender, EventArgs e)
    {
        App.Current.MainPage.Navigation.PopAsync();
    }

    public void OnPlusClicked(object sender, EventArgs e)
    {
        var plusPopup = new PopupHomePlusButtonView();
        App.Current.MainPage.ShowPopup(plusPopup);
    }
}