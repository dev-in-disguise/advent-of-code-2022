namespace Day07.OperatingSystem
{
    internal abstract class FileSystemEntry
    {
        protected Directory? _parentDirectory;

        public void SetParent(Directory parentDirectory)
        {
            _parentDirectory = parentDirectory;
        }
    }
}