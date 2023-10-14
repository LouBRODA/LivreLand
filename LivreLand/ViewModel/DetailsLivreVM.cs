using CommunityToolkit.Maui.Alerts;
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

        private bool isPickerVisible;

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

        public ICommand ShowPickerCommand { get; private set; }

        public ICommand AddBookToFavoritesCommand { get; private set; }

        public ICommand AddBookToReadListCommand { get; private set; }

        public ICommand RemoveBookCommand { get; private set; }

        #endregion

        #region Constructor

        public DetailsLivreVM(ManagerVM managerVM, NavigatorVM navigatorVM, BookVM bookVM) 
        {
            Manager = managerVM;
            Navigator = navigatorVM;
            Book = bookVM;
            ShowPickerCommand = new RelayCommand(() => ShowPicker());
            AddBookToFavoritesCommand = new RelayCommand<BookVM>((bookVM) => AddBookToFavorites(bookVM));
            AddBookToReadListCommand = new RelayCommand<BookVM>((bookVM) => AddBookToReadList(bookVM));
            RemoveBookCommand = new RelayCommand<BookVM>((bookVM) => RemoveBook(bookVM));
        }

        #endregion

        #region Methods

        private void ShowPicker()
        {
            IsPickerVisible = true;
        }

        private async Task AddBookToFavorites(BookVM bookVM)
        {
            Manager.AddToFavoritesCommand.Execute(bookVM);

            var toast = Toast.Make("Livre ajouté aux favoris !", CommunityToolkit.Maui.Core.ToastDuration.Short);
            await toast.Show();

            Navigator.NavigationCommand.Execute("/favoris");
        }

        private async Task AddBookToReadList(BookVM bookVM)
        {
            Manager.UpdateToBeReadBookCommand.Execute(bookVM);

            var toast = Toast.Make("Livre ajouté à la liste À lire plus tard !", CommunityToolkit.Maui.Core.ToastDuration.Short);
            await toast.Show();

            Navigator.NavigationCommand.Execute("/later");
        }

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
