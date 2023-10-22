using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
    public partial class DetailsLivreVM
    {
        #region Fields

        [ObservableProperty]
        private NavigatorVM navigator;

        [ObservableProperty]
        private ManagerVM manager;

        [ObservableProperty]
        private BookVM book;

        [ObservableProperty]
        private bool isPickerVisible = false;

        [ObservableProperty]
        private string addFavorisButtonText;

        #endregion

        #region Properties

        #endregion

        #region Constructor

        public DetailsLivreVM(ManagerVM managerVM, NavigatorVM navigatorVM, BookVM bookVM) 
        {
            Manager = managerVM;
            Navigator = navigatorVM;
            Book = bookVM;
        }

        #endregion

        #region Methods

        [RelayCommand]
        private void BackButton()
        {
            Navigator.PopupBackButtonNavigationCommand.Execute(null);
        }

        [RelayCommand]
        private void ShowPicker()
        {
            Manager.GetAllStatusCommand.Execute(null);
            Manager.SelectedStatus = Book.Status;
            IsPickerVisible = true;
        }

        [RelayCommand]
        private async Task AddRemoveBookToFavorites(BookVM bookVM)
        {
            Manager.CheckBookIsFavoriteCommand.Execute(bookVM);
            if (Manager.IsFavorite == false)
            {
                Manager.AddToFavoritesCommand.Execute(bookVM);
                AddFavorisButtonText = "Supprimer des favoris";
                OnPropertyChanged(nameof(AddFavorisButtonText));

                var toast = Toast.Make("Livre ajouté aux favoris !", CommunityToolkit.Maui.Core.ToastDuration.Short);
                await toast.Show();

                Manager.GetFavoriteBooksCommand.Execute(null);
                Navigator.NavigationCommand.Execute("/favoris");
            }
            else
            {
                Manager.RemoveFromFavoritesCommand.Execute(bookVM);
                AddFavorisButtonText = "Ajouter aux favoris";
                OnPropertyChanged(nameof(AddFavorisButtonText));

                var toast = Toast.Make("Livre supprimé des favoris !", CommunityToolkit.Maui.Core.ToastDuration.Short);
                await toast.Show();

                Manager.GetFavoriteBooksCommand.Execute(null);
                Navigator.NavigationCommand.Execute("/favoris");
            }
        }

        [RelayCommand]
        private async Task AddBookToReadList(BookVM bookVM)
        {
            Manager.UpdateToBeReadBookCommand.Execute(bookVM);

            var toast = Toast.Make("Livre ajouté à la liste À lire plus tard !", CommunityToolkit.Maui.Core.ToastDuration.Short);
            await toast.Show();

            Manager.GetToBeReadBooksCommand.Execute(null);
            Navigator.NavigationCommand.Execute("/later");
        }

        [RelayCommand]
        private void LoanBook(BookVM bookVM)
        {
            Manager.SelectedBook = bookVM;
            Manager.GetContactsCommand.Execute(null);
            Navigator.NavigationCommand.Execute("contacts");
        }

        [RelayCommand]
        private async Task RemoveBook(BookVM bookVM)
        {
            Manager.RemoveBookCommand.Execute(bookVM);

            var toast = Toast.Make("Livre supprimé !", CommunityToolkit.Maui.Core.ToastDuration.Short);
            await toast.Show();

            Navigator.PopupBackButtonNavigationCommand.Execute(null);
        }

        #endregion
    }
}
