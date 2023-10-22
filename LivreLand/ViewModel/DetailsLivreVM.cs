using CommunityToolkit.Maui.Alerts;
using Model;
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
    public class DetailsLivreVM : BaseViewModel
    {
        #region Fields

        private bool isPickerVisible = false;
        private string addFavorisButtonText;

        #endregion

        #region Properties

        public ManagerVM Manager { get; private set; }

        public NavigatorVM Navigator { get; private set; }

        public BookVM Book { get; private set; }

        public bool IsPickerVisible
        {
            get => isPickerVisible;
            set
            {
                if (isPickerVisible != value)
                {
                    isPickerVisible = value;
                    OnPropertyChanged(nameof(IsPickerVisible));
                }
            }
        }
        
        public string AddFavorisButtonText
        {
            get
            {
                Manager.GetFavoriteBooksCommand.Execute(null);
                if (Manager.AllFavoriteBooks.Any(favoriteBook => favoriteBook.Id == Book.Id))
                {
                    return addFavorisButtonText = "Supprimer des favoris";
                }
                else
                {
                    return addFavorisButtonText = "Ajouter aux favoris";
                }
            }
            set
            {
                if (addFavorisButtonText != value)
                {
                    addFavorisButtonText = value;
                    OnPropertyChanged(nameof(AddFavorisButtonText));
                }
            }
        }

        public ICommand BackButtonCommand { get; private set; }

        public ICommand ShowPickerCommand { get; private set; }

        public ICommand AddRemoveBookToFavoritesCommand { get; private set; }

        public ICommand AddBookToReadListCommand { get; private set; }

        public ICommand LoanBookCommand { get; private set; }

        public ICommand RemoveBookCommand { get; private set; }

        public ICommand OpenInfoCommand { get; private set; }

        #endregion

        #region Constructor

        public DetailsLivreVM(ManagerVM managerVM, NavigatorVM navigatorVM, BookVM bookVM) 
        {
            Manager = managerVM;
            Navigator = navigatorVM;
            Book = bookVM;
            BackButtonCommand = new RelayCommand(() => BackButton());
            ShowPickerCommand = new RelayCommand(() => ShowPicker());
            AddRemoveBookToFavoritesCommand = new RelayCommand<BookVM>((bookVM) => AddRemoveBookToFavorites(bookVM));
            AddBookToReadListCommand = new RelayCommand<BookVM>((bookVM) => AddBookToReadList(bookVM));
            LoanBookCommand = new RelayCommand<BookVM>((bookVM) => LoanBook(bookVM));
            RemoveBookCommand = new RelayCommand<BookVM>((bookVM) => RemoveBook(bookVM));
            OpenInfoCommand = new RelayCommand(() => OpenInfo());
        }

        #endregion

        #region Methods

        private void BackButton()
        {
            Navigator.PopupBackButtonNavigationCommand.Execute(null);
        }

        private void ShowPicker()
        {
            Manager.GetAllStatusCommand.Execute(null);
            Manager.SelectedStatus = Book.Status;
            IsPickerVisible = true;
        }

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

        private async Task AddBookToReadList(BookVM bookVM)
        {
            Manager.UpdateToBeReadBookCommand.Execute(bookVM);

            var toast = Toast.Make("Livre ajouté à la liste À lire plus tard !", CommunityToolkit.Maui.Core.ToastDuration.Short);
            await toast.Show();

            Manager.GetToBeReadBooksCommand.Execute(null);
            Navigator.NavigationCommand.Execute("/later");
        }

        private void LoanBook(BookVM bookVM)
        {
            Manager.SelectedBook = bookVM;
            Manager.GetContactsCommand.Execute(null);
            Navigator.NavigationCommand.Execute("contacts");
        }

        private async Task RemoveBook(BookVM bookVM)
        {
            Manager.RemoveBookCommand.Execute(bookVM);

            var toast = Toast.Make("Livre supprimé !", CommunityToolkit.Maui.Core.ToastDuration.Short);
            await toast.Show();

            Navigator.PopupBackButtonNavigationCommand.Execute(null);
        }

        private async Task OpenInfo()
        {
            var isbn = Manager.SelectedBook.ISBN13;
            string url = "https://openlibrary.org/isbn/" + isbn;
            await Launcher.OpenAsync(url);
        }

        #endregion
    }
}
