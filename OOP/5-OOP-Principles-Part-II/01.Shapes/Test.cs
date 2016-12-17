
namespace Shapes
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
            List<Shape> shapes = new List<Shape>
        {
            new Triangle(5,7),
            new Rectangle(10,10),
            new Square(5)
        };

            foreach (var shape in shapes)
            {
                var tempSurfice = shape.CalculateSurface();
                Console.WriteLine("{0} instance has surface equal to {1}", shape.GetType(), shape.CalculateSurface());
            }
        }
    }
}
