using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.File;

public class FileDeleteCommand : ICommand
{
    private readonly string _path;

    public FileDeleteCommand(string path)
    {
        _path = path;
    }

    public void Execute(FileSystemContext context)
    {
        context.FileSystem.DeleteFile(_path);
        context.Writer.Write($"Deleted file: {_path}");
    }
}