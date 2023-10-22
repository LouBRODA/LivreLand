using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LivreLand.View;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ViewModels;

namespace LivreLand.ViewModel
{
    [ObservableObject]
    public partial class EmpruntsPretsVM
    {
        #region Fields

        [ObservableProperty]
        private NavigatorVM navigator;

        [ObservableProperty]
        private ManagerVM manager;

        [ObservableProperty]
        private Color pretButtonBackgroundColor = Colors.White;

        [ObservableProperty]
        private bool pretButtonIsEnabled = true;

        [ObservableProperty]
        private Color empruntButtonBackgroundColor = Colors.Transparent;

        [ObservableProperty]
        private bool empruntButtonIsEnabled = false;

        [ObservableProperty]
        private bool pretCollectionIsVisible = true;

        [ObservableProperty]
        private bool empruntCollectionIsVisible = false;

        #endregion

        #region Properties

        #endregion

        #region Constructor

        public EmpruntsPretsVM(NavigatorVM navigatorVM, ManagerVM managerVM)
        {
            Navigator = navigatorVM;
            Manager = managerVM;
        }

        #endregion

        #region Methods

        [RelayCommand]
        private void OnSelectionLoanChanged(LoanVM loanVM)
        {
            if (loanVM != null)
            {
                foreach (var b in Manager.CurrentLoans)
                {
                    if (b.Book.Id == loanVM.Book.Id)
                    {
                        var bookCorresponding = b.Book;
                        var result = new DetailsLivreVM(Manager, Navigator, bookCorresponding);
                        App.Current.MainPage.Navigation.PushAsync(new DetailsLivreView(result));
                    }
                }
            }
        }

        [RelayCommand]
        private void OnSelectionBorrowingChanged(BorrowingVM borrowingVM)
        {
            if (borrowingVM != null)
            {
                foreach (var b in Manager.CurrentBorrowings)
                {
                    if (b.Book.Id == borrowingVM.Book.Id)
                    {
                        var bookCorresponding = b.Book;
                        var result = new DetailsLivreVM(Manager, Navigator, bookCorresponding);
                        App.Current.MainPage.Navigation.PushAsync(new DetailsLivreView(result));
                    }
                }
            }
        }

        [RelayCommand]
        public void PretsButtonClicked()
        {
            if (App.Current.PlatformAppTheme == AppTheme.Light)
            {
                PretButtonBackgroundColor = Colors.Transparent;
                PretButtonIsEnabled = false;
                EmpruntButtonBackgroundColor = Colors.White;
                EmpruntButtonIsEnabled = true;
            }
            else
            {
                PretButtonBackgroundColor = Colors.Transparent;
                PretButtonIsEnabled = false;
                EmpruntButtonBackgroundColor = Colors.Black;
                EmpruntButtonIsEnabled = true;
            }
            PretCollectionIsVisible = false;
            EmpruntCollectionIsVisible = true;
        }

        [RelayCommand]
        public void EmpruntsButtonClicked()
        {
            if (App.Current.PlatformAppTheme == AppTheme.Light)
            {
                PretButtonBackgroundColor = Colors.White;
                PretButtonIsEnabled = true;
                EmpruntButtonBackgroundColor = Colors.Transparent;
                EmpruntButtonIsEnabled = false;
            }
            else
            {
                PretButtonBackgroundColor = Colors.Black;
                PretButtonIsEnabled = true;
                EmpruntButtonBackgroundColor = Colors.Transparent;
                EmpruntButtonIsEnabled = false;
            }
            PretCollectionIsVisible = true;
            EmpruntCollectionIsVisible = false;
        }

        #endregion
    }
}
