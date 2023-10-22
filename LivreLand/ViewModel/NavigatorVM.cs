using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LivreLand.View;
using LivreLand.View.ContentViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LivreLand.ViewModel
{
    [ObservableObject]
    public partial class NavigatorVM
    {
        #region Fields

        #endregion

        #region Properties

        #endregion

        #region Constructor

        public NavigatorVM()
        {

        }

        #endregion

        #region Methods

        [RelayCommand]
        private async Task Navigation(string target)
        {
            await Shell.Current.GoToAsync($"//library/{target}");
        }

        [RelayCommand]
        private async Task PopupHomePlusNavigation()
        {
            await App.Current.MainPage.ShowPopupAsync(new PopupHomePlusButtonView(this));
        }

        [RelayCommand]
        private async Task PopupISBNNavigation()
        {
            await App.Current.MainPage.ShowPopupAsync(new PopupISBNView(Application.Current.Handler.MauiContext.Services.GetService<PopupISBNVM>()));
        }

        [RelayCommand]
        private async Task PopupBackButtonNavigation()
        {
            await App.Current.MainPage.Navigation.PopAsync();
        }

        #endregion
    }
}
