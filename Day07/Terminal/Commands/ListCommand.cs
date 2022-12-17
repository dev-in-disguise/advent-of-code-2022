using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Day07.OperatingSystem;

namespace Day07.Terminal.Commands
{
    internal class ListCommand : ITerminalOutput, ICommand, ISupportAdditionalOutput, IHasFileSystemEntry
    {
        private List<string>? _additionalOutput;

        internal static string GetCommandSignature() => "ls";

        public ITerminalOutput Parse(string terminalOutputLine) => this;

        public void AddAdditionalOutput(List<string> additionalOutput)
        {
            _additionalOutput = additionalOutput.ToList();
        }

        public List<IFileSystemEntry> GetFileSystemEntries()
        {
            if (_additionalOutput is null) throw new InvalidOperationException($"{nameof(GetFileSystemEntries)} can't be called when file system entries haven't been loaded");

            List<IFileSystemEntry> fileSystemEntries = new();

            foreach(string output in _additionalOutput)
            {
                string[] split = output.Split(' ');

                if (split[0] == "dir")
                {
                    fileSystemEntries.Add(new OperatingSystem.Directory(split[1]));
                }
                else
                {
                    fileSystemEntries.Add(new OperatingSystem.File(split[1], int.Parse(split[0])));
                }
            }

            return fileSystemEntries;
        }
    }
}
