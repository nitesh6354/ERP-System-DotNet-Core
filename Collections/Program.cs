using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

/*
-A collection is set of related data that may not neccesary belog to the same data type,
 that can be stt or modified at runtime .
-Collection is dynamic array, its length can increase at run time .
-Callections has machanism to RESIZE automatically at run time .
*/

/*
-Normal Array's Length is Fix it mean we can change length after declaring an array .
-if can change so using 'Array.Resize()' ,but Resize() method destroy old array and create a new length.
we can never insert a value into middle of a array .
*/

namespace Collections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int[] arr = new int[3];
            //arr[0] = 1;
            //arr[1] = 2;
            //arr[2] = 3;

            //Array.Resize(ref arr, 4);
            //Resize method of an array destroy old array and create 
            //a new array with new length.
            //arr[3] = 4;

            //foreach(int i in arr)
            //{
            //    Console.WriteLine(i);
            //} 
            ArrayList mylist = new ArrayList();

            Console.WriteLine(mylist.Capacity);
            mylist.Add(1);
            Console.WriteLine(mylist.Capacity);
            mylist.Add(2);
            mylist.Add(3);
            mylist.Add("nitesh");
            Console.WriteLine(mylist.Capacity);
            mylist.Add("amisha");
            Console.WriteLine(mylist.Capacity);
            
        }
    }
}
