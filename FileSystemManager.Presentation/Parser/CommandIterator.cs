namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser;

public class CommandIterator : ICommandIterator
{
    private readonly string[] _tokens;
    private int _position;

    public CommandIterator(string input)
    {
        _tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        _position = 0;
    }

    public bool HasNext()
    {
        return _position < _tokens.Length;
    }

    public string MoveNext()
    {
        if (!HasNext())
            throw new InvalidOperationException("No more tokens");

        return _tokens[_position++];
    }

    public string? Peek()
    {
        return HasNext() ? _tokens[_position] : null;
    }

    public void Reset()
    {
        _position = 0;
    }
}