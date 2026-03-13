using Itmo.ObjectOrientedProgramming.Lab4.Core.Writer;
using System.Text;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;

public sealed class FormattingVisitor : IFileSystemComponentVisitor
{
    private readonly StringBuilder _builder = new();
    private readonly IWriter _writer;
    private readonly int _maxDepth;
    private int _padding;

    public FormattingVisitor(IWriter writer, int maxDepth)
    {
        _writer = writer;
        _maxDepth = maxDepth;
        _padding = 0;
    }

    public string Value => _builder.ToString();

    public void Visit(FileNode file)
    {
        _builder.Append(' ', _padding);
        _builder.AppendLine(file.Name);
    }

    public void Visit(DirectoryNode directory)
    {
        _builder.Append(' ', _padding);
        _builder.AppendLine(directory.Name);

        if (_padding >= _maxDepth)
            return;

        _padding += 1;

        foreach (IFileSystemComponent child in directory.Components)
        {
            child.Accept(this);
        }

        _padding -= 1;
    }

    public void Write()
    {
        string result = _builder.ToString();
        string[] lines = result.Split('\n');

        foreach (string line in lines)
        {
            _writer.Write(line);
        }
    }
}