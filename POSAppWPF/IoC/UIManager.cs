
using POSAppCore;
using System.Threading.Tasks;

namespace POSAppWPF
{
	public class UIManager : IUIManager
	{
		public Task ShowCustomMessageBoxDialog(CustomMessageBoxDialogViewModel viewModel)
		{
			return new CustomMessageBoxDialogControl().ShowControl(viewModel);
		}

		public Task ShowPizzaCustomizationDialog(PizzaCustomizationViewModel viewModel)
		{
			return new PizzaCustomizationView().ShowControl(viewModel);
		}
	}
}
