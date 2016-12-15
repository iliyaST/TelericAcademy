using System.Collections.Generic;

namespace School
{
    class School
    {      
        private List<ClassOfStudents> classes = new List<ClassOfStudents>();

        public School(string name)
        {
            this.Name = name;
        }

        public string Name { get; }
        
        //add class
        public void AddClass(ClassOfStudents @class)
        {
            this.classes.Add(@class);
        }

        //remove class
        public void RemoveClass(ClassOfStudents @class)
        {
            this.classes.Remove(@class);
        }

        //get all classes as a list
        public List<ClassOfStudents> GetClasses()
        {
            return this.classes;
        }
    }
}