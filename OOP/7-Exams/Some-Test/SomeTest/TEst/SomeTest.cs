namespace SomeTest
{
    public class Class1
    {
        public bool isCalled { get; set; }

        public void Log(string message)
        {
            this.isCalled = true;
        }
    }

    public static class ClassTest
    {
        public static bool hm { get; set; }

        public static void SomeMethod()
        {
            var logger = new Class1();
            logger.Log("aaff");
            hm = logger.isCalled;
        }
    }
}