using POSAppCore;
using System.Collections.Generic;
using System.Windows;

namespace POSAppWPF
{
	public class SideMenuAnimationProperty : FrameworkElementAnimationAttachedProperties<SideMenuAnimationProperty>
	{
		protected override async void DoAnimation(FrameworkElement element, bool value, bool isFirstLoad)
		{
			if (value)
				await element.SlideInAsync(isFirstLoad ? 0 : 0.4, 0, new Thickness(0, 0, 0, 0), new Thickness(0, 0, -185, 0));
			else
				await element.SlideOutAsync(isFirstLoad ? 0 : 0.4, 0, new Thickness(0, 0, -185, 0), new Thickness(0, 0, 0, 0), false);
		}
	}

	public class SideMenuSubItemAnimationProperty : FrameworkElementAnimationAttachedProperties<SideMenuSubItemAnimationProperty>
	{
		public Dictionary<FrameworkElement, bool> OnCollapse { get; set; } = new Dictionary<FrameworkElement, bool>();

		protected override async void DoAnimation(FrameworkElement element, bool value, bool isFirstLoad)
		{
			if (!OnCollapse.ContainsKey(element))
				OnCollapse.Add(element, false);

			if (OnCollapse[element])
				return;

			var vm = ((SideMenuItemViewModel)(element.DataContext));

			var currentTopPosition = vm.ButtonPosition; //+ ((Application.Current.MainWindow.WindowState == WindowState.Maximized) ? 10 : 0);

			if (value && IoC.AppSettings.IsSideMenueVisible == false)
			{
				await element.SlideInWithFadingAsync(isFirstLoad ? 0 : 0.2, 0, new Thickness(0, currentTopPosition - 7, 0, 7), new Thickness(0, currentTopPosition, 0, 0));
			}
			else
			{
				OnCollapse[element] = true;
				await element.SlideOutWithFadingAsync(isFirstLoad ? 0 : 0.2, 0, new Thickness(0, currentTopPosition, 0, 0), new Thickness(0, currentTopPosition - 7, 0, 7));
				OnCollapse[element] = false;
			}
		}
	}

	public class SideMenuSubDownListAnimationProperty : FrameworkElementAnimationAttachedProperties<SideMenuSubDownListAnimationProperty>
	{
		protected override async void DoAnimation(FrameworkElement element, bool value, bool isFirstLoad)
		{
			if (value)
				await element.SlideInWithFadingAsync(isFirstLoad ? 0 : 0.3, 0, new Thickness(0, -element.ActualHeight, 0, 0), new Thickness(0, 0, 0, 0));
			else
				await element.SlideOutWithFadingAsync(isFirstLoad ? 0 : 0.3, 0, new Thickness(0, 0, 0, 0), new Thickness(0, -element.ActualHeight, 0, 0));

		}
	}
}
