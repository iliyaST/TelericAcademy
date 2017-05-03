namespace SchoolSystem.CLI.Models.Contracts
{
    using SchoolSystem.CLI.Models.Enums;

    public interface IMark
    {
        float Value { get; set; }

        Subject Subject { get; set; }
    }
}