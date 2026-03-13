using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Tree;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.Tree;

public class TreeGotoParser : ParserLinkBase
{
    protected override ICommand? TryParse(ICommandIterator iterator)
    {
        if (!iterator.HasNext() || iterator.MoveNext() != "tree")
            return null;

        if (!iterator.HasNext() || iterator.MoveNext() != "goto")
            return null;

        string path = iterator.MoveNext();

        return new TreeGotoCommand(path);
    }
}