namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;

public interface IFileSystemComponent
{
    string Name { get; }

    void Accept(IFileSystemComponentVisitor visitor);
}