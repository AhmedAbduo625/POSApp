
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace POSAppCore
{
    public class ItemCustomizationViewModel : BaseViewModel
    {
        #region PRIVATE MEMEBERS

        private string _title;

        #endregion

        #region PUBLIC PROPERTIES
        public string Title 
        {
            get => _title;
            set => SetProperty(ref _title, nameof(Title), value);
        }
        public ObservableCollection<OrderItemViewModel> CustomItems { get; set; }

        #endregion

        #region ICONS


        #endregion

        #region COMMANDS


        #endregion

        #region CONSTRUCTOR

        public ItemCustomizationViewModel()
        {
            CustomItems = new ObservableCollection<OrderItemViewModel>();   
        }

        #endregion

        #region PRIVATE METHODS


        #endregion

        #region PUBLIC METHODS

        #endregion

        #region ACTIONS

        #endregion
    }
}
