using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Connect;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.File;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Tree;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Writer;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class ParserTest
{
    [Fact]
    public void Parse_ConnectCommand_ReturnConnectCommand()
    {
        // Arrange
        var fileSystem = new LocalFileSystem();
        var writer = new ConsoleWriter();
        var factory = new ParserFactory();
        IParser parser = factory.CreateParser();
        string input = "connect /Users/ogrock3t";
        var iterator = new CommandIterator(input);

        // Act
        ICommand? command = parser.Parse(iterator);

        // Assert
        Assert.NotNull(command);
        Assert.IsType<ConnectCommand>(command);
    }

    [Fact]
    public void Parse_DisconnectCommand_ReturnDisconnectCommand()
    {
        // Arrange
        var fileSystem = new LocalFileSystem();
        var writer = new ConsoleWriter();
        var factory = new ParserFactory();
        IParser parser = factory.CreateParser();
        string input = "disconnect";
        var iterator = new CommandIterator(input);

        // Act
        ICommand? command = parser.Parse(iterator);

        // Assert
        Assert.NotNull(command);
        Assert.IsType<DisconnectCommand>(command);
    }

    [Fact]
    public void Parse_TreeGotoCommand_ReturnTreeGotoCommand()
    {
        // Arrange
        var fileSystem = new LocalFileSystem();
        var writer = new ConsoleWriter();
        var factory = new ParserFactory();
        IParser parser = factory.CreateParser();
        string input = "tree goto /folder";
        var iterator = new CommandIterator(input);

        // Act
        ICommand? command = parser.Parse(iterator);

        // Assert
        Assert.NotNull(command);
        Assert.IsType<TreeGotoCommand>(command);
    }

    [Fact]
    public void Parse_TreeListCommand_ReturnTreeListCommand()
    {
        // Arrange
        var fileSystem = new LocalFileSystem();
        var writer = new ConsoleWriter();
        var factory = new ParserFactory();
        IParser parser = factory.CreateParser();
        string input = "tree list -d 2";
        var iterator = new CommandIterator(input);

        // Act
        ICommand? command = parser.Parse(iterator);

        // Assert
        Assert.NotNull(command);
        Assert.IsType<TreeListCommand>(command);
    }

    [Fact]
    public void Parse_FileShowCommand_ReturnFileShowCommand()
    {
        // Arrange
        var fileSystem = new LocalFileSystem();
        var writer = new ConsoleWriter();
        var factory = new ParserFactory();
        IParser parser = factory.CreateParser();
        string input = "file show file.txt";
        var iterator = new CommandIterator(input);

        // Act
        ICommand? command = parser.Parse(iterator);

        // Assert
        Assert.NotNull(command);
        Assert.IsType<FileShowCommand>(command);
    }

    [Fact]
    public void Parse_FileMoveCommand_ReturnFileMoveCommand()
    {
        // Arrange
        var fileSystem = new LocalFileSystem();
        var writer = new ConsoleWriter();
        var factory = new ParserFactory();
        IParser parser = factory.CreateParser();
        string input = "file move file.txt folder";
        var iterator = new CommandIterator(input);

        // Act
        ICommand? command = parser.Parse(iterator);

        // Assert
        Assert.NotNull(command);
        Assert.IsType<FileMoveCommand>(command);
    }

    [Fact]
    public void Parse_FileCopyCommand_ReturnFileCopyCommand()
    {
        // Arrange
        var fileSystem = new LocalFileSystem();
        var writer = new ConsoleWriter();
        var factory = new ParserFactory();
        IParser parser = factory.CreateParser();
        string input = "file copy file.txt folder";
        var iterator = new CommandIterator(input);

        // Act
        ICommand? command = parser.Parse(iterator);

        // Assert
        Assert.NotNull(command);
        Assert.IsType<FileCopyCommand>(command);
    }

    [Fact]
    public void Parse_FileDeleteCommand_ReturnFileDeleteCommand()
    {
        // Arrange
        var fileSystem = new LocalFileSystem();
        var writer = new ConsoleWriter();
        var factory = new ParserFactory();
        IParser parser = factory.CreateParser();
        string input = "file delete file.txt";
        var iterator = new CommandIterator(input);

        // Act
        ICommand? command = parser.Parse(iterator);

        // Assert
        Assert.NotNull(command);
        Assert.IsType<FileDeleteCommand>(command);
    }

    [Fact]
    public void Parse_FileRenameCommand_ReturnFileRenameCommand()
    {
        // Arrange
        var fileSystem = new LocalFileSystem();
        var writer = new ConsoleWriter();
        var factory = new ParserFactory();
        IParser parser = factory.CreateParser();
        string input = "file rename file.txt 123.txt";
        var iterator = new CommandIterator(input);

        // Act
        ICommand? command = parser.Parse(iterator);

        // Assert
        Assert.NotNull(command);
        Assert.IsType<FileRenameCommand>(command);
    }
}