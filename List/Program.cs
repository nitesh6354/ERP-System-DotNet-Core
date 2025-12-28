using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();

            // Add
            list.Add(10);
            list.Add(20);
            list.Add(30);

            // AddRange
            list.AddRange(new int[] { 40, 50 });

            // Insert
            list.Insert(2, 25);     // index 2

            Console.WriteLine("After Add, AddRange, Insert:");
            Print(list);

            // Remove (first occurrence)
            list.Remove(20);

            // RemoveAt (index)
            list.RemoveAt(0);

            Console.WriteLine("\nAfter Remove & RemoveAt:");
            Print(list);

            // RemoveAll (condition)
            list.RemoveAll(x => x > 30);

            Console.WriteLine("\nAfter RemoveAll(x > 30):");
            Print(list);

            // Contains
            Console.WriteLine("\nContains 25: " + list.Contains(25));

            // IndexOf
            Console.WriteLine("IndexOf 25: " + list.IndexOf(25));

            // Count
            Console.WriteLine("Count: " + list.Count);

            // Sort
            list.Sort();
            Console.WriteLine("\nAfter Sort:");
            Print(list);

            // Reverse
            list.Reverse();
            Console.WriteLine("\nAfter Reverse:");
            Print(list);
        }

        static void Print(List<int> list)
        {
            Console.WriteLine(string.Join(", ", list));
        }

    
    }
}


//output:

/*
    After Add, AddRange, Insert:
    10, 20, 25, 30, 40, 50

    After Remove & RemoveAt:
    25, 30, 40, 50

    After RemoveAll(x > 30):
    25, 30

    Contains 25: True
    IndexOf 25: 0
    Count: 2

    After Sort:
    25, 30

    After Reverse:
    30, 25

*/
