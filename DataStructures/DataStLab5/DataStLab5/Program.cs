using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStLab5
{
    class Musteri
    {
        public String musteriAdi;
        public int urunSayisi;

        public Musteri(string musteriAdi, int urunSayisi)
        {
            this.musteriAdi = musteriAdi;
            this.urunSayisi = urunSayisi;
        }
    }

    class Kuyruk<T>
    {
        private List<T> genericList;

        public Kuyruk()
        {
            genericList =  new List<T>();
        }

        public void Ekle(T item)
        {
            genericList.Add(item);
        }

        public T Sil()
        {
            T item = genericList[0];
            genericList.RemoveAt(0);
            return item;
        }

        public int ElemanSayisi()
        {
            return genericList.Count;
        }

        public bool BosMu()
        {
            return ElemanSayisi() == 0;
        } 
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Kuyruk<Musteri> kuyruk = new Kuyruk<Musteri>();
            kuyruk.Ekle(new Musteri("Selim", 10));
            kuyruk.Ekle(new Musteri("Canan", 20));
            kuyruk.Ekle(new Musteri("Aykut", 13));
            kuyruk.Ekle(new Musteri("Cemal", 4));

            int beklemeSuresi = 0;

            while (!kuyruk.BosMu())
            {
                Musteri musteri = kuyruk.Sil();
                Console.WriteLine($"Musteri Adi: {musteri.musteriAdi}, Bekleme Süresi: {beklemeSuresi}");
                beklemeSuresi += musteri.urunSayisi;
            }
            Console.WriteLine($"Toplam Bekleme Süresi: {beklemeSuresi}");
            Console.Read();

        }
    }
}
