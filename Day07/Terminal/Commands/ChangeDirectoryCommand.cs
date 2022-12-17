using Day07.OperatingSystem;

namespace Day07.Terminal.Commands
{
    internal class ChangeDirectoryCommand : ITerminalOutput, ICommand, IHasFileSystemEntry
    {
        internal string? CommandInput { get; private set; }

        internal static string GetCommandSignature() => "cd";

        public List<IFileSystemEntry> GetFileSystemEntries()
        {
            if (CommandInput is null) throw new InvalidOperationException($"{nameof(GetFileSystemEntries)} can't be called when file system entries haven't been loaded");

            if (FileSystem.CurrentDirectory is not null && FileSystem.CurrentDirectory.TryGetChildDirectory(CommandInput, out OperatingSystem.Directory? fileSystemEntry))
            {
                return new() { fileSystemEntry };
            }

            return new() { new OperatingSystem.Directory(CommandInput) };
        }

        public ITerminalOutput Parse(string terminalOutputLine)
        {
            string[] commandArgs = terminalOutputLine.Replace('$', ' ').Trim().Split(' ');

            CommandInput = commandArgs[1];
            return this;
        }
    }
}
