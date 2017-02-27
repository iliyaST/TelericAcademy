
using System;

namespace School
{
    public class Student
    {
        private string name;
        private string id;

        public Student()
        {
           
        }

        public Student(string id)
        {
            this.Id = id;
        }

        public Student(string name, string id)
        {
            this.Name = name;
            this.Id = id;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException();
                }

                if (value == "")
                {
                    throw new ArgumentException();
                }

                this.name = value;
            }
        }

        public string Id
        {
            get
            {
                return this.id;
            }
            set
            {
                if (int.Parse(value) < 10000 || int.Parse(value) > 99999)
                {
                    throw new ArgumentOutOfRangeException();
                }

                this.id = value;
            }
        }
    }
}
