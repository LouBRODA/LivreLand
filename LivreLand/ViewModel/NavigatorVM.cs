using CommunityToolkit.Maui.Views;
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
    public class NavigatorVM
    {
        #region Properties

        public ICommand NavigationCommand { get; }
        public ICommand PopupHomePlusNavigationCommand { get; }
        public ICommand PopupISBNNavigationCommand { get; }
        public ICommand PopupBackButtonNavigationCommand { get; }

        #endregion

        #region Constructor

        public NavigatorVM()
        {
            NavigationCommand = new Command(async (target) => await Shell.Current.GoToAsync($"//library/{target}"));

            PopupHomePlusNavigationCommand = new Command(() => App.Current.MainPage.ShowPopup(new PopupHomePlusButtonView(this)));
            PopupISBNNavigationCommand = new Command(() => App.Current.MainPage.ShowPopup(new PopupISBNView(Application.Current.Handler.MauiContext.Services.GetService<PopupISBNVM>())));
            PopupBackButtonNavigationCommand = new Command(() => App.Current.MainPage.Navigation.PopAsync());
        }

        #endregion

        #region Methods

        #endregion
    }
}
