

using POSAppCore;
using System.Security;

namespace POSAppWPF
{
    /// <summary>
    /// Interaction logic for SigninPage.xaml
    /// </summary>
    public partial class SigninPage : BasePage<SignInPageViewModel>, IMappingPassword
	{
        public SigninPage()
        {
            InitializeComponent();
        }

		public SecureString SecurePassword => this.passwordbox.SecurePassword;
	}
}
