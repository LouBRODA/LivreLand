using LivreLand.View;
using Model;
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
            get { return pretButtonBackgroundColor; }
            set
            {
                if (pretButtonBackgroundColor != value)
                {
                    pretButtonBackgroundColor = value;
                    OnPropertyChanged(nameof(PretButtonBackgroundColor));
                }
            }
        }

        public bool PretButtonIsEnabled
        {
            get { return pretButtonIsEnabled; }
            set
            {
                if (pretButtonIsEnabled != value)
                {
                    pretButtonIsEnabled = value;
                    OnPropertyChanged(nameof(PretButtonIsEnabled));
                }
            }
        }

        public Color EmpruntButtonBackgroundColor
        {
            get { return empruntButtonBackgroundColor; }
            set
            {
                if (empruntButtonBackgroundColor != value)
                {
                    empruntButtonBackgroundColor = value;
                    OnPropertyChanged(nameof(EmpruntButtonBackgroundColor));
                }
            }
        }

        public bool EmpruntButtonIsEnabled
        {
            get { return empruntButtonIsEnabled; }
            set
            {
                if (empruntButtonIsEnabled != value)
                {
                    empruntButtonIsEnabled = value;
                    OnPropertyChanged(nameof(EmpruntButtonIsEnabled));
                }
            }
        }

        public bool EmpruntCollectionIsVisible
        {
            get { return empruntCollectionIsVisible; }
            set
            {
                if (empruntCollectionIsVisible != value)
                {
                    empruntCollectionIsVisible = value;
                    OnPropertyChanged(nameof(EmpruntCollectionIsVisible));
                }
            }
        }

        public bool PretCollectionIsVisible
        {
            get { return pretCollectionIsVisible; }
            set
            {
                if (pretCollectionIsVisible != value)
                {
                    pretCollectionIsVisible = value;
                    OnPropertyChanged(nameof(PretCollectionIsVisible));
                }
            }
        }

        public ICommand OnSelectionLoanChangedCommand { get; private set; }

        public ICommand OnSelectionBorrowingChangedCommand { get; private set; }

        public ICommand PretsButtonCommand { get; private set; }

        public ICommand EmpruntsButtonCommand { get; private set; }

        #endregion

        #region Constructor

        public EmpruntsPretsVM(NavigatorVM navigatorVM, ManagerVM managerVM)
        {
            Navigator = navigatorVM;
            Manager = managerVM;
            OnSelectionLoanChangedCommand = new RelayCommand<LoanVM>((loanVM) => OnSelectionLoanChanged(loanVM));
            OnSelectionBorrowingChangedCommand = new RelayCommand<BorrowingVM>((borrowingVM) => OnSelectionBorrowingChanged(borrowingVM));
            PretsButtonCommand = new RelayCommand(() => PretsButtonClicked());
            EmpruntsButtonCommand = new RelayCommand(() => EmpruntsButtonClicked());
        }

        #endregion

        #region Methods

        private void OnSelectionLoanChanged(LoanVM loanVM)
        {
            if (loanVM == null)
            {
                foreach (var b in Manager.AllCurrentLoans)
                {
                    if (b.Book.Id == loanVM.Book.Id)
                    {
                        var bookCorresponding = b.Book;
                        var result = new DetailsLivreVM(Manager, Navigator, bookCorresponding);
                        App.Current.MainPage.Navigation.PushAsync(new DetailsLivreView(result));
                    }
                }
            }
        }

        private void OnSelectionBorrowingChanged(BorrowingVM borrowingVM)
        {
            if (borrowingVM != null)
            {
                foreach (var b in Manager.AllCurrentBorrowings)
                {
                    if (b.Book.Id == borrowingVM.Book.Id)
                    {
                        var bookCorresponding = b.Book;
                        var result = new DetailsLivreVM(Manager, Navigator, bookCorresponding);
                        App.Current.MainPage.Navigation.PushAsync(new DetailsLivreView(result));
                    }
                }
            }
        }

        public void PretsButtonClicked()
        {
            if (App.Current.PlatformAppTheme == AppTheme.Light)
            {
                PretButtonBackgroundColor = Colors.Transparent;
                PretButtonIsEnabled = false;
                EmpruntButtonBackgroundColor = Colors.White;
                EmpruntButtonIsEnabled = true;
            }
            else
            {
                PretButtonBackgroundColor = Colors.Transparent;
                PretButtonIsEnabled = false;
                EmpruntButtonBackgroundColor = Colors.Black;
                EmpruntButtonIsEnabled = true;
            }
            PretCollectionIsVisible = false;
            EmpruntCollectionIsVisible = true;
        }

        public void EmpruntsButtonClicked()
        {
            if (App.Current.PlatformAppTheme == AppTheme.Light)
            {
                PretButtonBackgroundColor = Colors.White;
                PretButtonIsEnabled = true;
                EmpruntButtonBackgroundColor = Colors.Transparent;
                EmpruntButtonIsEnabled = false;
            }
            else
            {
                PretButtonBackgroundColor = Colors.Black;
                PretButtonIsEnabled = true;
                EmpruntButtonBackgroundColor = Colors.Transparent;
                EmpruntButtonIsEnabled = false;
            }
            PretCollectionIsVisible = true;
            EmpruntCollectionIsVisible = false;
        }

        #endregion
    }
}
