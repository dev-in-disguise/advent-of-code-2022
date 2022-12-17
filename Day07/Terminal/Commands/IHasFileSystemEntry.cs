using Day07.OperatingSystem;

namespace Day07.Terminal.Commands
{
    internal interface IHasFileSystemEntry
    {
        List<IFileSystemEntry> GetFileSystemEntries();
    }
}