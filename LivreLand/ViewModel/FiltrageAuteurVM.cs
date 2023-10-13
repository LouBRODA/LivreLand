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
    public class FiltrageAuteurVM : BaseViewModel
    {
        #region Properties

        public NavigatorVM Navigator { get; private set; }

        public ManagerVM Manager { get; private set; }

        public ICommand NavigateAuthorPageCommand { get; private set; }

        #endregion

        #region Constructor

        public FiltrageAuteurVM(NavigatorVM navigatorVM, ManagerVM managerVM)
        {
            Navigator = navigatorVM;
            Manager = managerVM;
            NavigateAuthorPageCommand = new RelayCommand(() => NavigateAuthorPage());
        }

        #endregion

        #region Methods

        private async Task NavigateAuthorPage()
        {
            Manager.GetBooksByAuthorCommand.Execute(null);
            Navigator.NavigationCommand.Execute("/tous");
        }

        #endregion
    }
}
