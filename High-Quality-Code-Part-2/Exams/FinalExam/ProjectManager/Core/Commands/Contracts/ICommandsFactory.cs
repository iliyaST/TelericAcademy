namespace ProjectManager.CLI.Core.Commands.Contracts
{
    /// <summary>
    /// Represents a command generator for creating different commands
    /// </summary>
    public interface ICommandsFactory
    {
        /// <summary>
        /// Creates a command by a given name
        /// </summary>
        /// <param name="commandName">The name of the command.</param>
        /// <returns>Returns the specific command.</returns>
        ICommand CreateCommandFromString(string commandName);
    }
}