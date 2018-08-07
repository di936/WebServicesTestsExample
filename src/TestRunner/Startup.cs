using System.IO;
using System.Reflection;
using System.Threading;

namespace TestRunner
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var console = Config.Default.Console;
            var tests = Config.Default.Tests;

            var runner = new Runner();
            runner.Run(console, tests, args);
        }
    }
}
