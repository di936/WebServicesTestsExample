using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace TestRunner
{
    internal class Runner
    {
        public void Run(string filePath, string testFilePath, string[] args)
        {
            var processInfo = new ProcessStartInfo
            {
                FileName = filePath,
                Arguments = $"{ testFilePath } { string.Join(" ", args.Where(arg => !string.IsNullOrEmpty(arg))) }"
            };

            var process = new Process
            {
                StartInfo = processInfo
            };

            process.Start();
            process.WaitForExit();
        }
    }
}