using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    struct Object
    {
        public int x;
        public int y;
        public string c;
        public ConsoleColor color;

    }
    static void printOnPosition(int x, int y, string c, ConsoleColor color = ConsoleColor.Gray)
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;
        Console.Write(c);
    }

    static void Main()
    {
        Console.BufferHeight = Console.WindowHeight = 30;
        Console.BufferWidth = Console.WindowWidth = 30;
        double speed = 100.0;
        double acc = 0.5;
        int position = 5;
        int livesCount = 5;
        Object userCar = new Object();
        userCar.x = 2;
        userCar.y = 29;
        userCar.c = "@";
        userCar.color = ConsoleColor.Yellow;
        Random rand = new Random();
        List<Object> objects = new List<Object>();
        while (true)
        {
            bool hitted = false;
            int chance = rand.Next(0, 100);
            if (chance < 10)
            {
                Object newObject = new Object();
                newObject.color = ConsoleColor.White;
                newObject.c = "+";
                newObject.x = rand.Next(1, position + 1);
                newObject.y = 0;
                objects.Add(newObject);
            }
            if (chance <= 20)
            {
                Object newObject = new Object();
                newObject.color = ConsoleColor.Cyan;
                newObject.c = "!";
                newObject.x = rand.Next(1, position + 1);
                newObject.y = 0;
                objects.Add(newObject);
            }
            else
            {
                speed += acc;
                if (speed > 500)
                {
                    speed = 500;
                }
                {
                    Object newCar = new Object();
                    newCar.color = ConsoleColor.Green;
                    newCar.x = rand.Next(0, position + 1);
                    newCar.y = 0;
                    newCar.c = "#";
                    objects.Add(newCar);                   
                }
            }
            while (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressedkey = Console.ReadKey(true);
                {
                    if (pressedkey.Key == ConsoleKey.LeftArrow)
                    {
                        if (userCar.x - 1 >= 0)
                        {
                            userCar.x = userCar.x - 1;
                        }
                    }
                    else if (pressedkey.Key == ConsoleKey.RightArrow)
                    {
                        if (userCar.x < position)
                        {
                            userCar.x = userCar.x + 1;
                        }
                    }
                }
            }
            List<Object> newList = new List<Object>();
            for (int i = 0; i < objects.Count; i++)
            {
                Object oldCar = objects[i];
                Object newObject = new Object();
                newObject.x = oldCar.x;
                newObject.y = oldCar.y + 1;
                newObject.c = oldCar.c;
                newObject.color = oldCar.color;
                if (newObject.c == "+" && newObject.x == userCar.x && newObject.y == userCar.y)
                {
                    livesCount++;
                }
                if (newObject.c == "!" && newObject.x == userCar.x && newObject.y == userCar.y)
                {
                    speed -= 20;
                }
                if (newObject.c == "#" && newObject.x == userCar.x && newObject.y == userCar.y)
                {
                    hitted = true;
                    livesCount--;
                    speed += 50;
                    if (speed > 500)
                    {
                        speed = 500;
                    }
                    if (livesCount <= 0)
                    {
                        printOnPosition(8, 7, "GAME OVER!", ConsoleColor.Red);
                        printOnPosition(8, 12, "Press [enter] to Exit:", ConsoleColor.Red);
                        Environment.Exit(0);
                    }
                }
                if (newObject.y < 30)
                {
                    newList.Add(newObject);
                }
            }
            objects = newList;
            Console.Clear();
            foreach (var car in objects)
            {
                printOnPosition(car.x, car.y, car.c, car.color);
            }
            if (hitted == true)
            {
                objects.Clear();
                printOnPosition(userCar.x, userCar.y, "X", ConsoleColor.Red);
            }
            else
            {
                printOnPosition(userCar.x, userCar.y, userCar.c, userCar.color);
            }
            printOnPosition(8, 4, "Lives: " + livesCount, ConsoleColor.White);
            printOnPosition(8, 5, "Speed: " + speed, ConsoleColor.White);
            printOnPosition(8, 6, "Acceleration: " + acc, ConsoleColor.White);
            Thread.Sleep((int)(600 - speed));
        }
    }
}