using System.Diagnostics.CodeAnalysis;
using Day07.Terminal.Commands;

namespace Day07.OperatingSystem;

internal static class FileSystem
{
    private static List<Directory> _directories = new();

    public static Directory? CurrentDirectory { get; private set; }

    internal static void Add(List<IFileSystemEntry> entries)
    {
        if(CurrentDirectory is null)
        {
            throw new NotSupportedException("Hopefully we don't get ls as the first command in round 2");
        }

        CurrentDirectory.Add(entries);

        foreach(IFileSystemEntry entry in entries)
        {
            entry.SetParent(CurrentDirectory);

            if (entry is Directory directory)
            {    
                _directories.Add(directory);
            }
        }
    }

    internal static List<Directory> GetDirectories() => _directories;

    internal static void SetCurrentDirectory(ChangeDirectoryCommand cd)
    {
        if(cd.CommandInput == "..")
        {
            SetCurrentDirectory(CurrentDirectory.GetParent());
        }
        else
        {
            SetCurrentDirectory(cd.GetFileSystemEntries().Select(s => (Directory)s).Single());
        }
    }

    internal static void Format()
    {
        _directories.Clear();
        CurrentDirectory = null;
    }

    private static void SetCurrentDirectory(Directory dir)
    {
        CurrentDirectory = dir;

        if(!_directories.Any(s => s.DirectoryName == dir.DirectoryName))
        {
            _directories.Add(dir);
        }
    }
}
