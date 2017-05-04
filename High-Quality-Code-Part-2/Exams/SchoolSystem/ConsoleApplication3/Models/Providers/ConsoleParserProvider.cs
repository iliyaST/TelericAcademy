namespace ConsoleApplication3.Models.Providers
{
    using Contracts;

    public class ConsoleParserProvider : IParser
    {
        // public void ProcessCommand()
        // {
        //    var orderName = command.Split(' ')[0];
        //    var assembly = this.GetType().GetTypeInfo().Assembly;
        //    var infoType = assembly.DefinedTypes
        //        .Where(type => type.ImplementedInterfaces.Any(inter => inter == typeof(ICommand)))
        //        .Where(type => type.Name.ToLower().Contains(orderName.ToLower()))
        //        .FirstOrDefault();

        // if (infoType == null)
        //    {
        //        throw new ArgumentException("The passed command is not found!");
        //    }
        // }
    }
}
