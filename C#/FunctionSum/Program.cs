using System;

namespace FunctionSum
{
    class Program
    {
        static int arrayAdd(int[] values)
        {
            int output = 0;
            foreach(int value in values)
            {
                output = output + value;
            }
            return output;
        }
        static void Main(string[] args)
        {
            int[] values = {4, 5, 6, 7};
            Console.WriteLine(arrayAdd(values));
        }
    }
}
