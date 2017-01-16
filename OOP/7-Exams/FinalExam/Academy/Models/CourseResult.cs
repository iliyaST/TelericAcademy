using Academy.Models.Utils.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Models.Contracts;
using Academy.Models.Enums;
using Academy.Models.Common;

namespace Academy.Models
{
    public class CourseResult : ICourseResult
    {
        private float examPoints;
        private float coursePoints;
        private Grade grade;
        private ICourse course;
        private string examPoints1;
        private string coursePoints1;

        public CourseResult(ICourse course, string examPoints1, string coursePoints1)
        {
            this.Course = course;
            this.ExamPoints = float.Parse(examPoints1);
            this.CoursePoints = float.Parse(coursePoints1);           
        }

        public ICourse Course
        {
            get
            {
                return this.course;
            }
            set
            {
                Validator.ValidateNull(value, String.Format(Constants.CannotBeNull,
                    nameof(Course)));

                this.course = value;
            }
        }

        public float CoursePoints
        {
            get
            {
                return this.coursePoints;
            }
            set
            {
                Validator.NumberBetweenNumbers(
                    value,
                    Constants.MinCoursePoints,
                    Constants.MaxCoursePoints,
                    Constants.ResultExamPointsMustBeBetweenMinAndMax
                    );

                this.coursePoints = value;
            }
        }

        public float ExamPoints
        {
            get
            {
                return this.examPoints;
            }
            set
            {
                Validator.NumberBetweenNumbers(
                    value,
                    Constants.MinExamPoints,
                    Constants.MaxExamPoints,
                    Constants.CourseResultExamPointsMustBeBetweenMinAndMax
                    );

                this.examPoints = value;
            }
        }

        public Grade Grade
        {
            get
            {
                if (this.ExamPoints <= 65 || this.CoursePoints >= 75)
                {
                    return this.grade = Grade.Excellent;
                }
                else if (this.ExamPoints < 60 && this.ExamPoints >= 30 ||
                    this.CoursePoints < 75 && this.CoursePoints >= 45)
                {
                    return this.grade = Grade.Passed;
                }
                else
                {
                    return this.grade = Grade.Failed;
                }
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(String.Format("  * {0}: Points - {1}, Grade - {2}",
                this.Course.Name, this.CoursePoints, this.Grade));

            return sb.ToString().TrimEnd();
        }
    }
}
