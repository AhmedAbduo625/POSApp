
using System.Reflection;
using System.Windows.Input;

namespace POSAppCore
{
	public class KeyboardNumbersViewModel : BaseViewModel
	{

		#region PRIVATE MEMEBERS
		private bool _showKeyboardNumbers = false;
		#endregion

		#region PUBLIC PROPERTIES
		public bool ShowKeyboardNumbers
		{
			get => _showKeyboardNumbers;
			set
			{
				SetProperty(ref _showKeyboardNumbers, nameof(ShowKeyboardNumbers), value);
			}
		}
		public PropertyInfo TargetProperty { get; set; }
        public BaseViewModel TargetType { get; set; }


        #endregion

        #region ICONS



        #endregion

        #region COMMANDS

        public ICommand PressedCommand { get; set; }
		public ICommand CloseKyboardCommand { get; set; }

		#endregion

		#region CONSTRUCTOR

		public KeyboardNumbersViewModel()
		{
			PressedCommand = new RelayCommand(Pressed);
			CloseKyboardCommand = new RelayCommand((args) => IoC.KeyboardNumbersManager.ShowKeyboardNumbers = false);
		}

		#endregion

		#region PRIVATE METHODS

		private void Pressed(object args)
		{
			var currentValue = TargetProperty.GetValue(TargetType) is null ? "" : TargetProperty.GetValue(TargetType).ToString();
			TargetProperty.SetValue(TargetType, currentValue + args.ToString());
		}


        #endregion

        #region PUBLIC METHODS
		public void EstablishConnection(BaseViewModel vm, string propertName)
		{
			TargetType = vm;
			TargetProperty = vm.GetType().GetProperties().FirstOrDefault(p=>p.Name == propertName);
		}
		#endregion

		#region ACTIONS


		#endregion

	}

}
