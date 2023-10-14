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
    public class FiltrageNoteVM : BaseViewModel
    {
        #region Properties

        public NavigatorVM Navigator { get; private set; }

        public ManagerVM Manager { get; private set; }

        public ICommand NavigateRatingPageCommand { get; private set; }

        #endregion

        #region Constructor

        public FiltrageNoteVM(NavigatorVM navigatorVM, ManagerVM managerVM)
        {
            Navigator = navigatorVM;
            Manager = managerVM;
            NavigateRatingPageCommand = new RelayCommand(() => NavigateRatingPage());
        }

        #endregion

        #region Methods

        private void NavigateRatingPage()
        {
            Manager.GetBooksByRatingCommand.Execute(null);
            Navigator.NavigationCommand.Execute("/tous");
        }

        #endregion
    }
}
