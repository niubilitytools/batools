namespace Runas
{
    using CommandLine;
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using System.Security;

    internal class Program
    {
        private static readonly Func<IOptions, MessageState> CallTargetFileWithSpecificUser = opts =>
            {
             
                var startInfo = new ProcessStartInfo { FileName = opts.FileName };
                if (!string.IsNullOrEmpty(opts.UserName))
                {
                    if (string.IsNullOrWhiteSpace(opts.Domain))
                    {
                        var idx = opts.UserName.IndexOf('@');
                        if (idx > -1)
                        {
                            startInfo.Domain = opts.UserName.Substring(idx + 1);
                            startInfo.UserName = opts.UserName.Substring(0, idx);
                        }
                        else if ((idx = opts.UserName.IndexOf('\\')) > -1)
                        {
                            startInfo.Domain = opts.UserName.Substring(0, idx);
                            startInfo.UserName = opts.UserName.Substring(idx + 1);
                        }
                        else
                        {
                            startInfo.UserName = opts.UserName;
                        }
                    }
                    else
                    {
                        startInfo.Domain = opts.Domain;
                        startInfo.UserName = opts.UserName;
                    }

                    startInfo.Password = BuildSecureString(opts.Password);
                }
                else
                {
                    var status = WindowsSecurityUtil.TryGetAdminWithRunas(opts, Assembly.GetExecutingAssembly().Location);
                    if (status == UserState.RestartTryGet)
                        return MessageState.OK;
                    if (status == UserState.NoAdministrator)
                    {
                        return MessageState.Fail("Failed to try to get administrator permission ");
                    }
                }

                if (!string.IsNullOrEmpty(opts.Arguments)) startInfo.Arguments = opts.Arguments;
                startInfo.UseShellExecute = false;
                startInfo.LoadUserProfile = true;
                using (var p = new Process { StartInfo = startInfo })
                {
                    p.Start();
                    return MessageState.OK;
                }
            };

        public static int Main(string[] args)
        {
            Console.Title = "Run a file with specific user";
            try
            {
                var result = Parser.Default.ParseArguments(() => new Options(), args);

                if (result.Tag == ParserResultType.NotParsed)
                {
                    // Console.ReadLine();
                    return 1;
                }

                result.WithParsed(opts =>
                {
                    CallTargetFileWithSpecificUser(opts);
                });
                return 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return 1;
            }
        }

        private static SecureString BuildSecureString(string plaintext)
        {
            var password = new SecureString();
            if (string.IsNullOrEmpty(plaintext)) return password;
            return plaintext.Aggregate(password, (result, cur) => { result.AppendChar(cur); return result; });
        }
    }
}