using Day07.Terminal.Commands;
using Day07.Terminal;
using Day07.OperatingSystem;

namespace Day07;

internal sealed class PartTwo
{
    internal static void Run()
    {
        FileSystem.Format();
        string[] terminalOutputLines = InputProvider.GetInput().Split(Environment.NewLine);
        List<ITerminalOutput> terminalOutputs = new();
        List<string> currentCommandOutput = new();
        foreach (string terminalOutputLine in terminalOutputLines)
        {
            if (Command.IsKnown(terminalOutputLine))
            {
                TryAddCommandOutput(terminalOutputs, currentCommandOutput);

                terminalOutputs.Add(Command.Parse(terminalOutputLine));
            }
            else
            {
                currentCommandOutput.Add(terminalOutputLine);
            }
        }

        TryAddCommandOutput(terminalOutputs, currentCommandOutput);

        foreach (ITerminalOutput terminalOutput in terminalOutputs)
        {
            if (terminalOutput is not IHasFileSystemEntry hasFileSystemEntry) continue;

            if (terminalOutput is ChangeDirectoryCommand cd)
            {
                FileSystem.SetCurrentDirectory(cd);
            }
            else
            {
                FileSystem.Add(hasFileSystemEntry.GetFileSystemEntries());
            }
        }

        List<OperatingSystem.Directory> directories = FileSystem.GetDirectories();
        int totalSize = directories.Where(dir => dir.IsRoot).Single().GetSize();
        int maxSize = 70000000 - 30000000;

        var sizeOfFolderToDelete = directories.Where(dir => (totalSize - dir.GetSize()) <= maxSize).Min(s => s.GetSize());
        
        Console.WriteLine(sizeOfFolderToDelete);
    }

    private static void TryAddCommandOutput(List<ITerminalOutput> terminalOutputs, List<string> currentCommandOutput)
    {
        if (currentCommandOutput.Count == 0) return;

        ITerminalOutput lastOutput = terminalOutputs.Last();

        if (lastOutput is not ISupportAdditionalOutput additionalOutputCommand)
        {
            throw new NotSupportedException($"No additional output supported for command {lastOutput.GetType()}");
        }

        additionalOutputCommand.AddAdditionalOutput(currentCommandOutput);
        currentCommandOutput.Clear();
    }
}