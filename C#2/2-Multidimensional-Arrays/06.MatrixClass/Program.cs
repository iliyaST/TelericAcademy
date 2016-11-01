
using System;
using System.Text;

public class Matrix
{
    private int[,] container;
    public int Rows { get; private set; }
    public int Cols { get; private set; }

    public Matrix(int rows, int cols)
    {
        this.container = new int[rows, cols];
        Rows = rows;
        Cols = cols;
    }

    public int this[int i, int j]
    {
        get
        {
            return container[i, j];
        }
        set
        {
            container[i, j] = value;
        }
    }

    public static Matrix operator +(Matrix A, Matrix B)
    {
        if (A.Rows != B.Rows && A.Cols != B.Cols)
        {
            throw new InvalidOperationException("Matrix dimension missmatch");
        }

        Matrix matrixSum = new Matrix(A.Rows, A.Cols);

        for (int i = 0; i < matrixSum.Rows; i++)
        {
            for (int j = 0; j < matrixSum.Cols; j++)
            {
                matrixSum[i, j] = A[i, j] + B[i, j];
            }
        }

        return matrixSum;
    }

    public static Matrix operator -(Matrix A, Matrix B)
    {
        if (A.Rows != B.Rows && A.Cols != B.Cols)
        {
            throw new InvalidOperationException("Matrix dimension missmatch");
        }

        Matrix matrixDifference = new Matrix(A.Rows, A.Cols);

        for (int i = 0; i < matrixDifference.Rows; i++)
        {
            for (int j = 0; j < matrixDifference.Cols; j++)
            {
                matrixDifference[i, j] = A[i, j] - B[i, j];
            }
        }

        return matrixDifference;
    }

    public static Matrix operator *(Matrix A, Matrix B)
    {
        if (A.Cols != B.Rows)
        {
            throw new InvalidOperationException("Matrix dimension missmatch");
        }

        Matrix matrixProduct = new Matrix(A.Rows, B.Cols);

        for (int rowA = 0; rowA < A.Rows; rowA++)
        {
            for (int colB = 0; colB < B.Cols; colB++)
            {
                for (int colA = 0; colA < A.Cols; colA++)
                {
                    matrixProduct[rowA, colB] += A[rowA, colA] * B[colA, colB];
                }
            }
        }

        return matrixProduct;
    }

    public override string ToString()
    {
        StringBuilder stringMatrix = new StringBuilder();

        for (int i = 0; i < container.GetLength(0); i++)
        {
            for (int j = 0; j < container.GetLength(1); j++)
            {
                stringMatrix.AppendFormat("{0, -4}", container[i, j]);
            }
            stringMatrix.AppendLine();
        }
        return stringMatrix.ToString();
    }

}
