namespace Day07.Terminal.Commands
{
    internal interface ICommand
    {
        ITerminalOutput Parse(string terminalOutputLine);
    }
}