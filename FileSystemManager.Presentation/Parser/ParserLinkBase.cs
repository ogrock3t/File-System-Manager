using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser;

public abstract class ParserLinkBase : IParserLink
{
    private IParserLink? _next;

    public IParserLink AddNext(IParserLink link)
    {
        if (_next == null)
            _next = link;
        else
            _next.AddNext(link);

        return this;
    }

    public ICommand? Parse(ICommandIterator iterator)
    {
        ICommand? command = TryParse(iterator);

        if (command != null)
            return command;

        iterator.Reset();

        return _next?.Parse(iterator);
    }

    protected abstract ICommand? TryParse(ICommandIterator iterator);
}