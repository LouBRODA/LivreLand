using LivreLand.View;
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
    public class ALirePlusTardVM : BaseViewModel
    {
        #region Properties

        public NavigatorVM Navigator { get; private set; }

        public ManagerVM Manager { get; private set; }

        public ICommand OnSelectionChangedCommand { get; private set; }

        #endregion

        #region Constructor

        public ALirePlusTardVM(NavigatorVM navigatorVM, ManagerVM managerVM)
        {
            Navigator = navigatorVM;
            Manager = managerVM;
            OnSelectionChangedCommand = new RelayCommand<BookVM>((bookVM) => OnSelectionChanged(bookVM));
        }

        #endregion

        #region Methods

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
