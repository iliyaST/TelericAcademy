namespace QuadraticMatrixCreation
{
    using MatrixActions;
    using MatrixCreation;

    public class QadraticMatrix : Matrix
    {
        public QadraticMatrix(int dimensions)
            : base(dimensions, dimensions)
        {
            this.Body = new int[dimensions, dimensions];
        }

        public override void FillMatrixRotatingWalkStyle()
        {
            int matrixLength = this.Body.GetLength(0),
                   initialValue = 1,
                   currentRow = 0,
                   currentCol = 0,
                   directionPositionX = 1,
                   directionPositionY = 1;

            while (true)
            {
                // We start filling the matrix from the top left corner so there the value is 1
                this.Body[currentRow, currentCol] = initialValue;

                if (MatrixActions.CheckIfMatrixIsFull(this.Body, currentRow, currentCol))
                {
                    break;
                }

                if (CheckIfCellIsInsideOfMatrix(currentRow, currentCol, directionPositionX, directionPositionY) ||
                    this.Body[currentRow + directionPositionX, currentCol + directionPositionY] != 0)
                {
                    while (CheckIfCellIsInsideOfMatrix(currentRow, currentCol, directionPositionX, directionPositionY) ||
                        this.Body[currentRow + directionPositionX, currentCol + directionPositionY] != 0)
                    {
                        MatrixActions.ChangeDirection(ref directionPositionX, ref directionPositionY);
                    }
                }

                currentRow += directionPositionX;
                currentCol += directionPositionY;
                initialValue++;
            }

            MatrixActions.FindClosestEmptyCell(this.Body, out currentRow, out currentCol);

            if (currentRow != 0 && currentCol != 0)
            {
                directionPositionX = 1;
                directionPositionY = 1;

                while (true)
                {
                    this.Body[currentRow, currentCol] = initialValue;

                    if (MatrixActions.CheckIfMatrixIsFull(this.Body, currentRow, currentCol))
                    {
                        break;
                    }

                    if (CheckIfCellIsInsideOfMatrix(currentRow, currentCol, directionPositionX, directionPositionY) ||
                        this.Body[currentRow + directionPositionX, currentCol + directionPositionY] != 0)
                    {
                        while (CheckIfCellIsInsideOfMatrix(currentRow, currentCol, directionPositionX, directionPositionY) ||
                            this.Body[currentRow + directionPositionX, currentCol + directionPositionY] != 0)
                        {
                            MatrixActions.ChangeDirection(ref directionPositionX, ref directionPositionY);
                        }
                    }

                    currentRow += directionPositionX;
                    currentCol += directionPositionY;
                    initialValue++;
                }
            }
        }

        public bool CheckIfCellIsInsideOfMatrix(int currentRow, int currentCol, int directionPositionX, int directionPositionY)
        {
            if (currentRow + directionPositionX >= this.Body.GetLength(0))
            {
                return true;
            }

            if (currentRow + directionPositionX < 0)
            {
                return true;
            }

            if (currentCol + directionPositionY >= this.Body.GetLength(0))
            {
                return true;
            }

            if (currentCol + directionPositionY < 0)
            {
                return true;
            }

            return false;
        }
    }
}
