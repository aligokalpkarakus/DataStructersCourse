using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStLab4
{
    class IlceSinifi
    {
        public string ilceAdi;
        public int merkezdenUzaklik;

        public IlceSinifi(string ilceAdi, int merkezdenUzaklik)
        {
            this.ilceAdi = ilceAdi;
            this.merkezdenUzaklik = merkezdenUzaklik;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {

            String[] ilceAdi = {"Balçova", "Bornova","Buca","Çiğli","Gaziemir","Güzelbahçe","Karşıyaka","Konak","Narlıdere","Aliağa"
            ,"Bayındır","Bergama","Beydağ"
            ,"Çeşme","Dikili","Foça","Karaburun","Kemalpaşa"
            ,"Kınık","Kiraz","Menderes","Menemen","Ödemiş","Seferihisar"
            ,"Selçuk","Tire","Torbalı","Urla"};

            int[] merkezdenUzaklık = {14, 4, 10, 11, 8, 30, 6, 0, 17, 53, 78, 102, 141, 88, 105, 64, 107, 24, 119
            ,142, 23, 29, 113, 52, 76, 84, 46, 42 };

            int sayac = 0;
            int sayac2 = 0;

            IlceSinifi ilceSinifi;
            ArrayList arrayList = new ArrayList();
            List<IlceSinifi> genericListe;
            genericListe = new List<IlceSinifi>();
            while (sayac < ilceAdi.Length)
            {
                
                int genericListeLength = (int)Math.Pow(2,sayac2);

                for(int i = 0; i < genericListeLength ; i++)
                {
                    ilceSinifi = new IlceSinifi(ilceAdi[sayac], merkezdenUzaklık[sayac]);
                    genericListe.Add(ilceSinifi);
                    sayac++;

                    if(sayac == ilceAdi.Length)
                    {
                        break;
                    }

                    arrayList.Add(genericListe);
                    sayac2++;
                }
            }

            foreach(int i in arrayList)
            {
                for(int j = 0; j < 8; j++)
                {
                    Console.WriteLine(genericListe[i]);

                }
            }
        }
    }
}
