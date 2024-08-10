
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Input;

namespace POSAppCore
{
	public class OrderBillViewModel : BaseViewModel
	{
		#region PRIVATE MEMEBERS
		private string _barcode;
		private bool _showCustomItems = false;
		#endregion

		#region PUBLIC PROPERTIES

		public string Barcode
		{
			get => _barcode;
			set => SetProperty(ref _barcode, nameof(Barcode), value);
		}
        public bool ShowCustomItems
        {
            get => _showCustomItems;
            set => SetProperty(ref _showCustomItems, nameof(ShowCustomItems), value);
        }
        public ObservableCollection<OrderItemViewModel> BillItems { get; set; }
		public bool HasNoItems { get => BillItems is null || BillItems.Count == 0; }

		#endregion

		#region ICONS



		#endregion

		#region COMMANDS

		

        #endregion

        #region CONSTRUCTOR

        public OrderBillViewModel()
		{
			BillItems = new ObservableCollection<OrderItemViewModel>();
            BillItems.CollectionChanged += OnBillItemsCollectionChanged;
           
		}

        #endregion

        #region PRIVATE METHODS
        private void OnBillItemsCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (OrderItemViewModel item in e.NewItems)
                {
                    
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (var item in e.OldItems)
                {

                }
            }
        }
       

		#endregion

		#region PUBLIC METHODS

		#endregion

		#region ACTIONS
		public Action OnOrderPlaced { get; set; }
		#endregion
	}
}
