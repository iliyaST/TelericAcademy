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
                   directionRow = 1,
                   directionCol = 1;

            while (true)
            {
                // We start filling the matrix from the top left corner so there the value is 1
                this.Body[currentRow, currentCol] = initialValue;

                if (!MatrixActions.CheckIfThereIsAPossibleCellToMove(this.Body, currentRow, currentCol))
                {
                    MatrixActions.FindTheFirstPossibleEmptyCell(this.Body, out currentRow, out currentCol);

                    if (currentRow != 0 && currentCol != 0)
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }

                // Change direction untill empty cell that is inside matrix is found
                while (CheckIfNextCellIsOutsideOfMatrix(currentRow, currentCol, directionRow, directionCol) ||
                    this.Body[currentRow + directionRow, currentCol + directionCol] != 0)
                {
                    MatrixActions.ChangeDirection(ref directionRow, ref directionCol);
                }

                // Change direction when possible cell is found
                currentRow += directionRow;
                currentCol += directionCol;
                initialValue++;
            }
        }

        public bool CheckIfNextCellIsOutsideOfMatrix(int currentRow, int currentCol, int directionRow, int directionCol)
        {
            if (currentRow + directionRow >= this.Body.GetLength(0) || currentRow + directionRow < 0 ||
                currentCol + directionCol >= this.Body.GetLength(0) || currentCol + directionCol < 0)
            {
                return true;
            }

            return false;
        }
    }
}
