
namespace PersonClass
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class Test
    {
        public static void Main()
        {
            Person pesho = new Person("Pesho");
            Console.WriteLine(pesho);
            Person gosho = new Person("Gosho", 11);
            Console.WriteLine(gosho);
        }
    }
}
