using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Writer;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation;

public class Program
{
    public static void Main(string[] args)
    {
        var fileSystem = new LocalFileSystem();
        var writer = new ConsoleWriter();
        var parserFactory = new ParserFactory();
        IParser parser = parserFactory.CreateParser();
        var context = new FileSystemContext(fileSystem, writer);

        while (true)
        {
            string? input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
                continue;

            var iterator = new CommandIterator(input);

            ICommand? command = parser.Parse(iterator);

            if (command == null)
                writer.Write($"Unknown command: {input}");
            else
                command.Execute(context);
        }
    }
}