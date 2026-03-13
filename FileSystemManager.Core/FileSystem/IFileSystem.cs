namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;

public interface IFileSystem
{
    void Connect(string absolutePath);

    void Disconnect();

    void NavigateTo(string path);

    IEnumerable<string> GetFiles(string path);

    IEnumerable<string> GetDirectories(string absolutePath);

    string ReadFile(string path);

    void MoveFile(string source, string destination);

    void CopyFile(string source, string destination);

    void DeleteFile(string path);

    void RenameFile(string source, string newName);

    DirectoryNode BuildTree(string path, int depth);
}