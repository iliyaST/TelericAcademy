using System;

public class SimpleMathExam : Exam
{
    private int problemsSolved;

    public SimpleMathExam(int problemsSolved)
    {
        this.ProblemsSolved = problemsSolved;
    }

    public int ProblemsSolved
    {
        get
        {
            return this.problemsSolved;
        }

        private set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Problems solved cannot be less than 0!");
            }

            if (value > 10)
            {
                throw new ArgumentOutOfRangeException("Problems solved cannot be more than the total problems count!");
            }

            this.problemsSolved = value;
        }
    }

    public override ExamResult Check()
    {
        if (this.ProblemsSolved <= 3)
        {
            return new ExamResult(2, 2, 6, "Bad result: nothing done.");
        }
        else if (this.ProblemsSolved >= 4 && this.ProblemsSolved <= 7)
        {
            return new ExamResult(4, 2, 6, "Average result: good work.");
        }
        else if (this.ProblemsSolved >= 7)
        {
            return new ExamResult(6, 2, 6, "Excellent result: great work!");
        }

        throw new ArgumentException("Invalid number of problems solved!");
    }
}
