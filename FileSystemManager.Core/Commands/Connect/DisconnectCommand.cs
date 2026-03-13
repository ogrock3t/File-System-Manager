using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Connect;

public class DisconnectCommand : ICommand
{
    public void Execute(FileSystemContext context)
    {
        context.FileSystem.Disconnect();
        context.Writer.Write("Disconnected from file system");
    }
}