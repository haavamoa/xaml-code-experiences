using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace asynccommand.Resources.Commands
{
    public class AsyncCommand : ICommand
    {
        private readonly Func<object, bool> _canExecute;
        private readonly Func<object, Task> _command;

        public AsyncCommand(Func<object, Task> command, Func<object, bool> canExecute = null)
        {
            _command = command;
            _canExecute = canExecute ?? (o => true);
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute(parameter);
        }

        public async void Execute(object parameter)
        {
            await ExecuteAsync(parameter);
        }

        public event EventHandler CanExecuteChanged;

        public async Task ExecuteAsync(object parameter = null)
        {

            await _command(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(null, new EventArgs());
        }
    }
}