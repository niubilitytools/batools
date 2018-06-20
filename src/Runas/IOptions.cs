namespace Runas
{
    using CommandLine;

    internal interface IOptions
    {
        [Option('u', "username", SetName = "byUser",
            HelpText =
                "run the file with this account, please keep None/Empty if you would like to run the file with current account"
            )]
        string UserName { get; set; }

        [Option('d', "domain", SetName = "byUser", HelpText = "domain of account")]
        string Domain { get; set; }

        [Option('p', "password", SetName = "byUser", HelpText = "password of account")]
        string Password { get; set; }

        [Option('a', "arguments", HelpText = "arguments of exe file")]
        string Arguments { get; set; }

        [Option('s', "selfcall", HelpText = "")]
        bool IsSelfcall { get; set; }

        [Value(0, MetaName = "exe file full path",
            HelpText = "full path, this is must be required and this file must exist.", Required = true)]
        string FileName { get; set; }
    }
}