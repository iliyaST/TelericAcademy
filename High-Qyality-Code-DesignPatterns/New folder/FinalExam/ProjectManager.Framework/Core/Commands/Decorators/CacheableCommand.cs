using ProjectManager.Framework.Core.Commands.Contracts;
using ProjectManager.Framework.Data;
using ProjectManager.Framework.Services;
using System;
using System.Collections.Generic;

namespace ProjectManager.Framework.Core.Commands.Decorators
{
    public class CacheableCommand : ICommand
    {
        private readonly ICommand command;
        private ICachingService service;
        private int count = 1;

        public CacheableCommand(ICommand command, ICachingService service)
        {
            this.command = command;
            this.service = service;
        }

        public int ParameterCount
        {
            get
            {
                return this.command.ParameterCount;
            }
        }

        public string Execute(IList<string> parameters)
        {
            if (this.count == 1)
            {
                this.service.AddCacheValue("ListProjects", "Execute", command.Execute(new List<string>()));

                this.count++;

                return command.Execute(new List<string>());
            }

            if (!this.service.IsExpired && this.count != 1)
            {
                var catche = this.service.GetCacheValue("ListProjects", "Execute");
                return string.Join(Environment.NewLine, catche);
            }

            return command.Execute(new List<string>());
        }
    }
}
