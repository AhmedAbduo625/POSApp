
using System.ComponentModel;
using System.Linq.Expressions;


namespace POSAppCore
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        public void SetProperty<T>(ref T oldValue, string propertName, T newValue)
        {
            oldValue = newValue;
            OnPropertyChanged(propertName);

        }
        public async Task RunCommand(Expression<Func<bool>> exp, Func<Task> task)
        {
            if (exp.GetProperty())
                return;

            exp.SetProperty(true);

            try
            {
                await task.Invoke();
            }
            catch (Exception ex)
            {
                IoC.UI.ShowCustomMessageBoxDialog(new CustomMessageBoxDialogViewModel() { Message = ex.Message});
            }
            finally
            {
                exp.SetProperty(false);
            }
        }
    }
}
