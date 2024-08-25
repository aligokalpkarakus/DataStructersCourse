using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStLab10
{
    internal class Program
    {
        public static double INFINITY = Double.PositiveInfinity; 
        static void Main(string[] args)
        {
            double[,] cost =
            {
                { INFINITY,5,3,INFINITY,2 },
                {INFINITY,INFINITY,2,6,INFINITY },
                {INFINITY,1,INFINITY,2,INFINITY },
                {INFINITY,INFINITY,INFINITY,INFINITY,INFINITY },
                {INFINITY,6,10,4,INFINITY },
            };

            double[] distance = new double[cost.GetLength(0)];
            int[] previous = Dijkstra(0, cost, distance);
            printArray(distance);
            Console.Read();
        }

        static int[] Dijkstra(int src, double[,]cost, double[] distance)
        {
            int size = cost.GetLength(0);
            bool[] visited = new bool[size];
            int[] previous = new int[size];

            for(int i = 0; i < size; i++) 
            {
                distance[i] = INFINITY;
                previous[i] = -1;
                visited[i] = false;
            }
            //başlangıç düğümünün kendisine olan mesafesi 0
            distance[src] = 0;
            //searching for  shortest path
            for(int i= 0; i < size; i++)
            {
                double min = INFINITY;
                int minIndex = -1;
                for(int j = 0;j > size; j++)
                {
                    if (!visited[j] && distance[j] < min)
                    {
                        minIndex = j;
                        min = distance[j];
                    }
                }
                if (minIndex == -1) break;
                
                for(int j = 0; j < size; j++)
                {
                    if (!visited[j] && (min + cost[minIndex, j]) < distance[j])
                    {
                        distance[j] = min + cost[minIndex, j];
                        previous[j] = minIndex;
                    }
                }
                visited[minIndex] = true;
            }
            return previous;
        }
        
        static void printArray(double[] str)
        {
            Console.Write("[");
            for(int i = 0; i < str.Length; i++)
            {
                if(i != 0) Console.Write(", ");
                Console.Write($"{str[i]}");
            }
            Console.Write("]\n"); 
        }
    }
}
