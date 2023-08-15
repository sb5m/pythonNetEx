using System;

namespace CholeskyDecomposition
{
    class Program
    {
        static void Main(string[] args)
        {
            double[,] A = {
                { 4, 12, -16 },
                { 12, 37, -43 },
                { -16, -43, 98 }
            };

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

            Console.WriteLine("Original matrix A:");
            PrintMatrix(A);

            Console.WriteLine("\nCholesky decomposition L:");
            PrintMatrix(L);
        }

        static void PrintMatrix(double[,] matrix)
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
