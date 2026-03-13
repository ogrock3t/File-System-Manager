using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Connect;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.Connect;

public class ConnectParser : ParserLinkBase
{
    protected override ICommand? TryParse(ICommandIterator iterator)
    {
        if (!iterator.HasNext() || iterator.MoveNext() != "connect")
            return null;

        if (!iterator.HasNext())
            return null;

        string path = iterator.MoveNext();

        return new ConnectCommand(path);
    }
}