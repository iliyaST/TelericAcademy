namespace Task_2_Refactor
{
    using System;
    using Homework;

    public class Refactoring
    {
        public void CookPotatoRefactoringCode()
        {
            var potato = new Potato();

            if (potato != null)
            {
                if (potato != null && potato.HasBeenPeeled && potato.IsHealthy)
                {
                    this.Cook(potato);
                }
            }
        }

        public void CheckIfCellMustBeVisited()
        {
            int x = 0;
            int y = 0;
            int minimumX = 0;
            int maximumX = 0;
            int minimumY = 0;
            int maximumY = 0;
            bool shouldVisitCell = true;

            bool isValidX = minimumX <= x && x <= maximumX;
            bool isValidY = minimumY <= y && y <= maximumY;

            if (shouldVisitCell && isValidX && isValidY)
            {
                this.VisitCell();
            }
        }

        public void RefactorCode()
        {
            int expectedValue = 23;
            int[] arrayOfIntegers = new int[100];
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(arrayOfIntegers[i]);

                if (i % 10 == 0 && (arrayOfIntegers[i] == expectedValue))
                {
                    Console.WriteLine("Value Found");
                    break;
                }
            }
        }

        private void VisitCell()
        {
            throw new NotImplementedException();
        }

        private void Cook(Vegetable potato)
        {
            throw new NotImplementedException();
        }
    }
}