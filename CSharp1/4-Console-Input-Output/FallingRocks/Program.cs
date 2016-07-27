using System;
using System.Collections.Generic;
using System.Threading;

class FallingRocks
{
    struct Object
    {
        public int x;
        public int y;
        public string c;
        public ConsoleColor color;
    }
    static void drawOnPosition(int x, int y, String c, ConsoleColor color = ConsoleColor.Magenta)
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;
        Console.WriteLine(c);
    }

    static void Main()
    {       
        Object userSpaceShit = new Object();
        userSpaceShit.x = 7;
        userSpaceShit.y = 20;
        userSpaceShit.c = "0";
        userSpaceShit.color = ConsoleColor.White;
        Console.BufferHeight = Console.WindowHeight = 30;
        Console.BufferWidth = Console.WindowWidth = 33;
        Random rand = new Random();
        List<Object> rocks = new List<Object>();
        int lifesCount = 5;
        double acc = 0;
        int i = 0;
        while (true)
        {
            bool life = false;
            bool word = false;
            bool colision = false;
            int chance = rand.Next(0, 100);
            if (chance < 2)
            {
                Object rock = new Object();
                rock.color = ConsoleColor.White;
                rock.c = "B";
                rock.x = rand.Next(0, 14);
                rock.y = 0;
                rocks.Add(rock);
            }
            if (chance < 4)
            {
                Object rock = new Object();
                rock.color = ConsoleColor.White;
                rock.c = "+";
                rock.x = rand.Next(0, 14);
                rock.y = 0;
                rocks.Add(rock);
            }

            if (chance < 19)
            {
                Object rock = new Object();
                rock.color = ConsoleColor.DarkYellow;
                rock.c = "!";
                rock.x = rand.Next(0, 14);
                rock.y = 0;
                rocks.Add(rock);
            }
            if (chance < 24)
            {
                Object rock = new Object();
                rock.color = ConsoleColor.Red;
                rock.c = "#";
                rock.x = rand.Next(0, 14);
                rock.y = 0;
                rocks.Add(rock);
            }
            if (chance < 26)
            {
                Object rock = new Object();
                rock.color = ConsoleColor.Blue;
                rock.c = "@";
                rock.x = rand.Next(0, 14);
                rock.y = 0;
                rocks.Add(rock);
            }
            if (chance < 28)
            {
                Object rock = new Object();
                rock.color = ConsoleColor.DarkYellow;
                rock.c = "$";
                rock.x = rand.Next(0, 14);
                rock.y = 0;
                rocks.Add(rock);
            }
            while (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                {
                    if (pressedKey.Key == ConsoleKey.LeftArrow)
                    {
                        if (userSpaceShit.x - 1 >= 0)
                        {
                            userSpaceShit.x = userSpaceShit.x - 1;
                        }
                    }
                    if (pressedKey.Key == ConsoleKey.RightArrow)
                    {
                        if (userSpaceShit.x + 1 <= 13)
                        {
                            userSpaceShit.x = userSpaceShit.x + 1;
                        }
                    }
                }
            }
            List<Object> newList = new List<Object>();
            for (int j = 0; j < rocks.Count; j++)
            {
                Object oldRock = rocks[j];
                Object newRock = new Object();
                newRock.x = oldRock.x;
                newRock.y = oldRock.y + 1;
                newRock.c = oldRock.c;
                newRock.color = oldRock.color;
                if (newRock.c == "@" && newRock.x == userSpaceShit.x && newRock.y == userSpaceShit.y)
                {
                    colision = true;
                    lifesCount--;
                }
                if (newRock.c == "*" && newRock.x == userSpaceShit.x && newRock.y == userSpaceShit.y)
                {
                    colision = true;
                    lifesCount--;
                }
                if (newRock.c == "$" && newRock.x == userSpaceShit.x && newRock.y == userSpaceShit.y)
                {
                    colision = true;
                    lifesCount--;
                }
                if (newRock.c == "#" && newRock.x == userSpaceShit.x && newRock.y == userSpaceShit.y)
                {
                    colision = true;
                    lifesCount--;
                }
                if (newRock.c == "!" && newRock.x == userSpaceShit.x && newRock.y == userSpaceShit.y)
                {
                    colision = true;
                    lifesCount--;
                }
                if (newRock.c == "+" && newRock.x == userSpaceShit.x && newRock.y == userSpaceShit.y)
                {
                    life = true;
                    lifesCount++;
                }
                if (newRock.c == "B" && newRock.x == userSpaceShit.x && newRock.y == userSpaceShit.y)
                {
                    word = true;
                    i++;
                }
                if (newRock.y < 30)
                {
                    newList.Add(newRock);
                }
            }
            rocks = newList;
            Console.Clear();
            foreach (var item in rocks)
            {
                drawOnPosition(item.x, item.y, item.c, item.color);
            }
            if (colision == true)
            {
                drawOnPosition(userSpaceShit.x, userSpaceShit.y, "X", ConsoleColor.Red);
                newList.Clear();
                acc += 20;
            }
            else
            {
                if (life == true)
                {
                    drawOnPosition(userSpaceShit.x, userSpaceShit.y, "1", ConsoleColor.Yellow);
                }
                else
                {
                    if (word == true)
                    {
                        drawOnPosition(userSpaceShit.x, userSpaceShit.y, "W", ConsoleColor.White);
                    }
                    else
                    {
                        drawOnPosition(userSpaceShit.x, userSpaceShit.y, userSpaceShit.c, ConsoleColor.White);
                    }
                }
            }           
            if (lifesCount == 0)
            {
                drawOnPosition(15, 16, "YOU LOOSE!", ConsoleColor.Red);               
                Environment.Exit(0);
            }
            drawOnPosition(15, 3, "Collect letter 'B'", ConsoleColor.Green);
            drawOnPosition(15, 5, "Make the Word" , ConsoleColor.Yellow);
            drawOnPosition(15, 6, "'WIN' to win !" , ConsoleColor.Yellow);
            drawOnPosition(15, 10, "Lives:" + lifesCount, ConsoleColor.White);         
            drawOnPosition(15, 11, "Acceleration:" + (int)acc, ConsoleColor.White);
            if (i == 0)
            {
                drawOnPosition(15, 15, "_ _ _", ConsoleColor.White);
            }
            if (i == 1)
            {
                drawOnPosition(15, 15, "W _ _", ConsoleColor.White);
            }
            if (i == 2)
            {
                drawOnPosition(15, 15, "W I _", ConsoleColor.White);
            }
            if (i == 3)
            {
                drawOnPosition(15, 15, "W I N", ConsoleColor.White);
            }
            if (i == 3)
            {
                drawOnPosition(15, 16, "YOU WIN!", ConsoleColor.Magenta);              
                Environment.Exit(0);
            }
            acc += 0.1;
            if (acc > 100)
            {
                acc = 100;
            }
            Thread.Sleep((int)(200 - acc));
        }

    }
}