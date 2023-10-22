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
    public partial class FiltrageAuteurVM
    {
        #region Fields

        [ObservableProperty]
        private NavigatorVM navigator;

        [ObservableProperty]
        private ManagerVM manager;

        #endregion

        #region Properties

        #endregion

        #region Constructor

        public FiltrageAuteurVM(NavigatorVM navigatorVM, ManagerVM managerVM)
        {
            Navigator = navigatorVM;
            Manager = managerVM;
        }

        #endregion

        #region Methods

        [RelayCommand]
        private void NavigateAuthorPage()
        {
            Manager.GetBooksByAuthorCommand.Execute(null);
            Navigator.NavigationCommand.Execute("/tous");
        }

        #endregion
    }
}
