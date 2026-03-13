using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.File;

public class FileRenameCommand : ICommand
{
    private readonly string _path;
    private readonly string _newName;

    public FileRenameCommand(string path, string newName)
    {
        _path = path;
        _newName = newName;
    }

    public void Execute(FileSystemContext context)
    {
        context.FileSystem.RenameFile(_path, _newName);
        context.Writer.Write($"Renamed file {_path} to {_newName}");
    }
}