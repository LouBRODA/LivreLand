using PersonalMVVMToolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class PublishDateVM : BaseViewModel
    {
        #region Properties

        public DateTime PublishDate { get; set; }

        public int NbBooksWritten { get; set; }

        #endregion

        #region Constructor

        public PublishDateVM()
        {

        }

        #endregion
    }
}
