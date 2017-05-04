using ProjectManager.CLI.Models;

namespace Pesho.Core.Contracts
{
    /// <summary>
    /// Represents a model factory for creating different models.
    /// </summary>
    public interface IModelsFactory
    {
        /// <summary>
        /// Creates a Project.
        /// </summary>
        /// <param name="name">The name of the project.</param>
        /// <param name="startingDate">The starting date of the project.</param>
        /// <param name="endingDate">The ending date of the project.</param>
        /// <param name="state">The state of the project.</param>
        /// <returns>Returns the created project.</returns>
        Project CreateProject(string name, string startingDate, string endingDate, string state);

        /// <summary>
        /// Creates a task.
        /// </summary>
        /// <param name="owner">The owner of the task.</param>
        /// <param name="name">The name of the task.</param>
        /// <param name="state">The state of the task.</param>
        /// <returns>Returns created task.</returns>
        Task CreateTask(User owner, string name, string state);

        /// <summary>
        /// Creates a user.
        /// </summary>
        /// <param name="username">Username of the user.</param>
        /// <param name="email">Email of the user.</param>
        /// <returns>Returns created user.</returns>
        User CreateUser(string username, string email);
    }
}
