using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = {1,2,3,4,5,6,7,8,9,10};
            IEnumerable<int> output = numbers.Where(x => x % 2 == 0).ToList();
            
            Console.WriteLine("\n".PadRight(15, '-'));
            Console.WriteLine("These are the even numbers: ");
            foreach(var item in output)
            {
                Console.Write(String.Format("{0} ", item));
            }
            Console.WriteLine("\n".PadRight(15, '-'));
            Console.WriteLine("These are the odd numbers: ");
            IEnumerable<int> oddnumbers = numbers.Where(x => x % 2 != 0).ToList();

            foreach(var item in oddnumbers)
            {
                Console.Write($"{item} ");
            }
        }
    }
}
