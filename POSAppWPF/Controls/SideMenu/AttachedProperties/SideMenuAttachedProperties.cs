using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;
using POSAppCore;

namespace POSAppWPF
{
	public class SideMenuItemHoverProperty : BaseAttachedProperty<SideMenuItemHoverProperty, bool>
	{
		private int CurrentYDistanceBetweenElementContainerAndWindow = 129;

		public override void ValueChangedHandler(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (d is Grid grid)
			{
				RoutedEventHandler onLoad = null;
				onLoad += (ss, ee) =>
				{
					grid.Loaded -= onLoad;
					grid.MouseEnter += Grid_MouseEnter;
					grid.MouseLeave += Grid_MouseLeave;
				};
				grid.Loaded += onLoad;
			}
		}

		private void Grid_MouseEnter(object sender, MouseEventArgs e)
		{
			var grid = sender as Grid;
			var vm = ((SideMenuItemViewModel)(grid.DataContext));

			/* Get the exact position of the hovered button to specify the position of the sub menu */
			Point relativeLocation = grid.TranslatePoint(new Point(0, 0), Application.Current.MainWindow);
			vm.ButtonPosition = (int)relativeLocation.Y - CurrentYDistanceBetweenElementContainerAndWindow + (Application.Current.MainWindow.WindowState == WindowState.Maximized ? 10 : 0);

			vm.IsLeftItemHover = true;
			vm.OnPropertyChanged(nameof(vm.IsHover));
		}

		private void Grid_MouseLeave(object sender, MouseEventArgs e)
		{
			var grid = sender as Grid;
			var vm = ((SideMenuItemViewModel)(grid.DataContext));

			vm.IsLeftItemHover = false;
			/* Wait 2 milliSeconds expecting the mouse get into the sub menu*/
			Task.Delay(2).ContinueWith((t) => vm.OnPropertyChanged(nameof(vm.IsHover)));
		}

		public override void ValueUpdatedHandler(DependencyObject d, object baseValue) { }
	}

	public class SideMenuSubItemHoverProperty : BaseAttachedProperty<SideMenuSubItemHoverProperty, bool>
	{
		public override void ValueChangedHandler(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (d is Border border)
			{
				RoutedEventHandler onLoad = null;
				onLoad += (ss, ee) =>
				{
					border.Loaded -= onLoad;
					border.MouseEnter += Grid_MouseEnter;
					border.MouseLeave += Grid_MouseLeave;
				};
				border.Loaded += onLoad;
			}
		}

		private void Grid_MouseEnter(object sender, MouseEventArgs e)
		{
			var border = sender as Border;
			var vm = ((SideMenuItemViewModel)(border.DataContext));

			vm.IsRightItemHover = true;
			vm.OnPropertyChanged(nameof(vm.IsHover));
		}

		private void Grid_MouseLeave(object sender, MouseEventArgs e)
		{
			var border = sender as Border;
			var vm = ((SideMenuItemViewModel)(border.DataContext));

			vm.IsRightItemHover = false;
			/* Wait 2 milliSeconds expecting the mouse get into the main menu*/
			Task.Delay(2).ContinueWith((t) => vm.OnPropertyChanged(nameof(vm.IsHover)));
		}

		public override void ValueUpdatedHandler(DependencyObject d, object baseValue) { }
	}

	public class HasSingleChildProperty : BaseAttachedProperty<HasSingleChildProperty, bool>
	{
		public override void ValueChangedHandler(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{

		}

		public override void ValueUpdatedHandler(DependencyObject d, object baseValue)
		{

		}
	}
}
