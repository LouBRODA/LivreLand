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
    public partial class RatingsVM
    {
        #region Fields

        [ObservableProperty]
        private int nbBooksWritten;

        [ObservableProperty]
        private float? average;

        [ObservableProperty]
        private int count;

        #endregion

        #region Properties

        #endregion

        #region Constructor

        public RatingsVM()
        {

        }

        #endregion

    }
}
