using CommunityToolkit.Mvvm.ComponentModel;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class BorrowingVM : ObservableObject
    {
        #region Fields

        #endregion

        #region Properties

        public Borrowing Model { get; }

        public string Id
        {
            get => Model.Id;
            set => SetProperty(Model.Id, value, v => Model.Id = value);
        }

        public BookVM Book
        {
            get => new BookVM(Model.Book);
        }

        public ContactVM Owner
        {
            get => new ContactVM(Model.Owner);
        }

        public DateTime BorrowedAt
        {
            get => Model.BorrowedAt;
            set => SetProperty(Model.BorrowedAt, value, v => Model.BorrowedAt = value);
        }

        public DateTime? ReturnedAt
        {
            get => Model.ReturnedAt;
            set => SetProperty(Model.ReturnedAt, value, v => Model.ReturnedAt = value);
        }

        #endregion

        #region Constructor

        public BorrowingVM(Borrowing b)
        {
            Model = b;
        }

        #endregion
    }
}