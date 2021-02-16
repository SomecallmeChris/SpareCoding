using System;
using System.Collections.Generic;

namespace Duplicates
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] array = new int[10]
            //{2,2,3,4,5,2,7,7,9,9};
            Dictionary<int,int> frequency = new Dictionary<int, int>();
            Random generate = new Random();
            List<int> ran_list = new List<int>();
//            int[] ran_array = new int[500];
            int value = 0;

            for(int j = 0; j < 500; j++)
            {
                value = generate.Next(0, 10);
                ran_list.Add(value);
                //ran_array[j] = value;
            }
             
            for(int i = 0; i < ran_list.Count; i++)
            {
                if(frequency.ContainsKey(ran_list[i]))
                {
                    int keyvalue = frequency[ran_list[i]];
                    keyvalue++;
                    frequency[ran_list[i]] = keyvalue;
                }
                else
                    frequency.Add(ran_list[i], 1);
            }

            foreach(var item in frequency)
            {
                Console.WriteLine($"Value {item.Key}, occured {item.Value} times");
            }
        }
    }
}
