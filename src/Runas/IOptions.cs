namespace Runas
{
    using CommandLine;

    internal interface IOptions
    {
        [Value(0, MetaName = "path",
         HelpText = "It's full path of running file and must be exist.", Required = true)]
        string FileName { get; set; }

        [Option('u', "username", SetName = "byUser",
            HelpText =
                "Running file under this account, can be None/Empty if using current account, also can be like \"domain\\username\""
            )]
        string UserName { get; set; }

        [Option('d', "domain", SetName = "byUser", HelpText = "Domain of account")]
        string Domain { get; set; }

        [Option('p', "password", SetName = "byUser", HelpText = "Password for the account, use quotation liked \"space and special chars\"")]
        string Password { get; set; }

        [Option('a', "arguments", HelpText = "Arguments for running file")]
        string Arguments { get; set; }

        [Option('s', "selfcall", Hidden = true, HelpText = "")]
        bool IsSelfcall { get; set; }
    }
}