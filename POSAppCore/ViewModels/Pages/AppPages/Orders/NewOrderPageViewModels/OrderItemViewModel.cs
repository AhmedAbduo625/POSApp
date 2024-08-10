

using System.Windows.Input;

namespace POSAppCore
{
	public class OrderItemViewModel : BaseViewModel
	{
        #region PRIVATE MEMEBERS

        #endregion

        #region PUBLIC PROPERTIES

        public int Id { get; set; }
        public string? ItemName { get; set; }
        public decimal Price { get; set; }
        public bool HasCustomItems { get; set; }
        public string CustomItemTitle { get; set; }

        public List<OrderItemViewModel> BasicItems { get; set; }
        public List<OrderItemViewModel> ExtraItems { get; set; }
        public List<OrderItemViewModel> RemovedItems { get; set; }
        public List<OrderItemViewModel> OtherItems { get; set; }

        public List<CustomItemViewModel> GroupItems { get; set; }

        #endregion

        #region ICONS

        public Icons PlusIcon { get; set; } = Icons.PlusIcon;
		public Icons MinusIcon { get; set; } = Icons.MinusIcon;


        #endregion

        #region COMMANDS

        public ICommand CustomItemsCommand { get; set; }
        public ICommand AddItemCommand { get; set; }
		public ICommand RemoveItemCommand { get; set; }
		#endregion

		#region CONSTRUCTOR

		public OrderItemViewModel()
		{
            CustomItemsCommand = new RelayCommand(CustomItems);
            AddItemCommand = new RelayCommand(AddItem);
			RemoveItemCommand = new RelayCommand(RemoveItem);
		}

		#endregion

		#region PRIVATE METHODS

		private void AddItem(object args)
		{
			OnAddingNewItem?.Invoke((OrderItemViewModel)args);
		}
		private void RemoveItem(object args)
		{
			OnRemovingItem?.Invoke((OrderItemViewModel)args);
		}
        private void CustomItems(object args)
        {
            OnDisplayCustomItems?.Invoke();
        }

        #endregion

        #region PUBLIC METHODS

        public Action<OrderItemViewModel> OnAddingNewItem { get; set; }
		public Action<OrderItemViewModel> OnRemovingItem { get; set; }
        public Action OnDisplayCustomItems { get; set; }

        #endregion
    }
}
