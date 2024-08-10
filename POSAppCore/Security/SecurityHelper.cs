using System.Runtime.InteropServices;
using System.Security;

namespace POSAppCore
{
    public static class SecurityHelper
    {
        public static string UnsecureString(this SecureString secureString)
        {
            if (secureString is null)
                return string.Empty;

            /* Pointer in unmanaged memory */
            var ptr = IntPtr.Zero;

            try
            {
                ptr = Marshal.SecureStringToGlobalAllocUnicode(secureString);
                return Marshal.PtrToStringUni(ptr);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(ptr);
            }

        }
    }
}
