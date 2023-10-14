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
    public class FiltrageDateVM : BaseViewModel
    {
        #region Properties

        public NavigatorVM Navigator { get; private set; }

        public ManagerVM Manager { get; private set; }

        public ICommand NavigateDatePageCommand { get; private set; }

        #endregion

        #region Constructor

        public FiltrageDateVM(NavigatorVM navigatorVM, ManagerVM managerVM)
        {
            Navigator = navigatorVM;
            Manager = managerVM;
            NavigateDatePageCommand = new RelayCommand(() =>  NavigateDatePage());
        }

        #endregion

        #region Methods

        private void NavigateDatePage()
        {
            Manager.GetBooksByDateCommand.Execute(null);
            Navigator.NavigationCommand.Execute("/tous");
        }

        #endregion
    }
}
