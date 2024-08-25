using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStrLab2._1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[,] matrix = { { 1, 2, 3, 4 }, { 4, 3, 2, 1 }, { 2, 5, 7, 11 }, { 13, 17, 19, 23 } };
            int sum = toplam(matrix);
            Console.WriteLine(sum);
            Console.ReadLine(); 

        }

        static int toplam(int[,] m)
        {
            int topla = 0;
           
            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    topla += m[i, j];
                }
            }

            return topla;
        }
    }
}
