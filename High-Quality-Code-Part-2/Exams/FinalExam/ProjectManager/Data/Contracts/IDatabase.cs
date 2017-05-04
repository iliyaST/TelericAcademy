using ProjectManager.CLI.Models.Contracts;
using System.Collections.Generic;

namespace ProjectManager.CLI.Data.Contracts
{
    /// <summary>
    /// Represents a database for keeping projects.
    /// </summary>
    public interface IDatabase
    {
        /// <summary>
        /// All the projects in the database
        /// </summary>
        IList<IProject> Projects { get; }
    }
}
