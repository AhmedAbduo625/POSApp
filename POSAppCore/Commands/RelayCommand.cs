using System.Windows.Input;

namespace POSAppCore
{
    public class RelayCommand : ICommand
    {
        private ICommand? buttonClickedCommand;

        public event EventHandler? CanExecuteChanged;

        public Action<object> OnExecute { get; set; }
        public Predicate<object> OnCanExecute { get; set; }

        public RelayCommand(Action<object> onExecute, Predicate<object> onCanExecute = null)
        {
            OnExecute = onExecute;
            OnCanExecute = onCanExecute;
        }

        public RelayCommand(ICommand? buttonClickedCommand)
        {
            this.buttonClickedCommand = buttonClickedCommand;
        }

        public bool CanExecute(object? parameter)
        {
            if (OnCanExecute is null)
                return true;

            return OnCanExecute.Invoke(parameter);
        }

        public void Execute(object? parameter)
        {
            OnExecute(parameter);
        }
    }
}
