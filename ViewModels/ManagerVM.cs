using Model;
using System.Windows.Input;

namespace ViewModels
{
    public class ManagerVM
    {

        #region Fields

        private Manager model;

        #endregion

        #region Properties 

        public Manager Model
        {
            get => model;
            private set => model = value;
        }

        public ICommand GetBooksByTitleCommand;

        #endregion

        #region Constructor

        public ManagerVM(Manager model)
        {
            Model = model;
            //GetBooksByTitleCommand = new Command(async () =>)
        }

        #endregion
    }
}