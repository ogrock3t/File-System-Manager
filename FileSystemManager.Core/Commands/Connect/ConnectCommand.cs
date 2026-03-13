using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Connect;

public class ConnectCommand : ICommand
{
    private readonly string _path;

    public ConnectCommand(string path)
    {
        _path = path;
    }

    public void Execute(FileSystemContext context)
    {
        context.FileSystem.Connect(_path);
        context.Writer.Write($"Connected to: {_path}");
    }
}