using System;
using System.Collections.Generic;

namespace Practice3
{
    class Program
    {
        static void Main(string[] args)
        {
            #region rectangle and point structs

            Point point = new Point(2, 3);
            Point point1 = new Point(2, 3);
            Console.WriteLine(point.ToString());

            Console.WriteLine("\n Rectangle Struct");

            Rectangle rect = new Rectangle(4, 5);
            Console.WriteLine($"The area of rectangle is {rect.CalculateArea()}");

            Rectangle anotherRect;
            anotherRect.height = 2;
            anotherRect.width = 3;
            anotherRect.topLeftPoint = new Point(0, 0);
            Console.WriteLine($"The area of rectangle is {anotherRect.CalculateArea()}");

            Rectangle secondRect = new Rectangle
            {
                width = 3,
                height = 2,
                topLeftPoint = new Point(1, 1)
            };

            bool isOverlapping = anotherRect.IsOverlapping(secondRect);
            Console.WriteLine(isOverlapping ? "Rectangles are overlapping" : "Rectangles are not overlapping");
            Rectangle thirdRect = new Rectangle { width = 5, height = 9 };
            Console.WriteLine($"The area of rectangle is {thirdRect.CalculateArea()}");
            #endregion

            #region tuples
            (int start, int end) tup = (8, 3);
            (int max, int min) tup1 = (83, 44);
            tup = tup1;
            Console.WriteLine($"({tup.start}, {tup.end})");

            List<(string, int)> dow = new List<(string, int)> { ("Mon", 1), ("Tue", 2), ("Wed", 3) };
            int[] numbers = new int[] { 1, 4, 5, 2, 2, 1 };
            int k = 5;
            var indices = GetSubArrayIndecies(numbers, k);
            List<(int start, int end)> result = GetSubArrayIndecies(numbers, k);
            foreach ((int start, int end) item in result)
            {
                Console.WriteLine($"({item.Item1}, {item.Item2})");
            }
            #endregion

            #region arrays
            int[][] multi = new int[3][];
            int[,] multiarr = new int[1, 2];
            double[] arrayOfDoubles = new double[] { 1.0, 2.0, 5.0, 6.3, 5.6 };
            string[] arrayOfString = new string[] { "h", "hello" };

            PrintArray(arrayOfDoubles);
            var arrayOfInts = ConvertArray(arrayOfDoubles);
            PrintArray(arrayOfInts);

            PrintArray(arrayOfDoubles);

            ref int firstEl = ref FirstElement(arrayOfInts);
            firstEl = 5555;
            Console.WriteLine(firstEl);
            PrintArray(arrayOfInts);
            Console.WriteLine(firstEl);
            #endregion

            Console.ReadLine();
        }

        #region Matrix
        static int[][] GetLowerTriangularMatrix(int[][] matrix )
        {
            int[][] result = new int[matrix.Length][];
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    result[i][j] = matrix[i][j];
                }
            }
            return result;
        }

        static void PrintMatrix(int[][] matrix)
        {
            foreach (int[] arr in matrix)
            {
                foreach (int item in arr)
                {
                    Console.Write(item);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
        #endregion

        #region Tuples
        //static (int, int) MinMax()
        //{ 
        //}

        // [1, 4, 5, 2, 3] k = 5
        static List<(int, int)> GetSubArrayIndecies(int[] array, int k)
        {
            List<(int, int)> result = new List<(int, int)>();
            for (int start = 0; start < array.Length; start++)
            {
                int sum = 0;
                for (int end = start; end < array.Length; end++)
                {
                    sum += array[end];
                    if (sum == k)
                    {
                        result.Add((start, end));
                    }
                    else if(sum > k)
                    {
                        break;
                    }
                }
            }
            return result;
        }
        #endregion

        #region Arrys
        static int[] ConvertArray(double[] array)
        {
            ChnageFirstElement(array);
            int[] result = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                result[i] = Convert.ToInt32(array[i]);
               // result[i] = (int)array[i];
            }
            array = new double[] { 1.2, 5.2 };
            return result;
        }

        static ref int FirstElement(int[] array)
        {
            return ref array[0];
        }

        static void ChnageFirstElement(double[] array)
        {
            array[0] = 9.999;
        }

        static void PrintArray(Array array)
        {
            foreach (var item in array)
            {
                Console.Write(item);
                Console.Write(" ");
            }
            Console.WriteLine();
        }

        static void PrintArray(double[] array)
        {
            foreach (var item in array)
            {
                Console.Write(item);
                Console.Write(" ");
            }
        }
        #endregion
    }
}