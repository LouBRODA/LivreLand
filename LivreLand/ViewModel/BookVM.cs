using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivreLand.ViewModel
{
    class BookVM
    {
        public Book Model
        {
            get => model;
            set => model = value;
        }
        private Book model;

        public BookVM()
        {
            Model = model;
        }

        public string Title
        {
            get => model.Title;
            set
            {
                model.Title = value;
            }
        }
    }
}
