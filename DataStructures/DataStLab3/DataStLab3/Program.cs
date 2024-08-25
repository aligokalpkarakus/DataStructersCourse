using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataStLab3
{
    public class SehirCifti
    {
        public String[] sehirAdlari;
        public int puan;

        //constructor method
        public SehirCifti()
        {
            sehirAdlari = new String[2];
            puan = 0;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            String[] sehirler = { "İstanbul", "Roma", "Paris", "Madrid", "New York", "Moskova", "Londra", "Pekin" };
            String[] seyahatPlani = seyehatPlaniOlustur(sehirler, 4);
            SehirCifti[] sehirCiftleri = sehirCiftleriOlustur(seyahatPlani);
  

        }

        static String[] seyehatPlaniOlustur(String[] sehirler, int sehirSayisi)
        {
            String[] seyehatPlani = new string[sehirSayisi];
            Random r = new Random();
            String[] sehirlerKopya = new String[sehirler.Length];
            Array.Copy(sehirler, sehirlerKopya, sehirler.Length);
            int maxValue = sehirler.Length;

            for (int i = 0; i < sehirSayisi ; i++)
            {
                int index = r.Next(0,maxValue);
                seyehatPlani[i] = sehirlerKopya[index];

                //Kaydırma işlemi ile listeye eklenen şehir siliniyor liste kaydırılıyor.
                for (int j = index; j < sehirlerKopya.Length - 1; j++)
                {
                    sehirlerKopya[j] = sehirlerKopya[j + 1];
                }
                maxValue--;
            }

            return seyehatPlani;
        }

        //SehirCifti tipinde dizi döndüren metod
        static SehirCifti[] sehirCiftleriOlustur(String[] seyehatPlani)
        {
           int elemanSayisi = (seyehatPlani.Length * (seyehatPlani.Length - 1)) / 2;
           SehirCifti[] sehirCiftleri = new SehirCifti[elemanSayisi];
           Random r = new Random();
           int count = 0;
           for (int i = 0; i < seyehatPlani.Length; i++)
            {
                for (int j = i + 1; j < seyehatPlani.Length; j++)
                {
                    SehirCifti sc = new SehirCifti();
                    sc.sehirAdlari[0] = seyehatPlani[i];
                    sc.sehirAdlari[1] = seyehatPlani[j];
                    sc.puan = r.Next(0, 101);
                    sehirCiftleri[count] = sc;
                    count++;
                }
            }
            return sehirCiftleri;
        }

    }
}
