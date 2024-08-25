using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStrLab2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            double[] matris = { 1.2, 1.5, 3.2, 5.7, -15.6 };
            double sonuc = topla(matris);
            int serdar = matris.Length;

            Console.WriteLine(sonuc);
            Console.WriteLine(serdar);  
            Console.ReadLine();
        }

        static double topla(double[] m)
        {
            double toplam = 0;
            int elemanSayisi = 0;

            for (int i = 0; i < m.Length; i++)
            {
                toplam += m[i];
                elemanSayisi++;
            }

            return toplam;
        }
    }
}
