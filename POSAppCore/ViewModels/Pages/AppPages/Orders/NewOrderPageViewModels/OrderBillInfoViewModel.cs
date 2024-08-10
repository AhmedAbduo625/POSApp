
using System.Windows.Input;

namespace POSAppCore
{
	public class OrderBillInfoViewModel : BaseViewModel
	{
		#region PRIVATE MEMEBERS
		private string _customerMobile;
		#endregion

		#region PUBLIC PROPERTIES

		public string CustomerMobile
		{
			get => _customerMobile;
			set => SetProperty(ref _customerMobile, nameof(CustomerMobile), value);
		}

		#endregion

		#region ICONS

		
		public Icons CustomersIcon { get; set; } = Icons.CustomersIcon;
		public Icons TakeAwayIcon { get; set; } = Icons.TakeAwayIcon;
		public Icons DeliveryIcon { get; set; } = Icons.DeliveryIcon;
		public Icons LobbyIcon { get; set; } = Icons.LobbyIcon;

		public Icons CashIcon { get; set; } = Icons.CashIcon;
		public Icons VisaIcon { get; set; } = Icons.VisaIcon;
		public Icons LiabilityIcon { get; set; } = Icons.LiabilityIcon;

        #endregion

        #region COMMANDS

       
        #endregion

        #region CONSTRUCTOR

        public OrderBillInfoViewModel()
		{
			
		}

		#endregion

		#region PRIVATE METHODS

		
		#endregion

		#region PUBLIC METHODS

		#endregion

		#region ACTIONS
		public Action OnNavigateToOrderBill { get; set; }
		#endregion
	}
}
