namespace Runas
{
    using CommandLine;
    using System;
    using System.Diagnostics;
    using System.Security.Principal;

    /// <summary>
    ///     Class WindowsSecurityUtil
    /// </summary>
    public static class WindowsSecurityUtil
    {
        /// <summary>
        ///     Try to get permission of administrator.
        /// </summary>
        /// <param name="executablePath">The executable path.</param>
        /// <param name="options">todo: describe options parameter on RunAsAdministrator</param>
        /// <returns>User sate</returns>
        internal static UserState TryGetAdminWithRunas(IOptions options, string executablePath)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
            {
                if (new WindowsPrincipal(identity).IsInRole(WindowsBuiltInRole.Administrator))
                {
                    return UserState.Administrator;
                }
            }

            if (options.IsSelfcall)
            {
                // failed to get permision after ron 2nd
                return UserState.NoAdministrator;
            }
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options), "the arguments can't be nothing");
            }

            options.IsSelfcall = true;
            // prepare a new process start infomation to try get permission again
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = executablePath,
                Arguments = Parser.Default.FormatCommandLine(options),
                Verb = "runas"
            };
            //start a new process with verb runas for getting administrator permission
            Process.Start(startInfo);
            //ÍË³ö
            return UserState.RestartTryGet;
        }
    }
}
