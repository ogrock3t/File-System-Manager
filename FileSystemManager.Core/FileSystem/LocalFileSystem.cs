namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;

public class LocalFileSystem : IFileSystem
{
    private string _connectionPath = string.Empty;

    private string _localPath = string.Empty;

    public void Connect(string absolutePath)
    {
        if (!Path.IsPathRooted(absolutePath))
            throw new ArgumentException("Path must be absolute", nameof(absolutePath));

        if (!Directory.Exists(absolutePath))
            throw new DirectoryNotFoundException($"Directory not found: {absolutePath}");

        _connectionPath = absolutePath;
        _localPath = absolutePath;
    }

    public void Disconnect()
    {
        _connectionPath = string.Empty;
        _localPath = string.Empty;
    }

    public void NavigateTo(string path)
    {
        if (string.IsNullOrEmpty(_connectionPath))
            throw new InvalidOperationException("Not connection to file system");

        string targetPath = Path.Combine(_localPath, path);

        if (!Directory.Exists(targetPath))
            throw new DirectoryNotFoundException($"Directory not found: {targetPath}");

        _localPath = targetPath;
    }

    public IEnumerable<string> GetFiles(string path)
    {
        if (string.IsNullOrEmpty(_connectionPath))
            throw new InvalidOperationException("Not connection to file system");

        string targetPath = Path.Combine(_localPath, path);

        if (!Directory.Exists(targetPath))
            throw new DirectoryNotFoundException($"Directory not found: {targetPath}");

        return Directory.GetFiles(targetPath);
    }

    public IEnumerable<string> GetDirectories(string absolutePath)
    {
        if (string.IsNullOrEmpty(_connectionPath))
            throw new InvalidOperationException("Not connection to file system");

        string targetPath = Path.Combine(_localPath, absolutePath);

        if (!Directory.Exists(targetPath))
            throw new DirectoryNotFoundException($"Directory not found: {targetPath}");

        return Directory.GetDirectories(targetPath);
    }

    public string ReadFile(string path)
    {
        if (string.IsNullOrEmpty(_connectionPath))
            throw new InvalidOperationException("Not connection to file system");

        string targetPath = Path.Combine(_localPath, path);

        if (!File.Exists(targetPath))
            throw new FileNotFoundException($"File not found: {targetPath}");

        return File.ReadAllText(targetPath);
    }

    public void MoveFile(string source, string destination)
    {
        if (string.IsNullOrEmpty(_connectionPath))
            throw new InvalidOperationException("Not connection to file system");

        string sourcePath = Path.Combine(_localPath, source);
        string destinationPath = Path.Combine(_localPath, destination);

        if (!File.Exists(sourcePath))
            throw new FileNotFoundException($"File not found: {sourcePath}");

        if (!Directory.Exists(destinationPath))
            throw new DirectoryNotFoundException($"Directory not found: {destinationPath}");

        string fileName = Path.GetFileName(sourcePath);
        string destinationFileName = Path.Combine(destinationPath, fileName);

        if (File.Exists(destinationFileName))
            throw new ArgumentException($"File already exists: {destinationFileName}");

        File.Move(sourcePath, destinationFileName);
    }

    public void CopyFile(string source, string destination)
    {
        if (string.IsNullOrEmpty(_connectionPath))
            throw new InvalidOperationException("Not connection to file system");

        string sourcePath = Path.Combine(_localPath, source);
        string destinationPath = Path.Combine(_localPath, destination);

        if (!File.Exists(sourcePath))
            throw new FileNotFoundException($"File not found: {sourcePath}");

        if (!Directory.Exists(destinationPath))
            throw new DirectoryNotFoundException($"Directory not found: {destinationPath}");

        string fileName = Path.GetFileName(sourcePath);
        string destinationFileName = Path.Combine(destinationPath, fileName);

        if (File.Exists(destinationFileName))
            throw new ArgumentException($"File already exists: {destinationFileName}");

        File.Copy(sourcePath, destinationFileName);
    }

    public void DeleteFile(string path)
    {
        if (string.IsNullOrEmpty(_connectionPath))
            throw new InvalidOperationException("Not connection to file system");

        string targetPath = Path.Combine(_localPath, path);

        if (!File.Exists(targetPath))
            throw new FileNotFoundException($"File not found: {targetPath}");

        File.Delete(targetPath);
    }

    public void RenameFile(string source, string newName)
    {
        if (string.IsNullOrEmpty(_connectionPath))
            throw new InvalidOperationException("Not connection to file system");

        if (newName.Contains('/', StringComparison.Ordinal))
            throw new ArgumentException($"Invalid name '{newName}'", nameof(newName));

        string filePath = Path.Combine(_localPath, source);

        if (!File.Exists(filePath))
            throw new FileNotFoundException($"File not found: {filePath}");

        string? directoryName = Path.GetDirectoryName(filePath);

        if (directoryName == null)
            throw new DirectoryNotFoundException($"Directory not found: {filePath}");

        string targetPath = Path.Combine(directoryName, newName);

        if (File.Exists(targetPath))
            throw new ArgumentException($"File with name: {newName} already exists");

        File.Move(filePath, targetPath);
    }

    public DirectoryNode BuildTree(string path, int depth)
    {
        if (string.IsNullOrEmpty(_connectionPath))
            throw new InvalidOperationException("Not connection to file system");

        string targetPath = Path.Combine(_localPath, path);

        if (!Directory.Exists(targetPath))
            throw new DirectoryNotFoundException($"Directory not found: {targetPath}");

        string dirName = path == "." ? "." : Path.GetFileName(targetPath);

        return BuildTreeRecursive(targetPath, dirName ?? ".", depth, 0);
    }

    private DirectoryNode BuildTreeRecursive(string path, string name, int maxDepth, int currentDepth)
    {
        var node = new DirectoryNode(path);

        if (currentDepth > maxDepth)
            return node;

        foreach (string dir in Directory.GetDirectories(path))
        {
            string dirName = Path.GetFileName(dir) ?? string.Empty;

            if (!string.IsNullOrEmpty(dirName))
            {
                DirectoryNode childNode = BuildTreeRecursive(dir, dirName, maxDepth, currentDepth + 1);
                node.Add(childNode);
            }
        }

        foreach (string file in Directory.GetFiles(path))
        {
            string fileName = Path.GetFileName(file) ?? string.Empty;

            if (!string.IsNullOrEmpty(fileName))
            {
                node.Add(new FileNode(fileName));
            }
        }

        return node;
    }
}