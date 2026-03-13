namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;

public class FileNode : IFileSystemComponent
{
    public string Name { get; }

    public FileNode(string name)
    {
        Name = name;
    }

    public void Accept(IFileSystemComponentVisitor visitor)
    {
        visitor.Visit(this);
    }
}