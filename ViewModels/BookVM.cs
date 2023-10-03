using Model;
using PersonalMVVMToolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class BookVM : BaseViewModel<Book>
    {

        #region Fields

        private Book model;

        #endregion

        #region Properties

        public Book Model
        {
            get => model;
            set => model = value;
        }

        public string Title
        {
            get => model.Title;
            set
            {
                model.Title = value;
            }
        }

        //public float? UserRating
        //{
        //    get => Model?.UserRating;
        //    set
        //    {
        //        if (Model == null) return;
        //        SetProperty(Model.UserRating = value, rating => Model.UserRating);
        //    }
        //}

        #endregion

        #region Constructor

        public BookVM(Book model)
        {
            Model = model;
        }

        #endregion
    }
}
