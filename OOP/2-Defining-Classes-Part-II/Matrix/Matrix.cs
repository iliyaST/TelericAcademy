using System;

namespace Matrix
{
    class Matrix<T> where T : IComparable
    {
        /// <summary>
        /// Field for matrix
        /// </summary>
        T[,] matrix;

        /// <summary>
        /// Find the lenght of the rows in the matrix
        /// </summary>
        /// <returns></returns>
        public int Rows
        {
            get
            {
                return matrix.GetLength(0);
            }
        }

        /// <summary>
        /// Find the lenght of the cols in the matrix
        /// </summary>
        /// <returns></returns>
        public int Cols
        {
            get
            {
                return matrix.GetLength(1);
            }
        }

        /// <summary>
        /// Define the matrix dimensions (create the matrix using constructor)
        /// </summary>
        /// <param name="rows">The rows of the matrix</param>
        /// <param name="cols">The cols of the matrix</param>
        public Matrix(int rows, int cols)
        {
            matrix = new T[rows, cols];
        }

        /// <summary>
        /// Indexator - make our matrix accsessible
        /// </summary>
        /// <param name="currentRow">Insert the row we want to look in...</param>
        /// <param name="currentCol">Insert the col we want to look in...</param>
        /// <returns></returns>
        public T this[int currentRow, int currentCol]
        {
            get
            {
                if ((currentRow < 0 && currentRow >= matrix.GetLength(0)) &&
                    (currentCol < 0 && currentCol >= matrix.GetLength(1)))
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    return matrix[currentRow, currentCol];
                }
            }
            set
            {
                if ((currentRow < 0 && currentRow >= matrix.GetLength(0)) &&
                    (currentCol < 0 && currentCol >= matrix.GetLength(1)))
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    matrix[currentRow, currentCol] = value;
                }
            }
        }

        /// <summary>
        /// Say what the + should do only if the matrices have same amount of rows and cols.
        /// </summary>
        /// <param name="firstMatrix"></param>
        /// <param name="secondMatrix"></param>
        /// <returns></returns>
        public static Matrix<T> operator +(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if (firstMatrix.matrix.GetLength(0) == secondMatrix.matrix.GetLength(0) &&
                firstMatrix.matrix.GetLength(1) == secondMatrix.matrix.GetLength(1))
            {
                Matrix<T> result = new Matrix<T>(firstMatrix.matrix.GetLength(0), firstMatrix.matrix.GetLength(1));

                for (int i = 0; i < firstMatrix.matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < firstMatrix.matrix.GetLength(1); j++)
                    {
                        result[i, j] = (dynamic)firstMatrix[i, j] + (dynamic)secondMatrix[i, j];
                    }
                }

                return result;
            }
            else
            {
                throw new ArgumentException("The matrices must be with same rows and cols!");
            }
        }


        /// <summary>
        ///  Substracting Matrices same as +
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static Matrix<T> operator -(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if (firstMatrix.matrix.GetLength(0) == secondMatrix.matrix.GetLength(0) &&
                firstMatrix.matrix.GetLength(1) == secondMatrix.matrix.GetLength(1))
            {
                Matrix<T> result = new Matrix<T>(firstMatrix.matrix.GetLength(0), firstMatrix.matrix.GetLength(1));

                for (int i = 0; i < firstMatrix.matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < firstMatrix.matrix.GetLength(1); j++)
                    {
                        result[i, j] = (dynamic)firstMatrix[i, j] - (dynamic)secondMatrix[i, j];
                    }
                }

                return result;
            }
            else
            {
                throw new ArgumentException("The matrices must be with same rows and cols!");
            }
        }

        public static Matrix<T> operator *(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if (firstMatrix.matrix.GetLength(1) != secondMatrix.matrix.GetLength(0))
            {
                throw new OperationCanceledException("Cannot multiply!");
            }
            else
            {
                Matrix<T> result = new Matrix<T>(firstMatrix.matrix.GetLength(0), secondMatrix.matrix.GetLength(1));

                for (int i = 0; i < result.matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < result.matrix.GetLength(1); j++)
                    {
                        for (int k = 0; k < firstMatrix.matrix.GetLength(1); k++)
                        {
                            result[i, j] += (dynamic)firstMatrix[i, k] * (dynamic)secondMatrix[k, j];
                        }
                    }
                }

                return result;
            }
        }

        /// <summary>
        ///  Check for non-zero elements (if there is a zero element or not ????!!)
        /// </summary>
        /// <param name="someMatrix"></param>
        /// <returns>Returns false if there is a zero element and true if there isnt</returns>
        public static bool operator true(Matrix<T> someMatrix)
        {
            bool isNonZero = true;

            for (int i = 0; i < someMatrix.matrix.GetLength(0); i++)
            {
                for (int j = 0; j < someMatrix.matrix.GetLength(1); j++)
                {
                    if ((dynamic)someMatrix[i, j] == 0)
                    {
                        isNonZero = false;
                    }
                }
            }

            return isNonZero;
        }

        /// <summary>
        /// Watch the lecture of IvayloKenov 2015.......True and False
        /// </summary>
        /// <param name="someMatrix"></param>
        /// <returns></returns>
        public static bool operator false(Matrix<T> someMatrix)
        {
            bool isNonZero = true;

            for (int i = 0; i < someMatrix.matrix.GetLength(0); i++)
            {
                for (int j = 0; j < someMatrix.matrix.GetLength(1); j++)
                {
                    if ((dynamic)someMatrix[i, j] == 0)
                    {
                        isNonZero = false;
                    }
                }
            }

            return isNonZero;
        }
    }
}

