using Model;
using System.Windows.Input;

namespace ViewModels
{
    public class ManagerVM
    {

        #region Properties 

        public Manager Model
        {
            get => model;
            private set => model = value;
        }
        private Manager model;

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