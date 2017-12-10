using System;
using System.Windows.Input;

namespace CmdLineSynchroniser.Command
{
    public class DeletgateCommand<T>:ICommand
    {
        private readonly Action<T> _executeMethod = null;
        private readonly Func<T, bool> _canExecuteMethod = null;

        public DeletgateCommand(Action<T> executeMethod)
            : this(executeMethod, null)
        { }

        public DeletgateCommand(Action<T> executeMethod, Func<T, bool> canExecuteMethod)
        {
            _executeMethod = executeMethod ?? throw new ArgumentNullException(nameof(executeMethod));
            _canExecuteMethod = canExecuteMethod;
        }

        #region ICommand member
        /// <summary>
        ///  Method to determine if the command can be executed
        /// </summary>
        public bool CanExecute(T parameter)
        {
            return _canExecuteMethod == null || _canExecuteMethod(parameter);
        }

        /// <summary>
        ///  Execution of the command
        /// </summary>
        public void Execute(T parameter)
        {
            _executeMethod?.Invoke(parameter);
        }

        #endregion


        event EventHandler ICommand.CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        #region ICommand member

        public bool CanExecute(object parameter)
        {
            if (parameter == null && typeof(T).IsValueType)
            {
                return (_canExecuteMethod == null);

            }

            return CanExecute((T)parameter);
        }

        public void Execute(object parameter)
        {
            Execute((T)parameter);
        }

        #endregion
    }
}
