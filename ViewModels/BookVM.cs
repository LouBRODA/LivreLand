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

        #endregion

        #region Properties

        public string ISBN13
        {
            get => Model.ISBN13;
            set => SetProperty(Model.ISBN13, value, v => Model.ISBN13 = value);
        }

        public string Title
        {
            get => Model.Title;
            set => SetProperty(Model.Title, value, v => Model.Title = value);
        }

        public List<string> Publishers
        {
            get => Model.Publishers;
            set => SetProperty(Model.Publishers, value, v => Model.Publishers = value);
        }

        public DateTime PublishDate
        {
            get => Model.PublishDate;
            set => SetProperty(Model.PublishDate, value, v => Model.PublishDate = value);
        }

        //public List<AuthorVM> Authors
        //{
        //    get => model.Authors;
        //    set
        //    {
        //        model.Authors = value;
        //    }
        //}

        public int NbPages
        {
            get => Model.NbPages;
            set => SetProperty(Model.NbPages, value, v => Model.NbPages = value);
        }

        public string ImageSmall
        {
            get => Model.ImageSmall;
        }

        public float? UserRating
        {
            get => Model?.UserRating;
            set
            {
                if (Model == null) return;
                SetProperty(Model.UserRating, value, rating => Model.UserRating = rating);
            }
        }

        #endregion

        #region Constructor

        public BookVM(Book b) : base(b)
        {
            
        }

        #endregion
    }
}
