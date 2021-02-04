using System;

namespace MatrixAddition
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initialise 2D array
            int[,] matrixOne = new int[,]
            {
                {1,2,3},
                {4,5,6},
                {7,8,9},
            };

            int[,] matrixTwo = new int[,]
            {
                {10,11,12},
                {13,14,15},
                {16,17,18},
            };
            int rowsSize = matrixOne.GetLength(0);
            int colsSize = matrixOne.GetLength(1);

            Console.WriteLine($"MatrixOne - Rows: {rowsSize} Columns: {colsSize}");
            Console.WriteLine($"MatrixTwo - Rows: {rowsSize} Columns: {colsSize}");

            int[,] finalArray = new int[rowsSize,colsSize];
            for(int i = 0; i<rowsSize; i++)
            {
                for(int j = 0; j<colsSize; j++)
                {
                    finalArray[i,j] = matrixOne[i,j] + matrixTwo[i,j];
                }
            }
            for(int k = 0; k<rowsSize; k++)
            {
                Console.Write("\n");
                for(int l = 0; l<colsSize; l++)
                    Console.Write($"{finalArray[k,l]}, ");
            } 
        }
    }
}