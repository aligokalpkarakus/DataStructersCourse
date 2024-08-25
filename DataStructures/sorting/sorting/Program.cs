using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sorting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] data = {'b','d', 'c', 'a', 'e','h' };

            Console.WriteLine("Orijinal Dizi:");
            PrintArray(data);

            insertionSort(data);

            Console.WriteLine("\nSıralanmış Dizi:");
            PrintArray(data);
        }

        public static void insertionSort(char[] data)
        {
            int n = data.Length;
            for (int k = 1; k < n; k++) //döngü 1'den başlıyor çünkü ilk eleman zaten sıralı kabul ederiz.
            { 
                char ch = data[k]; // ch değişkeni mevcut elemanı temsil ediyor.
                int j = k; 
                while (j > 0 && data[j - 1] > ch) // while döngüsünde ch değerini uygun konuma getirmek için önceki elemanlarla karşılaştırır ve gerekirse yer değiştirir.
                { 
                    data[j] = data[j - 1]; 
                    j--; 
                }
                data[j] = ch;
                Console.WriteLine($"Adım {k}: {string.Join(", ", data)}"); 
            }
        }

        public static void PrintArray(char[] arr)
        {
            Console.WriteLine(string.Join(", ", arr)); // diziyi virgülle ayrılmış şekilde yazdırmak için.
        }
    }
}
