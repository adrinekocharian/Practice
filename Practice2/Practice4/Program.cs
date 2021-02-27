using System;

namespace Practice4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] multiArray = new int[3,3];
            int[,] multiArray3 = new int[2,3];

            int[][] jaggedArray = new int[5][];

            Matrix matrix1 = new Matrix(3, 3);
            Matrix matrix2 = new Matrix(3, 4);
            matrix1.GenerateRandomMatrix();
            matrix2.GenerateRandomMatrix();
            matrix1.PrintMatrix();
            matrix2.PrintMatrix();

            // Console.ReadLine();
            //bool IsUpper = false;
            //if (userInput == 1)
            //    IsUpper = true;
            //IsUpper = false;

            var triangularMatrix = matrix1.GetTriangularMatrix(true);
            if (triangularMatrix != null)
            {
                triangularMatrix.PrintMatrix();
            }
            // Same as usign null-conditional (?.) operator
            triangularMatrix?.PrintMatrix();

            //string a = "hello";
            //DateTime d = DateTime.Now;
            //var d1 = d.AddDays(2);
            //matrix1.Addition(matrix2);
            //Matrix mult = matrix1.Mult(matrix2);

            Matrix mult2 = Matrix.Mult(matrix1, matrix2);
            mult2.PrintMatrix();

            //Matrix m = matrix1 + matrix2;
            //int a = 0, b = 0;
            //int s = a + b;

            Console.ReadLine();
        }
    }
}