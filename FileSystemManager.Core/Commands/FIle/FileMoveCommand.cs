using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.File;

public class FileMoveCommand : ICommand
{
    private readonly string _path;
    private readonly string _destination;

    public FileMoveCommand(string path, string destination)
    {
        _path = path;
        _destination = destination;
    }

    public void Execute(FileSystemContext context)
    {
        context.FileSystem.MoveFile(_path, _destination);
        context.Writer.Write($"Moved file from {_path} to {_destination}.");
    }
}