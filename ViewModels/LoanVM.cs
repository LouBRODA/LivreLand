using CommunityToolkit.Mvvm.ComponentModel;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    [ObservableObject]
    public partial class LoanVM
    {
        #region Fields

        [ObservableProperty]
        private string id;

        [ObservableProperty]
        private BookVM book;

        [ObservableProperty]
        private ContactVM loaner;

        [ObservableProperty]
        private DateTime loanedAt;

        [ObservableProperty]
        private DateTime? returnedAt;

        #endregion

        #region Properties

        #endregion

        #region Constructor

        public LoanVM(Loan l)
        {

        }

        #endregion
    }
}
