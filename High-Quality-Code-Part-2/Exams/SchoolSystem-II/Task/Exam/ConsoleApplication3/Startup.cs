namespace SchoolSystem.CLI
{
    using SchoolSystem.CLI.Core;

    public class Startup
    {
        public static void Main()
        {
            var engine = Engine.Instance;
            engine.Start();
        }
    }
}
