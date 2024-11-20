using System.Windows.Input;

namespace WatchList.WPF.Commands
{
    public class RelayCommandApp : ICommand
    {
        private readonly Action<object?>? _execute;
        private readonly Predicate<object?>? _canExecute;

        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public RelayCommandApp(Action<object?> execute)
            : this(execute, null) => _execute = execute;

        public RelayCommandApp(Action<object?> execute, Predicate<object?>? canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object? parameter)
            => _canExecute == null || _canExecute(parameter);

        public void Execute(object? parameter) => _execute(parameter);
    }
}
