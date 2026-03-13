using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Tree;

public class TreeListCommand : ICommand
{
    private readonly int _depth;

    public TreeListCommand(int depth)
    {
        _depth = depth;
    }

    public void Execute(FileSystemContext context)
    {
        DirectoryNode tree = context.FileSystem.BuildTree(".", _depth);
        var visitor = new FormattingVisitor(context.Writer, _depth);
        tree.Accept(visitor);
        visitor.Write();
    }
}