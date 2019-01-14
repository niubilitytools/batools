namespace Runas
{
    using CommandLine;

    internal interface IOptions
    {
        [Value(0, MetaName = "file path",
         HelpText = "A full path that's the running file and must be exist.", Required = true)]
        string FileName { get; set; }

        [Option('u', "username", SetName = "byUser",
            HelpText =
                "Running the file with this account, can be None/Empty if using current account, also can be like \"domain\\username\""
            )]
        string UserName { get; set; }

        [Option('d', "domain", SetName = "byUser", HelpText = "Domain of account")]
        string Domain { get; set; }

        [Option('p', "password", SetName = "byUser", HelpText = "Password for the account, use quotation liked \"space and special chars\"")]
        string Password { get; set; }

        [Option('a', "arguments", HelpText = "Arguments for running file")]
        string Arguments { get; set; }

        [Option('s', "selfcall", Hidden = true, HelpText = "A signal for internal use")]
        bool IsSelfcall { get; set; }
    }
}
