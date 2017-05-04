namespace ProjectManager.CLI.Core.Contracts
{
    public interface IParser
    {
        string ProcessCommand(string fullCommandName);
    }
}
