namespace POSAppCore
{
	public interface IUIManager
	{
		Task ShowCustomMessageBoxDialog(CustomMessageBoxDialogViewModel viewModel);
		Task ShowPizzaCustomizationDialog(PizzaCustomizationViewModel viewModel);

	}
}
