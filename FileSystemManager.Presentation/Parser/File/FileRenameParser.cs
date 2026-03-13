using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.File;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.File;

public class FileRenameParser : ParserLinkBase
{
    protected override ICommand? TryParse(ICommandIterator iterator)
    {
        if (!iterator.HasNext() || iterator.MoveNext() != "file")
            return null;

        if (!iterator.HasNext() || iterator.MoveNext() != "rename")
            return null;

        string path = iterator.MoveNext();
        string name = iterator.MoveNext();

        return new FileRenameCommand(path, name);
    }
}