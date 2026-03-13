using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Tree;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.Tree;

public class TreeListParser : ParserLinkBase
{
    protected override ICommand? TryParse(ICommandIterator iterator)
    {
        if (!iterator.HasNext() || iterator.MoveNext() != "tree")
            return null;

        if (!iterator.HasNext() || iterator.MoveNext() != "list")
            return null;

        int depth = 1;

        while (iterator.HasNext())
        {
            string token = iterator.MoveNext();

            if (token == "d")
            {
                iterator.MoveNext();

                string depthValue = iterator.MoveNext();

                break;
            }
        }

        return new TreeListCommand(depth);
    }
}