using CommunityToolkit.Mvvm.ComponentModel;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class AuthorVM : ObservableObject
    {

        #region Fields

        private int nbBooksWritten { get; set; }

        #endregion

        #region Properties

        public Author Model { get; }

        public string Name
        {
            get => Model.Name;
            set
            {
                Model.Name = value;
            }
        }

        public int NbBooksWritten
        {
            get => nbBooksWritten;
            set
            {
                nbBooksWritten = value;
            }
        }

        #endregion

        #region Constructor

        public AuthorVM(Author model)
        {
            Model = model;
        }

        #endregion
    }
}