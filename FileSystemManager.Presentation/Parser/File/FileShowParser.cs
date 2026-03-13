using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.File;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.File;

public class FileShowParser : ParserLinkBase
{
    protected override ICommand? TryParse(ICommandIterator iterator)
    {
        if (!iterator.HasNext() || iterator.MoveNext() != "file")
            return null;

        if (!iterator.HasNext() || iterator.MoveNext() != "show")
            return null;

        string path = iterator.MoveNext();

        return new FileShowCommand(path);
    }
}