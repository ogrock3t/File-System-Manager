using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Connect;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.Connect;

public class DisconnectParser : ParserLinkBase
{
    protected override ICommand? TryParse(ICommandIterator iterator)
    {
        if (!iterator.HasNext() || iterator.MoveNext() != "disconnect")
            return null;

        return new DisconnectCommand();
    }
}