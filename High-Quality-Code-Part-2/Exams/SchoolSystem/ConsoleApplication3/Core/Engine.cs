namespace School.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using ConsoleApplication3.Models.Contracts;
    using Models;
    using Models.Contracts;

    public class Engine
    {
        private IReader reader;
        private IWriter writer;

        public Engine(IReader reader, IWriter writer)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("Engine must have reader!");
            }

            if (writer == null)
            {
                throw new ArgumentNullException("Engine must have writer!");
            }

            this.reader = reader;
            this.writer = writer;

            Teachers = new Dictionary<int, Teacher>();
            Students = new Dictionary<int, Student>();
        }

        internal static Dictionary<int, Teacher> Teachers { get; set; }

        internal static Dictionary<int, Student> Students { get; set; }

        public void Start()
        {
            while (true)
            {
                try
                {
                    var command = this.reader.ReadLine();
                    if (command == "End")
                    {
                        break;
                    }

                    // process
                    var orderName = command.Split(' ')[0];
                    var assembly = this.GetType().GetTypeInfo().Assembly;
                    var infoType = assembly.DefinedTypes
                        .Where(type => type.ImplementedInterfaces.Any(inter => inter == typeof(ICommand)))
                        .Where(type => type.Name.ToLower().Contains(orderName.ToLower()))
                        .FirstOrDefault();

                    if (infoType == null)
                    {
                        throw new ArgumentException("Invalid Command!");
                    }

                    // Execute command
                    var order = Activator.CreateInstance(infoType) as ICommand;
                    var parameters = command.Split(' ').ToList();
                    parameters.RemoveAt(0);

                    // Print
                    this.writer.WriteLine(order.Execute(parameters));
                }
                catch (Exception ex)
                {
                    this.writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
