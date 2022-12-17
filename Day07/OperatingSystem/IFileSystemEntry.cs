namespace Day07.OperatingSystem
{
    internal interface IFileSystemEntry
    {
        void SetParent(Directory parentDirectory);
        int GetSize();
    }
}