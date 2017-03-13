using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Security.Principal;
//using Framework.Interop;

namespace Framework.Security
{
    public class clsImpersonator : IDisposable
    {
        private WindowsImpersonationContext _wic;

        /// <summary>  
        /// Begins impersonation with the given credentials, Logon type and Logon provider.  
        /// </summary>  
        ///  <param name="userName">Name of the user.</param>  
        ///  <param name="domainName">Name of the domain.</param>  
        ///  <param name="password">The password. <see cref="System.String"/></param>  
        ///  <param name="logonType">Type of the logon.</param>  
        ///  <param name="logonProvider">The logon provider. <see cref="Mit.Sharepoint.WebParts.EventLogQuery.Network.LogonProvider"/></param>  
        public clsImpersonator(string userName, string domainName, string password,
                LogonType logonType, LogonProvider logonProvider)
        {
            Impersonate(userName, domainName, password, logonType, logonProvider);
        }

        /// <summary>  
        /// Begins impersonation with the given credentials.  
        /// </summary>  
        ///  <param name="userName">Name of the user.</param>  
        ///  <param name="domainName">Name of the domain.</param>  
        ///  <param name="password">The password. <see cref="System.String"/></param>  
        public clsImpersonator(string userName, string domainName, string password)
        {
            Impersonate(userName, domainName, password, LogonType.LOGON32_LOGON_INTERACTIVE, LogonProvider.LOGON32_PROVIDER_DEFAULT);
        }

        /// <summary>  
        /// Initializes a new instance of the <see cref="Impersonator"/> class.  
        /// </summary>  
        public clsImpersonator()
        { }

        /// <summary>  
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.  
        /// </summary>  
        public void Dispose()
        {
            UndoImpersonation();
        }

        /// <summary>  
        /// Impersonates the specified user account.  
        /// </summary>  
        ///  <param name="userName">Name of the user.</param>  
        ///  <param name="domainName">Name of the domain.</param>  
        ///  <param name="password">The password. <see cref="System.String"/></param>  
        public void Impersonate(string userName, string domainName, string password)
        {
            Impersonate(userName, domainName, password, LogonType.LOGON32_LOGON_INTERACTIVE, LogonProvider.LOGON32_PROVIDER_DEFAULT);
        }

        /// <summary>  
        /// Impersonates the specified user account.  
        /// </summary>  
        ///  <param name="userName">Name of the user.</param>  
        ///  <param name="domainName">Name of the domain.</param>  
        ///  <param name="password">The password. <see cref="System.String"/></param>  
        ///  <param name="logonType">Type of the logon.</param>  
        ///  <param name="logonProvider">The logon provider. <see cref="Mit.Sharepoint.WebParts.EventLogQuery.Network.LogonProvider"/></param>  
        public void Impersonate(string userName, string domainName, string password,
                LogonType logonType, LogonProvider logonProvider)
        {
            UndoImpersonation();

            IntPtr logonToken = IntPtr.Zero;
            IntPtr logonTokenDuplicate = IntPtr.Zero;

            try
            {
                // revert to the application pool identity, saving the identity of the current requestor  

                _wic = WindowsIdentity.Impersonate(IntPtr.Zero);

                // do logon & impersonate  
                if (clsWin32NativeMethods.LogonUser(userName, domainName, password,
                                   (int)logonType, (int)logonProvider, ref logonToken) != 0)
                {
                    if (clsWin32NativeMethods.DuplicateToken(logonToken,
                        (int)ImpersonationLevel.SecurityImpersonation, ref logonTokenDuplicate) != 0)
                    {
                        var wi = new WindowsIdentity(logonTokenDuplicate);
                        wi.Impersonate(); // discard the returned identity context (which is the context of the application pool)  
                    }
                    else
                        throw new Win32Exception(Marshal.GetLastWin32Error());
                }
                else
                    throw new Win32Exception(Marshal.GetLastWin32Error());

            }
            finally
            {
                if (logonToken != IntPtr.Zero)
                    clsWin32NativeMethods.CloseHandle(logonToken);

                if (logonTokenDuplicate != IntPtr.Zero)
                    clsWin32NativeMethods.CloseHandle(logonTokenDuplicate);
            }
        }

        /// <summary>  
        /// Stops impersonation.  
        /// </summary>  
        public void UndoImpersonation()
        {
            // restore saved requestor identity  
            if (_wic != null)
                _wic.Undo();
            _wic = null;
        }
    }
}
