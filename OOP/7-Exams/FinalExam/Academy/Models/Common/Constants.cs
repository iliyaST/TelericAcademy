using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Models.Common
{
    public class Constants
    {
        // String lengths
        public const int MinCourseNameLength = 3;
        public const int MaxCourseNameLength = 45;
        public const int MinTrainerNameLength = 3;
        public const int MaxTrainerNameLength = 16;
        public const int MinStudentNameLength = 3;
        public const int MaxStudentNameLength = 16;
        public const int MinLectureNameLength = 5;
        public const int MaxLectureNameLength = 30;
        public const int MinDemoResourseNamelength = 3;
        public const int MaxDemoResourseNameLength = 15;
        public const int MinDemoUrlNamelength = 5;
        public const int MaxDemoUrlNameLength = 150;

        // Numbers validation
        public const int MinNumberOfCourses = 1;
        public const int MaxNumberOfCourses = 7;
        public const int MinExamPoints = 0;
        public const int MaxExamPoints = 1000;
        public const int MinCoursePoints = 0;
        public const int MaxCoursePoints = 125;

        // Strings for validation
        public const string StringMustBeBetweenMinAndMax = "The name of the course must be between 3 and 45 symbols!";
        public const string NumberMustBeBetweenMinAndMax = "The number of lectures per week must be between 1 and 7!";
        public const string StringCannotBeNullOrEmpty = "{0} cannot be null or empty!";
        public const string UserNameLenghtMustBeBetweenMinAndMax = "User's username should be between 3 and 16 symbols long!";
        public const string CannotBeNull = "{0} cannot be null!";
        public const string ResultExamPointsMustBeBetweenMinAndMax = "Course result's exam points should be between 0 and 1000!";
        public const string CourseResultExamPointsMustBeBetweenMinAndMax = "Course result's exam points should be between 0 and 1000!";
        public const string LectureNameMustBeBetweenMinAndMax = "Lecture's name should be between 5 and 30 symbols long!";
        public const string ResourseMustBeBetweenMinAndMax = "Resource {0} should be between {1} and {2} symbols long!";

    }
}
