using System;
using System.Collections.Generic;
using System.Text;

namespace Practice4
{
    class Matrix
    {
        private int[,] body; // int[] body; int[][]
        public int NumOfRows { get; set; }
        public int NumOfColumns { get; set; }

        public Matrix(int n, int m)
        {
            this.NumOfRows = n;
            this.NumOfColumns = m;
            this.body = new int[n, m];
        }
       
        public void GenerateRandomMatrix()
        {
            Random rand = new Random();
            for (int i = 0; i < this.NumOfRows; i++)
            {
                for (int j = 0; j < this.NumOfColumns; j++)
                {
                    this.body[i, j] = rand.Next(1, 10);
                }
            }
        }

        public static Matrix Addition(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.NumOfRows != matrix2.NumOfRows || matrix1.NumOfColumns != matrix2.NumOfColumns)
                return null;

            Matrix sum = new Matrix(matrix1.NumOfRows, matrix1.NumOfColumns);
            for (int i = 0; i < matrix1.NumOfRows; i++)
            {
                for (int j = 0; j < matrix1.NumOfColumns; j++)
                {
                    sum.body[i, j] = matrix1.body[i, j] + matrix2.body[i, j];
                }
            }
            return sum;
        }

        public void Addition(Matrix matrix1)
        {
            if (matrix1.NumOfRows != this.NumOfRows || matrix1.NumOfColumns != this.NumOfColumns)
            {
                Console.WriteLine("Can not add given matrices.");
                return;
            }

            for (int i = 0; i < matrix1.NumOfRows; i++)
            {
                for (int j = 0; j < matrix1.NumOfColumns; j++)
                {
                    this.body[i, j] = matrix1.body[i, j] + this.body[i, j];
                }
            }
        }

        public Matrix ScalarMult(int scalar)
        {
            Matrix scalarMultMatrix = new Matrix(this.NumOfRows, this.NumOfColumns);
            for (int i = 0; i < this.NumOfRows; i++)
            {
                for (int j = 0; j < this.NumOfColumns; j++)
                {
                    scalarMultMatrix.body[i, j] = this.body[i, j] * scalar;
                }
            }

            return scalarMultMatrix;
        }

        //public Matrix Mult(Matrix matrix)
        //{

        //}
        public static Matrix Mult(Matrix m1, Matrix m2)
        {
            if (m1.NumOfColumns != m2.NumOfRows)
            {
                Console.WriteLine("Cannot multiply given matrices.");
                return null;
            }
            Matrix mult = new Matrix(m1.NumOfRows, m2.NumOfColumns);
            for (int i = 0; i < m1.NumOfRows; i++)
            {
                for (int j = 0; j < m2.NumOfColumns; j++)
                {
                    for (int k = 0; k < m1.NumOfColumns; k++)
                    {
                        mult.body[i, j] += m1.body[i, k] * m2.body[k, j];
                    }
                }
            }
            return mult;
        }

        public void PrintMatrix()
        {
            for (int i = 0; i < this.NumOfRows; i++)
            {
                for (int j = 0; j < this.NumOfColumns; j++)
                {
                    Console.Write(this.body[i,j]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
        //public Matrix LowerTriangluarMatrix()
        //{

        //}
        //public Matrix UpperTriangluarMatrix()
        //{

        //}
        public Matrix GetTriangularMatrix(bool isUpper)
        {
            if (this.NumOfColumns != this.NumOfRows)
            {
                Console.WriteLine("The given matrix does not have triangular matrix.");
                return null;
            }

            Matrix result = new Matrix(this.NumOfRows, this.NumOfColumns);
            for (int i = 0; i < this.NumOfRows; i++)
            {
                for (int j = 0; j < this.NumOfColumns; j++)
                {
                    if (isUpper)
                    {
                        if (j >= i)
                        {
                            result.body[i, j] = this.body[i, j];
                        }
                    }
                    else
                    {
                        if(j <= i)
                        {
                            result.body[i, j] = this.body[i, j];
                        }
                    }
                }
            }
            return result;
        }

        public override string ToString()
        {
            PrintMatrix();
            return null;
        }
    }
}
