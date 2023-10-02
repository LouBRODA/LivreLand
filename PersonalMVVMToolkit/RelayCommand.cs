using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PersonalMVVMToolkit
{
    public class RelayCommand<T> : ICommand
    {

        #region Fields

        private readonly Action<T> execute;

        private readonly Func<T, bool> canExecute;

        #endregion

        #region Properties

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            T param = (T)parameter;
            return canExecute(param);
        }

        public void Execute(object? parameter)
        {
            T param = (T)parameter;
            execute(param);
        }

        public void RefreshCommand()
            => CanExecuteChanged?.Invoke(this, EventArgs.Empty);

        #endregion

        #region Constructor

        public RelayCommand(Action<T> execute, Func<T,bool> canExecute = null) 
        {
            this.execute = execute;
            this.canExecute = canExecute ?? (t => true);
        }

        #endregion
    }

    public class RelayCommand : RelayCommand<object>
    {

        #region Constructor

        public RelayCommand(Action execute, Func<bool> canExecute = null) : base(new Action<object> (o => execute()), canExecute != null ? new Func<object, bool>(o => canExecute()) : null)
        {

        }

        #endregion
    }
}
