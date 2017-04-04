using Exceptions_Homework.Exeptions;
using Exceptions_HomeworkExeptions;
using System;

public class ExamResult
{
    private int grade;
    private int minGrade;
    private int maxGrade;
    private string comments;

    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {

        if (comments == null || comments == "")
        {
            throw new Exception();
        }

        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }

    public int Grade
    {
        get
        {
            return this.grade;
        }
        private set
        {
            if (value < 0)
            {
                throw new InvalidGradeExeption("Grade must be positive!");
            }

            this.grade = value;
        }
    }

    public int MinGrade
    {
        get
        {
            return this.maxGrade;
        }
        private set
        {
            if (value < 0)
            {
                throw new InvalidGradeExeption("Min grade must be positive!");
            }

            this.minGrade = value;
        }
    }

    public int MaxGrade
    {
        get
        {
            return this.maxGrade;
        }
        private set
        {
            if (value <= minGrade)
            {
                throw new InvalidGradeExeption("Max grade must be bigger than the min!");
            }

            this.maxGrade = value;
        }
    }

    public string Comments
    {
        get
        {
            return this.comments;
        }
        private set
        {
            if (value == null || value == "")
            {
                throw new ArgumentNullException("Comments cannot be null or empty!");
            }

            this.comments = value;
        }
    }
}
