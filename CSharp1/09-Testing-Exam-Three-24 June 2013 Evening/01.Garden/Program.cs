using System;

class Garden
{
    static void Main()
    {
        double tomatoCost = double.Parse(Console.ReadLine());
        int tomatoArea = int.Parse(Console.ReadLine());
        double cacumberCost = double.Parse(Console.ReadLine());
        int cacumberArea = int.Parse(Console.ReadLine());
        double potatoCost = double.Parse(Console.ReadLine());
        int potatoArea = int.Parse(Console.ReadLine());
        double carrotCost = double.Parse(Console.ReadLine());
        int carrotArea = int.Parse(Console.ReadLine());
        double cabbageCost = double.Parse(Console.ReadLine());
        int cabbageArea = int.Parse(Console.ReadLine());
        double beansCost = double.Parse(Console.ReadLine());
        //tomato, cucumber, potato, carrot, cabbage, beans. 
        //        //0.5$ per seed		carrot	0.6$ per seed
        //        0.4$ per seed       cabbage 0.3$ per seed
        //0.25$ per seed      beans   0.4$ per seed

        double totalCost = (tomatoCost * 0.5) + (cacumberCost * 0.4) + (potatoCost * 0.25) + (carrotCost * 0.6)
           + (cabbageCost * 0.3) + (beansCost * 0.4);
        int totalArea = 250;
        int AreaByAllPlantsWithoutBeans = (tomatoArea + cacumberArea + potatoArea + carrotArea + cabbageArea);


        Console.WriteLine("Total costs: {0:F2}", totalCost);
        if (totalArea - AreaByAllPlantsWithoutBeans > 0)
        {
            Console.WriteLine("Beans area: {0}", totalArea - AreaByAllPlantsWithoutBeans);
        }
        if (totalArea - AreaByAllPlantsWithoutBeans == 0)
        {
            Console.WriteLine("No area for beans");
        }
        if (totalArea - AreaByAllPlantsWithoutBeans < 0)
        {
            Console.WriteLine("Insufficient area");
        }        
    }
}

