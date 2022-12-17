using System.Diagnostics.CodeAnalysis;
using Day07.Terminal.Commands;

namespace Day07.OperatingSystem;

internal class Directory : FileSystemEntry, IFileSystemEntry
{
    public string DirectoryName { get; }
    public bool IsRoot { get; }
    public List<IFileSystemEntry> Entries { get; private set; }

    public Directory(string directoryName)
    {
        DirectoryName = directoryName;
        IsRoot = directoryName == "/";
    }

    internal void Add(List<IFileSystemEntry> entries)
    {
        Entries = entries;
    }

    public int GetSize()
    {
        int size = 0;

        foreach (IFileSystemEntry entry in Entries ?? new())
        {
            size += entry.GetSize();
        }

        return size;
    }

    internal Directory GetParent()
    {
        return _parentDirectory ?? throw new InvalidOperationException("Parent directory is hard to get.");
    }

    internal bool TryGetChildDirectory(string commandInput, [NotNullWhen(returnValue: true)] out Directory? fileSystemEntry)
    {
        fileSystemEntry = Entries.Where(entry => entry is Directory dir && dir.DirectoryName == commandInput).Select(entry => (Directory)entry).SingleOrDefault();
        return fileSystemEntry is not null;
    }
}
