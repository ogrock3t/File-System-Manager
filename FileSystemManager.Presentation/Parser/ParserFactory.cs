using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.Connect;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.File;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.Tree;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser;

public class ParserFactory
{
    public IParser CreateParser()
    {
        return new ConnectParser()
            .AddNext(new DisconnectParser())
            .AddNext(new TreeGotoParser())
            .AddNext(new TreeListParser())
            .AddNext(new FileShowParser())
            .AddNext(new FileMoveParser())
            .AddNext(new FileCopyParser())
            .AddNext(new FileDeleteParser())
            .AddNext(new FileRenameParser());
    }
}