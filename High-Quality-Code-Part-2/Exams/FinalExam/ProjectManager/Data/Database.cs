using ProjectManager.CLI.Data.Contracts;
using ProjectManager.CLI.Models.Contracts;
using System.Collections.Generic;

namespace ProjectManager.CLI.Data
{
    // You are not allowed to modify this class
    public class Database : IDatabase
    {
        private static IList<IProject> projects;

        static Database()
        {
            projects = new List<IProject>();
        }

        public IList<IProject> Projects
        {
            get
            {
                return projects;
            }
        }
    }
}
