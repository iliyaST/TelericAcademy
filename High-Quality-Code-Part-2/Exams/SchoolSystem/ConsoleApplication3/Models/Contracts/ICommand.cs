namespace School.Models.Contracts
{
    using System.Collections.Generic;

    public interface ICommand
    {
        /// <summary>
        /// This method executes the current command
        /// </summary>
        /// <param name="parameters">The command parameters.</param>
        /// <returns>Returns string that descripes wether the command is succesfully executed or not.</returns>
        string Execute(IList<string> parameters);
    }
}
