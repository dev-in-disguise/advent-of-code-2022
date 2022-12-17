using Day07.Terminal.Commands;

namespace Day07.Terminal;

internal sealed class Command
{
    private static readonly Dictionary<string, Func<ICommand>> _commands = new()
    {
        { ChangeDirectoryCommand.GetCommandSignature(), () => new ChangeDirectoryCommand() },
        { ListCommand.GetCommandSignature(), () => new ListCommand() },
    };

    internal static bool IsKnown(string input) =>
        input.StartsWith('$') 
        && _commands.Keys.Any(input.Contains);

    internal static ITerminalOutput Parse(string terminalOutputLine)
    {
        foreach(var commandEntry in _commands)
        {
            if (terminalOutputLine.Contains(commandEntry.Key))
            {
                return commandEntry.Value.Invoke().Parse(terminalOutputLine);
            }
        }

        throw new ArgumentException($"Output line is no known command: '{terminalOutputLine}'", nameof(terminalOutputLine));
    }
}
