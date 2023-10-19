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
    public class PopupISBNVM : BaseViewModel
    {
        #region Properties

        public NavigatorVM Navigator { get; private set; }

        public ManagerVM Manager { get; private set; }

        public ICommand AddBookCommand { get; private set; }

        #endregion

        #region Constructor

        public PopupISBNVM(NavigatorVM navigatorVM, ManagerVM managerVM)
        {
            Navigator = navigatorVM;
            Manager = managerVM;
            AddBookCommand = new RelayCommand<string>((text) => AddBook(text));
        }

        #endregion

        #region Methods

        private async Task AddBook(string entryText)
        {
            Manager.AddBookCommand.Execute(entryText);

            var toast = Toast.Make("Livre ajouté !", CommunityToolkit.Maui.Core.ToastDuration.Short);
            await toast.Show();

            Manager.GetBooksFromCollectionCommand.Execute(null);
            Navigator.NavigationCommand.Execute("/tous");
        }

        #endregion
    }
}
