using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    [ObservableObject]
    public partial class PublishDateVM
    {
        #region Fields

        [ObservableProperty]
        private DateTime publishDate;

        [ObservableProperty]
        private int nbBooksWritten;

        #endregion

        #region Properties

        #endregion

        #region Constructor

        public PublishDateVM()
        {

        }

        #endregion
    }
}
