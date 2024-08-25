using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStLab9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double INF = double.PositiveInfinity;
            String[] iller = { "Ankara", "İstanbul", "İzmir", "Eskişehir", "Kayseri" };

            double[,] adjMatrix =
            {
                { INF, 5,3,INF,2},
                {INF,INF,2,6,INF },
                {INF,1,INF,2,INF },
                {INF,INF,INF,INF,INF },
                {INF, 6,10,4,INF },
            };

            Console.Write($"{" ",10}");

            for(int i = 0; i < iller.Length; i++)
            {
                Console.Write($"{iller[i],10}");
            }
            Console.WriteLine("\n");

            for(int i = 0;i < adjMatrix.GetLength(0); i++)
            {
                Console.Write($"{iller[i],10}");
                for (int j = 0; j < adjMatrix.GetLength(1); j++)
                {
                    String val = (adjMatrix[i, j] == INF) ? "#" : adjMatrix[i, j].ToString();
                    Console.Write($"{val,10}");
                }
                Console.Write("\n");
            }

            Console.WriteLine("Lütfen bir köşe numarası giriniz: ");
            int koseNo = int.Parse(Console.ReadLine() );

            int gelenKenarSay = 0, gidenKenarSay = 0;
            
            for(int i = 0; i < iller.Length; i++)
            {
                if (adjMatrix[koseNo, i] != INF)
                {
                    Console.WriteLine($"Giden Kenar: [{i}][{iller[i]}]: Maliyet: {adjMatrix[koseNo, i]}");
                    gidenKenarSay++;
                }

                if (adjMatrix[i,koseNo] != INF)
                {
                    Console.WriteLine($"Gelen Kenar: [{i}][{iller[i]}]: Maliyet: {adjMatrix[koseNo, i]}");
                    gelenKenarSay++;
                }
            }

            for(int k = 0; k < adjMatrix.GetLength(0); k++)
            {
                int minIndex = 0;
                for(int j = 1;j < adjMatrix.GetLength(1);j++)
                {
                    if (adjMatrix[k,j] != INF && adjMatrix[k,j] < adjMatrix[k, minIndex])
                    {
                        minIndex = j;
                    }
                }
                if (adjMatrix[k,minIndex] == INF)
                {
                    Console.WriteLine($"{iller[k]} için minimum maliyetli bir kenar yoktur.");
                }
                else
                {
                    Console.WriteLine($"{iller[k]} için minimum maliyet: {iller[minIndex]}");
                }

            }

            Console.ReadLine();

        }
    }
}
