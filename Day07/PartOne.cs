using Day07.OperatingSystem;
using Day07.Terminal;
using Day07.Terminal.Commands;

namespace Day07;

internal sealed class PartOne
{
    internal static void Run()
    {
        FileSystem.Format();
        string[] terminalOutputLines = InputProvider.GetInput().Split(Environment.NewLine);
        List<ITerminalOutput> terminalOutputs = new();
        List<string> currentCommandOutput = new();
        foreach(string terminalOutputLine in terminalOutputLines)
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
            
            if(terminalOutput is ChangeDirectoryCommand cd)
            {
                FileSystem.SetCurrentDirectory(cd);
            }
            else
            {
                FileSystem.Add(hasFileSystemEntry.GetFileSystemEntries());
            }
        }

        List<OperatingSystem.Directory> directories = FileSystem.GetDirectories();
        int totalSize = 0;

        foreach(OperatingSystem.Directory directory in directories)
        {
            int size = directory.GetSize();

            if(size <= 100000)
            {
                totalSize += size;
            }
        }

        Console.WriteLine(totalSize);
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