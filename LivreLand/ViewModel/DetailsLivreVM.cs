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
    public class DetailsLivreVM : BaseViewModel
    {
        #region Fields

        private bool isPickerVisible;

        #endregion

        #region Properties

        public ManagerVM Manager { get; private set; }

        public NavigatorVM Navigator { get; private set; }

        public BookVM Book { get; private set; }

        public bool IsPickerVisible
        {
            get => isPickerVisible;
            set
            {
                if (isPickerVisible != value)
                {
                    isPickerVisible = value;
                    OnPropertyChanged(nameof(IsPickerVisible));
                }
            }
        }

        public ICommand ShowPickerCommand { get; private set; }

        #endregion

        #region Constructor

        public DetailsLivreVM(ManagerVM managerVM, NavigatorVM navigatorVM, BookVM bookVM) 
        {
            Manager = managerVM;
            Navigator = navigatorVM;
            Book = bookVM;
            ShowPickerCommand = new RelayCommand(() => ShowPicker());
        }

        #endregion

        #region Methods

        private void ShowPicker()
        {
            IsPickerVisible = true;
        }

        #endregion
    }
}
