using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.File;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.File;

public class FileMoveParser : ParserLinkBase
{
    protected override ICommand? TryParse(ICommandIterator iterator)
    {
        if (!iterator.HasNext() || iterator.MoveNext() != "file")
            return null;

        if (!iterator.HasNext() || iterator.MoveNext() != "move")
            return null;

        string source = iterator.MoveNext();
        string destination = iterator.MoveNext();

        return new FileMoveCommand(source, destination);
    }
}