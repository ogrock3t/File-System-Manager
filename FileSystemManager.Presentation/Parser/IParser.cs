using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser;

public interface IParser
{
    ICommand? Parse(ICommandIterator iterator);
}