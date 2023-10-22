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
    public partial class AuthorVM
    {

        #region Fields

        [ObservableProperty]
        private int nbBooksWritten;

        [ObservableProperty]
        private string name;

        #endregion

        #region Properties

        #endregion

        #region Constructor

        public AuthorVM(Author model)
        {

        }

        #endregion
    }
}
