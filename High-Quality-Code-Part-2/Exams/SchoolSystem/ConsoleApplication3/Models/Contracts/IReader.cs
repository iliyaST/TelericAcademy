namespace School.Models.Contracts
{
    public interface IReader
    {
        /// <summary>
        /// This method describes reading fromd the console.
        /// </summary>
        /// <returns>Console readline provider.</returns>
        string ReadLine();
    }
}