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
    public partial class FiltrageNoteVM
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

        public FiltrageNoteVM(NavigatorVM navigatorVM, ManagerVM managerVM)
        {
            Navigator = navigatorVM;
            Manager = managerVM;
        }

        #endregion

        #region Methods

        [RelayCommand]
        private void NavigateRatingPage()
        {
            Manager.GetBooksByRatingCommand.Execute(null);
            Navigator.NavigationCommand.Execute("/tous");
        }

        #endregion
    }
}
