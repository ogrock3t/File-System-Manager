using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.File;

public class FileShowCommand : ICommand
{
    private readonly string _path;

    public FileShowCommand(string path)
    {
        _path = path;
    }

    public void Execute(FileSystemContext context)
    {
        string content = context.FileSystem.ReadFile(_path);
        context.Writer.Write($"Content from: {_path}");
        context.Writer.Write(content);
    }
}