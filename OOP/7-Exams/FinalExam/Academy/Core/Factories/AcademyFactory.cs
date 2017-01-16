using Academy.Core.Contracts;
using Academy.Core.Providers;
using Academy.Models;
using Academy.Models.Common;
using Academy.Models.Contracts;
using Academy.Models.Enums;
using Academy.Models.Utils.Contracts;
using System;

namespace Academy.Core.Factories
{
    public class AcademyFactory : IAcademyFactory
    {
        private static IAcademyFactory instanceHolder = new AcademyFactory();

        // private because of Singleton design pattern
        private AcademyFactory()
        {
        }

        public static IAcademyFactory Instance
        {
            get
            {
                return instanceHolder;
            }
        }

        public ISeason CreateSeason(string startingYear, string endingYear, string initiative)
        {
            var parsedStartingYear = int.Parse(startingYear);
            var parsedEngingYear = int.Parse(endingYear);

            Initiative parsedInitiativeAsEnum;
            Enum.TryParse<Initiative>(initiative, out parsedInitiativeAsEnum);

            return new Season(parsedStartingYear, parsedEngingYear, parsedInitiativeAsEnum);
        }

        public IStudent CreateStudent(string username, string track)
        {
            IStudent student = new Student(username, track);

            Validator.ValidateNull(student, String.Format(Constants.CannotBeNull, nameof(Student)));

            return student;
        }

        public ITrainer CreateTrainer(string username, string technologies)
        {
            ITrainer trainer = new Trainer(username, technologies);

            Validator.ValidateNull(trainer, String.Format(Constants.CannotBeNull, nameof(Trainer)));

            return trainer;
        }

        public ICourse CreateCourse(string name, string lecturesPerWeek, string startingDate)
        {
            ICourse course = new Course(name, lecturesPerWeek, startingDate);

            Validator.ValidateNull(course, String.Format(Constants.CannotBeNull, nameof(Trainer)));

            return course;
        }

        public ILecture CreateLecture(string name, string date, ITrainer trainer)
        {
            ILecture lecture = new Lecture(name, date, trainer);

            Validator.ValidateNull(lecture, String.Format(Constants.CannotBeNull, nameof(Lecture)));

            return lecture;
        }

        public ILectureResouce CreateLectureResouce(string type, string name, string url)
        {
            // Use this instead of DateTime.Now if you want any points in BGCoder!!
            var currentDate = DateTimeProvider.Now;

            ILectureResouce resourse = null;

            switch (type)
            {
                case "video":
                    resourse = new VideoResource(ResourseType.Video, name, url);
                    break;
                case "presentation":
                    resourse = new PresentationResource(ResourseType.Presentation, name, url);
                    break;
                case "demo":
                    resourse = new DemoResource(ResourseType.Demo, name, url);
                    break;
                case "homework":
                    resourse = new HomeworkResource(ResourseType.Homework, name, url);
                    break;
                default: throw new ArgumentException("Invalid lecture resource type");
            }

            Validator.ValidateNull(resourse, Constants.CannotBeNull);

            return resourse;
        }

        public ICourseResult CreateCourseResult(ICourse course, string examPoints, string coursePoints)
        {
            ICourseResult courseResult = new CourseResult(course,examPoints,coursePoints);

            Validator.ValidateNull(courseResult, String.Format(Constants.CannotBeNull
                , nameof(CourseResult)));

            return courseResult;
        }
    }
}
