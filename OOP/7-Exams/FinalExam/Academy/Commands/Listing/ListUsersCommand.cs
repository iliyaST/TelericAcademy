namespace Academy.Commands.Listing
{
    using Contracts;
    using System.Collections.Generic;
    using Core.Contracts;
    using System.Text;
    using System.Linq;

    public class ListUsersCommand : ICommand
    {
        private readonly IAcademyFactory factory;
        private readonly IEngine engine;

        public ListUsersCommand(IAcademyFactory factory, IEngine engine)
        {
            this.factory = factory;
            this.engine = engine;
        }

        public string Execute(IList<string> parameters)
        {
            var sb = new StringBuilder();

            if (this.engine.Trainers.Any())
            {
                foreach (var trainer in this.engine.Trainers)
                {
                    sb.AppendLine(trainer.ToString());
                }
            }

            if (this.engine.Students.Any())
            {
                foreach (var student in this.engine.Students)
                {
                    sb.AppendLine(student.ToString());
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
