
namespace POSAppCore
{ 
	public class OrderCategoryViewModel : BaseViewModel
	{
		#region PRIVATE MEMEBERS
		private bool _isChecked = false;
        #endregion

        #region PUBLIC PROPERTIES
        public int Id { get; set; }

        public string? CategoryName { get; set; }

		public bool IsChecked
		{
			get => _isChecked;
			set
			{
				if (IsChecked && value)
					return;

				SetProperty(ref _isChecked, nameof(IsChecked), value);

				if (value)
				{
					//Load Items...
					OnLoadingItems?.Invoke();
				}

				
			}
		}

		#endregion

		#region ICONS



		#endregion

		#region COMMANDS


		#endregion

		#region CONSTRUCTOR

		public OrderCategoryViewModel()
		{

		}

		#endregion

		#region PRIVATE METHODS


		#endregion

		#region PUBLIC METHODS

		#endregion

		#region ACTIONS
		public Action OnLoadingItems { get; set; }

		#endregion
	}
}
