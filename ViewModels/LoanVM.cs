using Model;
using PersonalMVVMToolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class LoanVM : BaseViewModel<Loan>
    {
        #region Fields

        #endregion

        #region Properties

        public string Id
        {
            get => Model.Id;
            set => SetProperty(Model.Id, value, v => Model.Id = value);
        }

        public BookVM Book
        {
            get => new BookVM(Model.Book);
        }

        public ContactVM Loaner
        {
            get => new ContactVM(Model.Loaner);
        }

        public DateTime LoanedAt
        {
            get => Model.LoanedAt;
            set => SetProperty(Model.LoanedAt, value, v => Model.LoanedAt = value);
        }

        public DateTime? ReturnedAt
        {
            get => Model.ReturnedAt;
            set => SetProperty(Model.ReturnedAt, value, v => Model.ReturnedAt = value);
        }

        #endregion

        #region Constructor

        public LoanVM(Loan l) : base(l)
        {

        }

        #endregion
    }
}
