using CommandLine.Text;
using System.Collections.Generic;

namespace Runas
{
    internal class Options : IOptions
    {
        [Usage]
        public static IEnumerable<Example> Usage
        {
            get
            {
                yield return
                    new Example(
                        "Example",
                        new Options
                        {
                            FileName = "%windir%\\system32\\notepad.exe",
                            UserName = "apac\\u rsid",
                            Domain = "",
                            Password = "^%$&*H S^W^",
                            //Arguments = "--password \" ^%$&*H S ^ W ^ \" --username \"apac\\u rsid\" %windir%\\system32\\notepad.exe"

                        });
            }
        }

        public string UserName { get; set; }

        public string Domain { get; set; }

        public string Password { get; set; }

        public string Arguments { get; set; }

        public bool IsSelfcall { get; set; }

        public string FileName { get; set; }
    }
}