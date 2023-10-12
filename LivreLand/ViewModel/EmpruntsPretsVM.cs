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
    public class EmpruntsPretsVM : BaseViewModel
    {
        #region Fields

        private Color pretButtonBackgroundColor = Colors.White;
        private bool pretButtonIsEnabled = true;
        private Color empruntButtonBackgroundColor = Colors.Transparent;
        private bool empruntButtonIsEnabled = false;
        private bool pretCollectionIsVisible = true;
        private bool empruntCollectionIsVisible = false;

        #endregion

        #region Properties

        public NavigatorVM Navigator { get; private set; }

        public ManagerVM Manager { get; private set; }

        public Color PretButtonBackgroundColor
        {
            get => pretButtonBackgroundColor;
            set => pretButtonBackgroundColor = value;
        }

        public bool PretButtonIsEnabled
        {
            get => pretButtonIsEnabled;
            set => pretButtonIsEnabled = value;
        }

        public Color EmpruntButtonBackgroundColor
        {
            get => empruntButtonBackgroundColor;
            set => empruntButtonBackgroundColor = value;
        }

        public bool EmpruntButtonIsEnabled
        {
            get => empruntButtonIsEnabled;
            set => empruntButtonIsEnabled = value;
        }

        public bool EmpruntCollectionIsVisible
        {
            get => empruntCollectionIsVisible;
            set => empruntCollectionIsVisible = value;
        }

        public bool PretCollectionIsVisible
        {
            get => pretCollectionIsVisible;
            set => pretCollectionIsVisible = value;
        }

        public ICommand PretsButtonCommand { get; private set; }

        public ICommand EmpruntsButtonCommand { get; private set; }

        #endregion

        #region Constructor

        public EmpruntsPretsVM(NavigatorVM navigatorVM, ManagerVM managerVM)
        {
            Navigator = navigatorVM;
            Manager = managerVM;
            PretsButtonCommand = new RelayCommand(() => PretsButtonClicked());
            EmpruntsButtonCommand = new RelayCommand(() => EmpruntsButtonClicked());
        }

        #endregion

        #region Methods

        public void PretsButtonClicked()
        {
            if (App.Current.PlatformAppTheme == AppTheme.Light)
            {
                pretButtonBackgroundColor = Colors.Transparent;
                pretButtonIsEnabled = false;
                empruntButtonBackgroundColor = Colors.White;
                empruntButtonIsEnabled = true;
            }
            else
            {
                pretButtonBackgroundColor = Colors.Transparent;
                pretButtonIsEnabled = false;
                empruntButtonBackgroundColor = Colors.Black;
                empruntButtonIsEnabled = true;
            }
            pretCollectionIsVisible = false;
            empruntCollectionIsVisible = true;
        }

        public void EmpruntsButtonClicked()
        {
            if (App.Current.PlatformAppTheme == AppTheme.Light)
            {
                pretButtonBackgroundColor = Colors.White;
                pretButtonIsEnabled = true;
                empruntButtonBackgroundColor = Colors.Transparent;
                empruntButtonIsEnabled = false;
            }
            else
            {
                pretButtonBackgroundColor = Colors.Black;
                pretButtonIsEnabled = true;
                empruntButtonBackgroundColor = Colors.Transparent;
                empruntButtonIsEnabled = false;
            }
            pretCollectionIsVisible = true;
            empruntCollectionIsVisible = false;
        }

        #endregion
    }
}
