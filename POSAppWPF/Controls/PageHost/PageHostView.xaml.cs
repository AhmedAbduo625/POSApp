using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace POSAppWPF
{
    /// <summary>
    /// Interaction logic for PageHostView.xaml
    /// </summary>
    public partial class PageHostView : UserControl
    {
        public PageHostView()
        {
            InitializeComponent();
        }

        public BasePage CurrentPage
        {
            get { return (BasePage)GetValue(CurrentPageProperty); }
            set { SetValue(CurrentPageProperty, value); }
        }

        public static readonly DependencyProperty CurrentPageProperty =
            DependencyProperty.Register(nameof(CurrentPage), typeof(BasePage), typeof(PageHostView), new UIPropertyMetadata(new PropertyChangedCallback(CurrentPageChanged)));

        private static void CurrentPageChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var oldFrame = ((PageHostView)d).oldFrame;
            var newFrame = ((PageHostView)d).newFrame;

            var oldContent = newFrame.Content;
            oldFrame.Content = oldContent;

            newFrame.Content = null;

            if (oldContent is BasePage oldPageContent)
            {
                oldPageContent.IsAnimateOut = true;
                Task.Delay((int)(oldPageContent.SlidSeconds * 1000)).ContinueWith((t) =>
                {
                    Application.Current.Dispatcher.Invoke(() => oldFrame.Content = null);
                });
            }			
			
			newFrame.Content = e.NewValue;

		}


    }
}
