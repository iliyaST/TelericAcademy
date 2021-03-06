﻿using Pesho.Core.Contracts;
using ProjectManager.CLI.Common;
using ProjectManager.CLI.Models;
using System;

namespace ProjectManager.CLI.Core
{
    public class ModelsFactory : IModelsFactory
    {
        private readonly Validator validator = new Validator();

        public Project CreateProject(string name, string startingDate, string endingDate, string state)
        {
            DateTime starting;
            DateTime end;
            var startingDateSuccessful = DateTime.TryParse(startingDate, out starting);
            var endingDateSuccessful = DateTime.TryParse(endingDate, out end);

            if (!startingDateSuccessful)
            {
                throw new UserValidationException("Failed to parse the passed starting date!");
            }

            if (!endingDateSuccessful)
            {
                throw new UserValidationException("Failed to parse the passed ending date!");
            }

            var project = new Project(name, starting, end, state);

            this.validator.Validate(project);

            return project;
        }

        public Task CreateTask(User owner, string name, string state)
        {
            var task = new Task(name, owner, state);

            this.validator.Validate(task);

            return task;
        }       

        public User CreateUser(string username, string email)
        {
            var user = new User(username, email);

            this.validator.Validate(user);

            return user;
        }       
    }
}
