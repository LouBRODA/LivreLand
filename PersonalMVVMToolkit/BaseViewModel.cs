using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalMVVMToolkit
{
    public class BaseViewModel<TModel> : ObservableObject
    {

        #region Fields

        private TModel model;

        #endregion

        #region Properties

        public TModel Model 
        { 
            get => model; 
            private set
            {
                SetProperty(ref model, value);
            }
        }

        #endregion

        #region Constructor

        public BaseViewModel(TModel model)
        {
            Model = model;
        }

        public BaseViewModel() : this(default)
        { }

        #endregion
    }

    public class BaseViewModel : ObservableObject { }
}
