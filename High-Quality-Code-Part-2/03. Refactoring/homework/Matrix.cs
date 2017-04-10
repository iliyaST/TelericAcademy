namespace MatrixCreation
{
    using System;

    public class Matrix
    {
        private int rows;
        private int cols;

        public Matrix(int rows, int cols)
        {
            this.Rows = rows;
            this.Cols = cols;
        }

        protected int Rows
        {
            get
            {
                return this.rows;
            }

            set
            {
                if (value <= 0 || value >= 100)
                {
                    throw new ArgumentException("Invalid dimensions!");
                }

                this.rows = value;
            }
        }

        protected int Cols
        {
            get
            {
                return this.cols;
            }

            set
            {
                if (value <= 0 || value >= 100)
                {
                    throw new ArgumentException("Invalid dimensions!");
                }

                this.cols = value;
            }
        }

        public int[,] Body { get; set; }

        public virtual void FillMatrix()
        {
            throw new NotImplementedException();
        }
    }
}
