using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQfuncs
{
    class Program
    {
        static void Main(string[] args)
        {
            // Data source
            int[] numbers = {0,1,2,3,4,5,6,7,8,9,10};

            // Create query
            var query = from num in numbers
                        let sqr = num * num;
                        where num > 3
                        select new num;

            // Query execution
            foreach(var item in query)
            {
                Console.Write($"{item} ");
            }
        }
    }
}
