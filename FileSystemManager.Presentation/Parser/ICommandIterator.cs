namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser;

public interface ICommandIterator
{
    bool HasNext();

    string MoveNext();

    string? Peek();

    void Reset();
}