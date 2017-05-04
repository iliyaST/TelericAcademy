namespace ProjectManager.CLI.Core.Contracts
{
    public interface IFileLogger
    {
        void Error(string message);

        void Fatal(string message);

        void Info(string message);
    }
}
