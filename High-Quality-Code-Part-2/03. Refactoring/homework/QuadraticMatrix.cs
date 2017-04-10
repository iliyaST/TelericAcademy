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
            { // malko e kofti tova uslovie, no break-a raboti 100% : )   

                // We start filling the matrix from the top left corner so there the value is 1
                this.Body[currentRow, currentCol] = initialValue;

                if (MatrixActions.CheckIfMatrixIsFull(this.Body, currentRow, currentCol))
                {
                    break;
                } // prekusvame ako sme se zadunili

                if (currentRow + directionPositionX >= matrixLength || currentRow + directionPositionX < 0 ||
                    currentCol + directionPositionY >= matrixLength || currentCol + directionPositionY < 0 ||
                    this.Body[currentRow + directionPositionX, currentCol + directionPositionY] != 0)
                {
                    while (currentRow + directionPositionX >= matrixLength || currentRow + directionPositionX < 0 ||
                        currentCol + directionPositionY >= matrixLength || currentCol + directionPositionY < 0 ||
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
            { // taka go napravih, zashtoto funkciqta ne mi davashe da ne si definiram out parametrite
                directionPositionX = 1;
                directionPositionY = 1;

                while (true)
                {
                    // malko e kofti tova uslovie, no break-a raboti 100% : )
                    this.Body[currentRow, currentCol] = initialValue;

                    if (MatrixActions.CheckIfMatrixIsFull(this.Body, currentRow, currentCol))
                    {
                        break;
                    }

                    // prekusvame ako sme se zadunili
                    if (currentRow + directionPositionX >= matrixLength || currentRow + directionPositionX < 0 ||
                        currentCol + directionPositionY >= matrixLength || currentCol + directionPositionY < 0 ||
                        this.Body[currentRow + directionPositionX, currentCol + directionPositionY] != 0)
                    {
                        while (currentRow + directionPositionX >= matrixLength || currentRow + directionPositionX < 0 ||
                            currentCol + directionPositionY >= matrixLength || currentCol + directionPositionY < 0 ||
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
    }
}
