using System;
using System.Collections;

namespace ArrayFrequency
{
    class Program
    {
        static void Main(string[] args)
        {
            Random fill = new Random();
            Hashtable table = new Hashtable();
            int[] valueArray = new int[30];

            // Fill array with 30 random values
            for(int i = 0; i < valueArray.Length; i++)
            {
                valueArray[i] = fill.Next(0, 9);
            }

            // Build hashtable for value frequencies (key)<value>
            foreach(int value in valueArray)
            {
                if(table.ContainsKey(value))
                {
                    int frequency = (int)table[value] + 1;
                    table[value] = frequency;
                }
                else
                {
                    table.Add(value, 1);
                    Console.WriteLine("New value added");
                }
            }
            foreach(DictionaryEntry de in table)
            {
                Console.WriteLine("Value {0} : Frequency : {1}", de.Key, de.Value);
            }
           
        }
    }
}