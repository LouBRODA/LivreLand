using Model;
using PersonalMVVMToolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class WorkVM : BaseViewModel<Work>
    {
        #region Fields

        #endregion

        #region Properties

        public string Id
        {
            get => Model.Id;
            set => SetProperty(Model.Id, value, v => Model.Id = value);
        }

        public string Description
        {
            get => Model.Description;
            set => SetProperty(Model.Description, value, v => Model.Description = value);
        }

        #endregion

        #region Constructor

        public WorkVM(Work w) : base(w)
        {

        }

        #endregion
    }
}
