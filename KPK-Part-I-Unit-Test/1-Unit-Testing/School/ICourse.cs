
using System.Collections.Generic;

namespace School
{
    public interface ICourse
    {
        ICollection<Student> Students { get; set; }
        void Add(Student student);
        void Remove(Student student);
    }
}
