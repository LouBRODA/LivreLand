using PersonalMVVMToolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ViewModels;

namespace LivreLand.ViewModel
{
    public class BibliothequeVM : BaseViewModel
    {
        #region Properties

        public NavigatorVM Navigator { get; private set; }

        public ManagerVM Manager { get; private set; }

        public ICommand AllBooksNavigateCommand { get; private set; }

        public ICommand AllLoansBorrowingsNavigateCommand { get; private set; }

        public ICommand AllFavorisBooksNavigateCommand { get; private set; }

        public ICommand AllStatusBooksNavigateCommand { get; private set; }

        public ICommand AllToReadBooksNavigateCommand { get; private set; }

        public ICommand AllAuthorsNavigateCommand { get; private set; }

        public ICommand AllDatesNavigateCommand { get; private set; }

        public ICommand AllRatingsNavigateCommand { get; private set; }

        #endregion

        #region Constructor

        public BibliothequeVM(NavigatorVM navigatorVM, ManagerVM managerVM)
        {
            Navigator = navigatorVM;
            Manager = managerVM;
            AllBooksNavigateCommand = new RelayCommand(() => AllBooksNavigate());
            AllLoansBorrowingsNavigateCommand = new RelayCommand(() => AllLoansBorrowingsNavigate());
            AllFavorisBooksNavigateCommand = new RelayCommand(() => AllFavorisBooksNavigate());
            AllStatusBooksNavigateCommand = new RelayCommand(() => AllStatusBooksNavigate());
            AllToReadBooksNavigateCommand = new RelayCommand(() => AllToReadBooksNavigate());
            AllAuthorsNavigateCommand = new RelayCommand(() => AllAuthorsNavigate());
            AllDatesNavigateCommand = new RelayCommand(() => AllDatesNavigate());
            AllRatingsNavigateCommand = new RelayCommand(() => AllRatingsNavigate());
        }

        #endregion

        #region Methods

        private void AllBooksNavigate()
        {
            Manager.GetBooksFromCollectionCommand.Execute(null);
            Navigator.NavigationCommand.Execute("/tous");
        }

        private void AllLoansBorrowingsNavigate()
        {
            Manager.GetCurrentLoansCommand.Execute(null);
            Manager.GetCurrentBorrowingsCommand.Execute(null);
            Navigator.NavigationCommand.Execute("/pret");
        }

        private void AllFavorisBooksNavigate()
        {
            Manager.GetFavoriteBooksCommand.Execute(null);
            Navigator.NavigationCommand.Execute("/favoris");
        }

        private void AllStatusBooksNavigate()
        {
            Manager.GetBooksFromCollectionCommand.Execute(null);
            Navigator.NavigationCommand.Execute("/statut");
        }

        private void AllToReadBooksNavigate()
        {
            Manager.GetToBeReadBooksCommand.Execute(null);
            Navigator.NavigationCommand.Execute("/later");
        }

        private void AllAuthorsNavigate()
        {
            Manager.GetAllAuthorsCommand.Execute(null);
            Navigator.NavigationCommand.Execute("/auteur");
        }

        private void AllDatesNavigate()
        {
            Manager.GetAllPublishDatesCommand.Execute(null);
            Navigator.NavigationCommand.Execute("/date");
        }

        private void AllRatingsNavigate()
        {
            Manager.GetAllRatingsCommand.Execute(null);
            Navigator.NavigationCommand.Execute("/note");
        }

        #endregion
    }
}
