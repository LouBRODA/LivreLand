using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
    public partial class BibliothequeVM
    {
        #region Fields

        [ObservableProperty]
        private NavigatorVM navigator;

        [ObservableProperty]
        private ManagerVM manager;

        #endregion

        #region Properties

        #endregion

        #region Constructor

        public BibliothequeVM(NavigatorVM navigatorVM, ManagerVM managerVM)
        {
            Navigator = navigatorVM;
            Manager = managerVM;
        }

        #endregion

        #region Methods

        [RelayCommand]
        private void AllBooksNavigate()
        {
            Manager.GetBooksFromCollectionCommand.Execute(null);
            Navigator.NavigationCommand.Execute("/tous");
        }

        [RelayCommand]
        private void AllLoansBorrowingsNavigate()
        {
            Manager.GetCurrentLoansCommand.Execute(null);
            Manager.GetCurrentBorrowingsCommand.Execute(null);
            Navigator.NavigationCommand.Execute("/pret");
        }

        [RelayCommand]
        private void AllFavorisBooksNavigate()
        {
            Manager.GetFavoriteBooksCommand.Execute(null);
            Navigator.NavigationCommand.Execute("/favoris");
        }

        [RelayCommand]
        private void AllStatusBooksNavigate()
        {
            Manager.GetBooksFromCollectionCommand.Execute(null);
            Navigator.NavigationCommand.Execute("/statut");
        }

        [RelayCommand]
        private void AllToReadBooksNavigate()
        {
            Manager.GetToBeReadBooksCommand.Execute(null);
            Navigator.NavigationCommand.Execute("/later");
        }

        [RelayCommand]
        private void AllAuthorsNavigate()
        {
            Manager.GetAllAuthorsCommand.Execute(null);
            Navigator.NavigationCommand.Execute("/auteur");
        }

        [RelayCommand]
        private void AllDatesNavigate()
        {
            Manager.GetAllPublishDatesCommand.Execute(null);
            Navigator.NavigationCommand.Execute("/date");
        }

        [RelayCommand]
        private void AllRatingsNavigate()
        {
            Manager.GetAllRatingsCommand.Execute(null);
            Navigator.NavigationCommand.Execute("/note");
        }

        #endregion
    }
}
