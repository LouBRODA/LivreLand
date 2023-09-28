using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class BookVM
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

        #endregion

        #region Constructor

        public BookVM(Book model)
        {
            Model = model;
        }

        #endregion
    }
}
