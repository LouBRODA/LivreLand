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
    public partial class ContactVM
    {
        #region Fields

        [ObservableProperty]
        private string id;

        [ObservableProperty]
        private string firstName;

        [ObservableProperty]
        private string lastName;

        #endregion

        #region Properties

        #endregion

        #region Constructor

        public ContactVM(Model.Contact c)
        {

        }

        #endregion
    }
}
