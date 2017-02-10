
namespace SomeTest
{
    public class Class1
    {
        bool isCalled = false;

        public void Log(string message)
        {
            this.isCalled = true;         
        }
    }

    public class ClassTest
    {
        public void SomeMethod()
        {
            var logger = new Class1();
        }
    }
}
