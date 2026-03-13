namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;

public class DirectoryNode : IFileSystemComponent
{
    private readonly List<IFileSystemComponent> _components = new List<IFileSystemComponent>();

    public string Name { get; }

    public IReadOnlyList<IFileSystemComponent> Components => _components;

    public DirectoryNode(string name)
    {
        Name = name;
    }

    public void Add(IFileSystemComponent component)
    {
        _components.Add(component);
    }

    public void Accept(IFileSystemComponentVisitor visitor)
    {
        visitor.Visit(this);
    }
}