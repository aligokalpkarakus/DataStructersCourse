using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStLab8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 6, 3, 5, 7, 4, 2, 1, 8 };
            Console.WriteLine("Original array: " + array);
            printArray(array);
            selectionSort(array);
            printArray(array);
            Console.ReadKey();
        }

        static void selectionSort(int[] array)
        {
            int min;
            int tur = 0;
            for (int i = 0; i < array.Length - 1; i++)
            {
                min = i;
                for (int j =  i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[min])
                    {
                        min = j;
                    }
                }
                //swap
                int temp = array[i];
                array[i] = array[min];
                array[min] = temp;
                tur++;

                Console.WriteLine("Tur " + tur + ":");
                printArray(array);
            }
        }

        static void printArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
