namespace Runas
{
    using System;
    using System.Diagnostics;
    using System.Security.Principal;

    using CommandLine;

    /// <summary>
    ///     Class WindowsSecurityUtil
    /// </summary>
    public static class WindowsSecurityUtil
    {
        /// <summary>
        ///     Try to get permission of administrator.
        /// </summary>
        /// <param name="opts"></param>
        /// <param name="executablePath">The executable path.</param>
        /// <returns>User sate</returns>
        internal static UserState RunAsAdministrator(IOptions options, string executablePath)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            using (var identity = WindowsIdentity.GetCurrent())
                if (new WindowsPrincipal(identity).IsInRole(WindowsBuiltInRole.Administrator))
                {
                    return UserState.Administrator;
                }            
            if (options.IsSelfcall)
            {
                return UserState.NoAdministrator;
            }
            if (options == null)
                throw new ArgumentNullException(nameof(options),"the arguments can't be nothing");
            options.IsSelfcall = true;
            // prepare a new process start infomation
            var startInfo = new ProcessStartInfo
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