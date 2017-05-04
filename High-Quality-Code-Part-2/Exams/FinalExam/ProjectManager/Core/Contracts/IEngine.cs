namespace ProjectManager.CLI.Core.Contracts
{
    /// <summary>
    /// Represents a instance for executing the program.
    /// </summary>
    public interface IEngine
    {
        /// <summary>
        /// Represents the main executing function responsible for the executing of the commands.
        /// </summary>
        void Start();
    }
}
