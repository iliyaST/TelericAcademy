namespace School.Models.Common
{
    public class Constants
    {
        // String lengths
        public const int MinNameLength = 2;
        public const int MaxNameLength = 31;

        // Numbers validation
        public const int MaxMarksCount = 20;
        public const int MaxGrade = 12;
        public const int MinGrade = 1;
        public const float MaxMarksValue = 6;
        public const float MinMarksValue = 2;

        // Strings for validation
        public const string StringMustBeBetweenMinAndMax = "The name of the course must be between 2 and 31 symbols!";
        public const string MarksCountMustBeLessThanTwenty = "Each teacher cannot have more than 20 marks!";
        public const string GradeMustBeBetweenMinAndMax = "Grade cannot be less than 1 and bigger than 12";
        public const string MarksValueShouldBeBetweenMinAndMax = "Marks value should be less than 6 and bigger than 2";
    }
}
