using System;

namespace CholeskyDecomposition
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter the size of the matrix: ");
            int n = int.Parse(Console.ReadLine());

            double[,] A = ReadMatrix(n);

            double[,] L = CholeskyDecomposition(A);

            Console.WriteLine("\nOriginal matrix A:");
            PrintMatrix(A);

            Console.WriteLine("\nCholesky decomposition L:");
            PrintMatrix(L);
        }

        public static double[,] ReadMatrix(int n)
        {
            double[,] matrix = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"Enter the value for A[{i},{j}]: ");
                    matrix[i, j] = double.Parse(Console.ReadLine());
                }
            }
            return matrix;
        }

        public static double[,] CholeskyDecomposition(double[,] A)
        {
            int n = A.GetLength(0);
            double[,] L = new double[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    double sum = 0;
                    if (i == j)
                    {
                        for (int k = 0; k < j; k++)
                            sum += L[j, k] * L[j, k];
                        L[j, j] = Math.Sqrt(A[j, j] - sum);
                    }
                    else
                    {
                        for (int k = 0; k < j; k++)
                            sum += L[i, k] * L[j, k];
                        L[i, j] = (1.0 / L[j, j] * (A[i, j] - sum));
                    }
                }
            }
            return L;
        }

        public static void PrintMatrix(double[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
