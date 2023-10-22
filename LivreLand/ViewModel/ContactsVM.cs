using CommunityToolkit.Maui.Alerts;
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
    public partial class ContactsVM
    {
        #region Fields

        [ObservableProperty]
        private NavigatorVM navigator;

        [ObservableProperty]
        private ManagerVM manager;

        [ObservableProperty]
        private bool dataFormIsVisible = false;

        #endregion

        #region Properties

        #endregion

        #region Constructor

        public ContactsVM(NavigatorVM navigatorVM, ManagerVM managerVM)
        {
            Navigator = navigatorVM;
            Manager = managerVM;
        }

        #endregion

        #region Methods

        [RelayCommand]
        private void AddContactDataForm()
        {
            DataFormIsVisible = true;
        }

        [RelayCommand]
        private async Task BookLended(ContactVM contactVM)
        {
            Manager.LendBookCommand.Execute(contactVM);

            var toast = Toast.Make("Livre prêté !", CommunityToolkit.Maui.Core.ToastDuration.Short);
            await toast.Show();

            Manager.GetCurrentLoansCommand.Execute(null);
            Manager.GetCurrentBorrowingsCommand.Execute(null);
            Navigator.NavigationCommand.Execute("/pret");
        }

        #endregion
    }
}
