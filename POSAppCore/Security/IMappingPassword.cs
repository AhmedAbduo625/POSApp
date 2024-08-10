using System.Security;

namespace POSAppCore
{
	public interface IMappingPassword
	{
		SecureString SecurePassword { get; }
	}
}
