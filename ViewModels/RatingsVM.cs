using CommunityToolkit.Mvvm.ComponentModel;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public partial class RatingsVM : ObservableObject
    {
        #region Fields

        private int nbBooksWritten { get; set; }

        #endregion

        #region Properties

        public float? Average { get; set; }

        public int Count { get; set; }

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

        public RatingsVM()
        {

        }

        #endregion

    }
}