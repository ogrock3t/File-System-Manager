namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser;

public interface IParserLink : IParser
{
    IParserLink AddNext(IParserLink link);
}