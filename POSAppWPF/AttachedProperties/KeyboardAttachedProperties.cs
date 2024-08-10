
using POSAppCore;
using SharpVectors.Dom;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace POSAppWPF
{
	public class TextBoxFocusForKeyboardProperty : BaseAttachedProperty<TextBoxFocusForKeyboardProperty, bool>
	{
		public override void ValueChangedHandler(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (d is TextBox textBox && (bool)e.NewValue)
			{
				textBox.Loaded += (ss, ee) =>
				{
					//var keyboard = GetKeyboardControl(d);

					((TextBox)ss).GotFocus += (sss, eee) =>
					{
						var bindingExpression = textBox.GetBindingExpression(TextBox.TextProperty);
						if (bindingExpression != null)
						{
							var binding = bindingExpression.ParentBinding;
							var path = binding.Path.Path;
							IoC.KeyboardNumbersManager.ShowKeyboardNumbers = true;
							((KeyboardNumbersViewModel)IoC.KeyboardNumbersManager).EstablishConnection((BaseViewModel)textBox.DataContext, path);
						}
					};

				};
			}
		}

		private object GetKeyboardControl(DependencyObject d)
		{
			var element = d;

			DependencyObject parent = VisualTreeHelper.GetParent(element);

			while (parent != null && parent is not UserControl)
			{
				element = parent;

				parent = VisualTreeHelper.GetParent(element);
			}

			var keyboard = ((UserControl)parent).FindName("keyboard");

			return keyboard;
		}

		private bool IsKeyboardGotFocus(KeyboardNumbersView keyboard)
		{
			return true;
		}

		public override void ValueUpdatedHandler(DependencyObject d, object baseValue)
		{

		}
	}

}
