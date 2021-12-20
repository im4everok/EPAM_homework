using System;

namespace MatrixLibrary
{
    public class MatrixException : ArgumentNullException
    {
        public MatrixException()
        {

        }
        public MatrixException(string msg) : base(msg) { }
    }

    public class Matrix : ICloneable
    {
        private double[,] array;
        private readonly int rows;
        private readonly int columns;

        public int Rows
        {
            get => rows;
        }

        public int Columns
        {
            get => columns;
        }

        public double[,] Array
        {
            get => array;
        }

        public Matrix(int rows, int columns)
        {
            try
            {
                if (rows < 1 || columns < 1)
                {
                    throw new ArgumentOutOfRangeException("rows");
                }
                this.rows = rows;
                this.columns = columns;
                array = new double[rows, columns];
                this.rows = rows;
                this.columns = columns;
                array = new double[rows, columns];
            }
            catch (ArgumentOutOfRangeException)
            {
                throw;
            }
        }

        public Matrix(double[,] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }
            rows = array.GetLength(0);
            columns = array.GetLength(1);

            this.array = new double[Rows, Columns];
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    this.array[i, j] = array[i, j];
                }
            }
        }

        public double this[int row, int column]
        {
            get
            {
                if (row < Rows && column < Columns && row >= 0 && column >= 0)
                {
                    return Array[row, column];
                }
                else
                {
                    throw new ArgumentException("Row or column doesnt exit or is less than 0");
                }
            }

            set
            {
                if (Array != null)
                {
                    if (row < array.GetLength(0) && column < array.GetLength(1) && row >= 0 && column >= 0)
                        array[row, column] = value;
                    else
                    {
                        throw new ArgumentException("Row or column passed are bigger than length of array or less than 0");
                    }
                }
                else
                {
                    array = new double[row + 1, column + 1];
                    array[row, column] = value;
                }
            }
        }

        public object Clone()
        {
            return MemberwiseClone();
        }

        public static Matrix operator +(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1 == null || matrix2 == null)
            {
                throw new ArgumentNullException("matrix1");
            }
            if (matrix1.Rows != matrix2.Rows || matrix1.Columns != matrix2.Columns || matrix1.Rows < 1 || matrix2.Rows < 1 || matrix2.Columns < 1 || matrix2.Columns < 1)
            {
                throw new MatrixException();
            }
            Matrix newM = new Matrix(matrix1.Rows, matrix1.Columns);
            for (int i = 0; i < matrix1.Rows; i++)
            {
                for (int j = 0; j < matrix1.Columns; j++)
                {
                    newM[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }
            return newM;
        }

        public static Matrix operator -(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1 == null || matrix2 == null)
            {
                throw new ArgumentNullException("matrix1");
            }
            if (matrix1.Rows != matrix2.Rows || matrix1.Columns != matrix2.Columns || matrix1.Rows < 1 || matrix2.Rows < 1 || matrix2.Columns < 1 || matrix2.Columns < 1)
            {
                throw new MatrixException();
            }
            Matrix newM = new Matrix(matrix1.Rows, matrix1.Columns);
            for (int i = 0; i < matrix1.Rows; i++)
            {
                for (int j = 0; j < matrix1.Columns; j++)
                {
                    newM[i, j] = matrix1[i, j] - matrix2[i, j];
                }
            }
            return newM;
        }

        public static Matrix operator *(Matrix matrix1, Matrix matrix2)
        {
            try
            {
                if (matrix1 == null || matrix2 == null)
                {
                    throw new ArgumentNullException("matrix1");
                }
                if (matrix1.Columns != matrix2.Rows)
                {
                    throw new MatrixException();
                }
                Matrix newM = new Matrix(matrix1.Rows, matrix2.Columns);

                for (int i = 0; i < matrix1.Rows; i++)
                {
                    for (int j = 0; j < matrix2.Columns; j++)
                    {
                        for (int k = 0; k < matrix1.Columns; k++)
                        {
                            newM[i, j] += matrix1[i, k] * matrix2[k, j];
                        }
                    }
                }
                return newM;
            }
            catch (MatrixException)
            {
                throw;
            }
        }

        public Matrix Add(Matrix matrix)
        {
            return this + matrix;
        }

        public Matrix Subtract(Matrix matrix)
        {
            return this - matrix;
        }

        public Matrix Multiply(Matrix matrix)
        {
            return this * matrix;
        }

        public override bool Equals(object obj)
        {
            Matrix m = obj as Matrix;
            if (m == null) return false;
            if (Rows == m.Rows && Columns == m.Columns)
            {
                for (int i = 0; i < Rows; i++)
                {
                    for (int j = 0; j < Columns; j++)
                    {
                        if (Array[i, j] != m.Array[i, j])
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        public override int GetHashCode() => Array.GetHashCode();
    }
}
