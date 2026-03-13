using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.File;

public class FileCopyCommand : ICommand
{
    private readonly string _path;
    private readonly string _destination;

    public FileCopyCommand(string path, string destination)
    {
        _path = path;
        _destination = destination;
    }

    public void Execute(FileSystemContext context)
    {
        context.FileSystem.CopyFile(_path, _destination);
        context.Writer.Write($"Copied file from {_path} to {_destination}.");
    }
}