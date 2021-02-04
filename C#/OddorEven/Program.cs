using System;
using System.Collections.Generic;

namespace OddorEven
{
    class Program
    {
        static void Main(string[] args)
        {
            Random generate = new Random();
            int[] array     = new int[2000];
            List<int> odd   = new List<int>();
            List<int> even  = new List<int>();

            for(int i = 0; i < array.Length; i++)
            {
                int value = generate.Next(0, 10000);
                array[i] = value;
            }

            for(int j = 0; j < array.Length; j++)
            {
                if((array[j] % 2) == 0)
                    even.Add(array[j]);
                else
                    odd.Add(array[j]);
            }
            Console.WriteLine($"No. of Even values : {even.Count} of {array.Length}");
            Console.WriteLine($"No. of Odd values  : {odd.Count} of {array.Length}");
        }
    }
}