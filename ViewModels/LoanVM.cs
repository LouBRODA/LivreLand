using CommunityToolkit.Mvvm.ComponentModel;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class LoanVM : ObservableObject
    {
        #region Fields

        #endregion

        #region Properties

        public Loan Model { get; }

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

        public LoanVM(Loan l)
        {
            Model = l;
        }

        #endregion
    }
}