namespace SchoolSystem.CLI.Models.Contracts
{
    using SchoolSystem.CLI.Models.Enums;

    /// <summary>
    /// Represents a Teacher and extends Person,has Subject and has the abillity to add marks to a current student
    /// </summary>
    public interface ITeacher : IPerson
    {
        Subject Subject { get; set; }

        /// <summary>
        /// Add mark in the specific subject to a current student with current value
        /// </summary>
        void AddMark(IStudent student, float value);
    }
}
