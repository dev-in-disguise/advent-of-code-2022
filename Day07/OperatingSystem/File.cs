namespace Day07.OperatingSystem;

internal class File : FileSystemEntry, IFileSystemEntry
{
    private string _name;
    private int _size;

    public File(string fileName, int fileSize)
    {
        _name = fileName;
        _size = fileSize;
    }

    public int GetSize() => _size;
}
