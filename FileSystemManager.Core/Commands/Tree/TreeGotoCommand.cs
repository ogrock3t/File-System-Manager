using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Tree;

public class TreeGotoCommand : ICommand
{
    private readonly string _path;

    public TreeGotoCommand(string path)
    {
        _path = path;
    }

    public void Execute(FileSystemContext context)
    {
        context.FileSystem.NavigateTo(_path);
        context.Writer.Write($"Navigated to: {_path}");
    }
}