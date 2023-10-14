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
    public class ContactsVM : BaseViewModel
    {
        #region Fields

        private bool dataFormIsVisible = false;

        #endregion

        #region Properties

        public NavigatorVM Navigator { get; private set; }

        public ManagerVM Manager { get; private set; }

        public bool DataFormIsVisible
        {
            get { return dataFormIsVisible; }
            set
            {
                if (dataFormIsVisible != value)
                {
                    dataFormIsVisible = value;
                    OnPropertyChanged(nameof(DataFormIsVisible));
                }
            }
        }

        public ICommand AddContactDataFormCommand { get; private set; }

        public ICommand BookLendedCommand { get; private set; }

        #endregion

        #region Constructor

        public ContactsVM(NavigatorVM navigatorVM, ManagerVM managerVM)
        {
            Navigator = navigatorVM;
            Manager = managerVM;
            AddContactDataFormCommand = new RelayCommand(() => AddContactDataForm());
            BookLendedCommand = new RelayCommand<ContactVM>((contactVM) => BookLended(contactVM));
        }

        #endregion

        #region Methods

        private void AddContactDataForm()
        {
            DataFormIsVisible = true;
        }

        private async Task BookLended(ContactVM contactVM)
        {
            Manager.LendBookCommand.Execute(contactVM);

            var toast = Toast.Make("Livre prêté !", CommunityToolkit.Maui.Core.ToastDuration.Short);
            await toast.Show();

            Navigator.PopupBackButtonNavigationCommand.Execute(null);
        }

        #endregion
    }
}
