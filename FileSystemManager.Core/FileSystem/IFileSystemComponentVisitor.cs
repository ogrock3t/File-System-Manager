namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;

public interface IFileSystemComponentVisitor
{
    void Visit(FileNode file);

    void Visit(DirectoryNode directory);
}