using Model;
using PersonalMVVMToolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class AuthorVM : BaseViewModel<Author>
    {

        #region Fields

        #endregion

        #region Properties

        public string Name
        {
            get => Model.Name;
            set
            {
                Model.Name = value;
            }
        }

        #endregion

        #region Constructor

        public AuthorVM(Author model) : base(model)
        {

        }

        #endregion
    }
}
