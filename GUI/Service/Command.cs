using System;
using System.Windows;
using System.Windows.Input;

namespace HighwayToHell.GUI.Service
{
    public class Command : ICommand
    {
        private readonly Action _action;

        public Command(Action action)
        {
            _action = action;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _action.Invoke();
        }

        public event EventHandler CanExecuteChanged;

        protected virtual void OnCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            //if (handler != null) handler(this, EventArgs.Empty);
        }
    }

    public class Command<T> : ICommand
    {
        private readonly Action<T> _action;

        public Command(Action<T> action)
        {
            _action = action;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            try
            {
                _action.Invoke((T)parameter);
            }
            catch
            {
                if (parameter == null)
                {
                  MessageBox.Show(".:I:.");  
                }
                
            }
        }

        public event EventHandler CanExecuteChanged;

        protected virtual void OnCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            //if (handler != null) handler(this, EventArgs.Empty);
        }
    }
}
