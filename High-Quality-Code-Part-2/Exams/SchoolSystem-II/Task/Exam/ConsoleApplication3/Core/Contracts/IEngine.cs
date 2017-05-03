namespace SchoolSystem.CLI.Core.Contracts
{
    using System.Collections.Generic;
    using Models;

    public interface IEngine
    {
        IReader Reader { get; set; }

        IWriter Writer { get; set; }

        IParser Parser { get; set; }

        Dictionary<int, Teacher> Teachers { get; set; }

        Dictionary<int, Student> Students { get; set; }

        void Start();
    }
}
