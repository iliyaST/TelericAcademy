
namespace School
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Course : ICourse
    {

        public ICollection<Student> Students { get; set; }

        public void Add(Student student)
        {
            if (student != null)
            {
                if (Students.Count < 30)
                {
                    Students.Add(student);
                }
                else 
                {
                    throw new ArgumentException("Student can't be more than 30 in one course!");
                }
            }
        }

        public void Remove(Student student)
        {         
            if (student != null)
            {
                Students.Remove(student);
            }
        }
    }
}
