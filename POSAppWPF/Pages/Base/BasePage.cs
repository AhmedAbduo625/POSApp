using SharpVectors.Converters;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using POSAppCore;

namespace POSAppWPF
{
    public class BasePage : Page
    {
        public double SlidSeconds { get; set; } = 0.0;
        public bool IsAnimateOut { get; set; }
        public BasePage()
        {
			this.Visibility = Visibility.Hidden;
            this.Loaded += Page_Loaded;
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            await AnimatePage();
            await DisplayPageLogoAsync();
        }

        private async Task AnimatePage()
        {
            if (IsAnimateOut)
                await this.FadingOutAsync(SlidSeconds, 0);
            else
                await this.FadingInAsync(SlidSeconds, 0);
        }

        public SvgViewbox LogoContainer
        {
            get { return (SvgViewbox)GetValue(LogoContainerProperty); }
            set { SetValue(LogoContainerProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LogoContainer.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LogoContainerProperty =
            DependencyProperty.Register("LogoContainer", typeof(SvgViewbox), typeof(BasePage), new PropertyMetadata(default(SvgViewbox)));

        private async Task DisplayPageLogoAsync()
        {
            var vm = (BasePageViewModel)this.DataContext;
            if (vm.PageLogoPath != null)
            {
                if (!IsAnimateOut)
                {
                    LogoContainer = new SvgViewbox();
                    await LogoContainer.LoadAsync(vm.PageLogoPath);
                    vm.LogoIsLoading = false;
                }
            }
        }
    }

    public class BasePage<Vm> : BasePage where Vm : BasePageViewModel, new()
    {
        private Vm? _viewModel = null;
        public Vm? ViewModel
        {
            get => _viewModel;
            set
            {
                if (_viewModel is null)
                {
                    _viewModel = value;
                    DataContext = _viewModel;
                }
            }
        }
        public BasePage()
        {
            ViewModel = new Vm();
        }
    }
}
