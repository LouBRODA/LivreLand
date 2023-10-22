using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LivreLand.View;
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
    public partial class TousVM
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

        public TousVM(NavigatorVM navigatorVM, ManagerVM managerVM)
        {
            Navigator = navigatorVM;
            Manager = managerVM;
        }

        #endregion

        #region Methods

        [RelayCommand]
        private void OnSelectionChanged(BookVM bookVM)
        {
            if (bookVM != null)
            {
                var result = new DetailsLivreVM(Manager, Navigator, bookVM);
                App.Current.MainPage.Navigation.PushAsync(new DetailsLivreView(result));
            }
        }

        #endregion
    }
}
