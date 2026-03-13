using Itmo.ObjectOrientedProgramming.Lab4.Core.Writer;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;

public class FileSystemContext
{
    public IFileSystem FileSystem { get; }

    public IWriter Writer { get; }

    public FileSystemContext(IFileSystem fileSystem, IWriter writer)
    {
        FileSystem = fileSystem;
        Writer = writer;
    }
}