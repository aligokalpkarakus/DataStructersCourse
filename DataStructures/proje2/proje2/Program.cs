using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace proje2
{
    class PriorityQueueMusteri<T>
    {
        private List<int> list; // liste

        public PriorityQueueMusteri() //constructor
        {
            list = new List<int>();
        }

        public void enqueue(int item) // eleman ekleme
        {
            list.Add(item);
        }

        public int dequeue() // eleman çıkarma
        {
            int kucukAlanIndex = 0;
            for (int i = 1; i < list.Count; i++)
            {
                if (list[kucukAlanIndex] > list[i]) //artan sırayla eleman çıkarma işlemi
                {
                    kucukAlanIndex = i;
                }

            }
            int temp = list[kucukAlanIndex];
            list.RemoveAt(kucukAlanIndex);
            return temp;
        }

        public bool isEmpty()
        {
            return list.Count == 0;
        }
    }

    class PriorityQueue<T>
    {
        private List<UM_Alanı> list; //liste 
        
        public PriorityQueue() //constructor
        {
            list = new List<UM_Alanı>();
        }

        public void enqueue(UM_Alanı item) //eleman ekleme
        {
            list.Add(item);
        }

        public UM_Alanı dequeue()
        {
            int kucukAlanIndex = 0;
            for(int i = 1; i < list.Count; i++)
            {
                if (String.Compare(list[kucukAlanIndex].Alan_Adı, list[i].Alan_Adı) > 0) //alfabe sırasında küçük olanı önce çıkarma
                {
                    kucukAlanIndex = i;
                }
                
            }
            UM_Alanı temp = list[kucukAlanIndex];
            list.RemoveAt(kucukAlanIndex);
            return temp;
        }

        public bool isEmpty()
        {
            return list.Count == 0;
        }
    }
    class MyQueue<T>
    {
        private List<T> items; //liste

        public MyQueue() 
        {
            items = new List<T>(); //constructor
        }

        public void enqueue(T item) //ekleme
        {
            items.Add(item);
        }

        public T dequeue() //silme
        {
            if (isEmpty())
            {
                throw new InvalidOperationException("Queue is empty");
            }

            T item = items[0];
            items.RemoveAt(0);
            return item;
        }

        public bool isEmpty()
        {
            return items.Count == 0;
        }
    }

    class MyStack<UM_Alanı>
    {
        private List<UM_Alanı> items; //liste
        public MyStack()
        {
            items = new List<UM_Alanı>(); //constructor
        }

        public void push(UM_Alanı item) //ekleme
        {
            items.Add(item);
        }

        public UM_Alanı pop() //çıkarma
        {
            if (items.Count == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }

            int lastIndex = items.Count - 1;
            UM_Alanı poppedItem = items[lastIndex];
            items.RemoveAt(lastIndex);
            return poppedItem;
        }

        public bool isEmpty()
        {
            return items.Count == 0;
        }
    }
    class UM_Alanı
    {
        public String Alan_Adı { get; set; } //UM_Alanına ait değişkenler
        public List<string> İl_Adı { get; set; }
        public int İlan_Yılı { get; set; }

        public UM_Alanı(String alan_Adı, List<string> il_Adları, int ilan_Yılı) //constructor
        {
            Alan_Adı = alan_Adı;
            İl_Adı = il_Adları;
            İlan_Yılı = ilan_Yılı;
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> sehirBolgeleri = new Dictionary<string, string> //şehirlere göre bölgeleri tutan sözlük
            {
                { "Antalya-Muğla", "Akdeniz" }, { "Diyarbakır", "Doğu Anadolu" },{ "Kars", "Doğu Anadolu" },{ "Malatya", "Doğu Anadolu" },
                { "Denizli", "Ege" },{ "İzmir", "Ege" },{ "Aydın", "Ege" },{ "Afyon", "Ege" },{ "Adıyaman", "Güneydoğu Anadolu" },{ "Şanlıurfa", "Güneydoğu Anadolu" },
                { "Konya", "İç Anadolu" },{ "Ankara", "İç Anadolu" },{ "Eskişehir", "İç Anadolu" },{ "Çorum", "Karadeniz" },{ "Karabük", "Karadeniz" },
                { "Kastamonu", "Karadeniz" },{ "İstanbul", "Marmara" },{ "Çanakkale", "Marmara" },{ "Edirne", "Marmara" },{ "Bursa", "Marmara" }, {"Sivas","İç Anadolu"},
                {"Nevşehir", "İç Anadolu"}
            };

            String[] alanlar = { "Divriği Ulu Camii ve Darüşşifası (Sivas) 1985" , "İstanbul'un Tarihi Alanları (İstanbul) 1985" , "Göreme Millî Parkı ve Kapadokya (Nevşehir) 1985",
            "Hattuşa: Hitit Başkenti (Çorum) 1986" , "Nemrut Dağı (Adıyaman) 1987", "Hieropolis-Pamukkale (Denizli) 1988", "Xanthos-Letoon (Antalya-Muğla) 1988", "Safranbolu Şehri (Karabük) 1994",
            "Truva Arkeolojik Alanı (Çanakkale) 1998", "Edirne Selimiye Camii ve Külliyesi (Edirne) 2011", "Çatalhöyük Neolitik Alanı (Konya) 2012",
            "Bursa ve Cumalıkızık: Osmanlı İmparatorluğunun Doğuşu (Bursa) 2014", "Bergama Çok Katmanlı Kültürel Peyzaj Alanı (İzmir) 2014", "Diyarbakır Kalesi ve Hevsel Bahçeleri Kültürel Peyzajı (Diyarbakır) 2015",
            "Efes (İzmir) 2015", "Ani Arkeolojik Alanı (Kars) 2016", "Aphrodisias (Aydın) 2017", "Göbekli Tepe (Şanlıurfa) 2018", "Arslantepe Höyüğü (Malatya) 2021",
            "Gordion (Ankara) 2023", "Eşrefoğlu Camii (Konya) 2023", "Mahmut Bey Camii (Kastamonu) 2023", "Sivrihisar Camii (Eskişehir) 2023", "Afyon Ulu Camii (Afyon) 2023",
            "Arslanhane Camii (Ankara) 2023"}; // kullanılacak alanlar

            

            List<UM_Alanı> umAlanları = new List<UM_Alanı>(); //generic list

            foreach(var alan in alanlar) //alanlar listesindeki alanları birbirinden ayır
            {
                String[] split = alan.Split('(', ')'); //parantez içini ayırma

                String alan_Adı = split[0].Trim(); //ilk paranteze kadar alan adını alma
                List<String> il_Adları = new List<String>(split[1].Trim().Split(',')); //parantezler arasını il adlarına alma
                int ilan_Yılı = int.Parse(split[2].Trim()); // yılı alma

                UM_Alanı umAlanı = new UM_Alanı(alan_Adı, il_Adları, ilan_Yılı); //çekilen alanı UM_Alanı nesnesi yapma
                umAlanları.Add(umAlanı); //listeye ekleme
            }

            Console.WriteLine("------------------HOŞGELDİNİZ------------------"); //Menu
            Console.WriteLine("İşlemler:");
            Console.WriteLine("1 - UNESCO Dünya Mirası Listesi\n" +
                "2 - Yığıt Listesi\n" +
                "3 - Kuyruk Listesi\n" +
                "4 - Öncelikli Kuyruk\n" +
                "5 - Müşteri Bekleme Süresi\n" +
                "6 - Sıralı Müşteri Bekleme Süresi");

            bool giris = true;
            while (giris)
            {
                Console.WriteLine();
                Console.Write("İşlem numarası giriniz (çıkış için 0): ");
                int islem = Int32.Parse(Console.ReadLine());
                Console.WriteLine();

                switch (islem)
                {
                    case 0:
                        Console.WriteLine("Çıkış yapılıyor..");
                        Thread.Sleep(2000);
                        Console.WriteLine("Yine bekleriz..");
                        giris = false;
                        break;
                    case 1:
                        unescoUmAlanları(umAlanları, sehirBolgeleri);
                        break;
                    case 2:
                        umAlanlariStack(umAlanları, sehirBolgeleri);
                        break;
                    case 3:
                        umAlanlariQueue(umAlanları, sehirBolgeleri);
                        break;
                    case 4:
                        umAlanlariPriorityQueue(umAlanları, sehirBolgeleri);
                        break;
                    case 5:
                        musteriQueue();
                        break;
                    case 6:
                        musteriPriorityQueue();
                        break;
                    default:
                        break;
                    
                }
            }
        }

        public static void unescoUmAlanları(List<UM_Alanı> umAlanları, Dictionary<string,string> sehirBolgeleri)
        {
            String[] bölgeler = { "Akdeniz", "Doğu Anadolu", "Ege", "Güneydoğu Anadolu", "İç Anadolu", "Karadeniz", "Marmara" }; //bölgeler

            List<UM_Alanı>[] genList = new List<UM_Alanı>[7]; // 7 elemanlı generic list

            for (int i = 0; i < genList.Length; i++)
            {
                genList[i] = new List<UM_Alanı>(); // listeyi kullanabilmek için oluşturma
            }


            foreach (var umAlan in umAlanları) //bölgelere göre alanları ayırma
            {
                foreach (var sehir in umAlan.İl_Adı)
                {
                    if (sehirBolgeleri.ContainsKey(sehir))
                    {
                        string bölge = sehirBolgeleri[sehir];
                        int bölgeIndex = Array.IndexOf(bölgeler, bölge); 

                         genList[bölgeIndex].Add(umAlan);

                    }
                }
            }

            Console.WriteLine("Bölge adları\tAlan Bilgileri"); //Output
            Console.WriteLine("------------\t--------------");

            for (int i = 0; i < genList.Length; i++)
            {
                Console.WriteLine($"{bölgeler[i]}\t\t");
                Console.WriteLine($"Alan Sayısı: {genList[i].Count}");
                foreach (var umAlan in genList[i])
                {
                    Console.WriteLine($"\t\tAlan ismi: {umAlan.Alan_Adı}");
                    foreach (var sehir in umAlan.İl_Adı)
                    {
                        Console.WriteLine($"\t\tŞehir ismi: {sehir}");
                    }
                    Console.WriteLine($"\t\tYıl: {umAlan.İlan_Yılı}\n");
                }
                Console.WriteLine("-----------------------------------------------------------------------------------------");
            }
        }

        public static void umAlanlariStack(List<UM_Alanı> umAlanları, Dictionary<string, string> sehirBolgeleri)
        {

            Console.WriteLine("Bölge adları\tAlan Bilgileri");
            Console.WriteLine("------------\t--------------");

            MyStack<UM_Alanı> myStack = new MyStack<UM_Alanı>(); //stack nesnesi

            foreach (var umAlan in umAlanları)
            {
                
                myStack.push(umAlan); //elemanları ekleme
               
            }

            while (!myStack.isEmpty()) // elemanları çıkarırken yazdırma
            {
                UM_Alanı popped = myStack.pop();
                string bolgeAdı = "";

                foreach (var sehir in popped.İl_Adı)
                {
                    if (sehirBolgeleri.ContainsKey(sehir))
                    {
                        bolgeAdı = sehirBolgeleri[sehir];

                        Console.WriteLine($"{bolgeAdı}\t\t");
                        Console.WriteLine($"\t\tAlan ismi: {popped.Alan_Adı}");
                        foreach (var ilAdi in popped.İl_Adı)
                        {
                            Console.WriteLine($"\t\tŞehir ismi: {ilAdi}");
                        }
                        Console.WriteLine($"\t\tYıl: {popped.İlan_Yılı}\n");
                        Console.WriteLine("-----------------------------------------------------------------------------------------");
                    }
                }
            }
        }

        public static void umAlanlariQueue(List<UM_Alanı> umAlanları, Dictionary<string,string> sehirBolgeleri)
        {
            MyQueue<UM_Alanı> myQueue = new MyQueue<UM_Alanı>(); // queue nesnesi

            foreach (var umAlan in umAlanları)
            {
                myQueue.enqueue(umAlan); // eleman ekleme
            }

            Console.WriteLine("Bölge adları\tAlan Bilgileri");
            Console.WriteLine("------------\t--------------");

            while (!myQueue.isEmpty()) // elemanları çıkarırken yazdırma
            {
                UM_Alanı dequeued = myQueue.dequeue();
                string bolgeAdi = "";

                foreach (var sehir in dequeued.İl_Adı)
                {
                    if (sehirBolgeleri.ContainsKey(sehir))
                    {
                        bolgeAdi = sehirBolgeleri[sehir];

                        Console.WriteLine($"{bolgeAdi}\t\t");
                        Console.WriteLine($"\t\tAlan ismi: {dequeued.Alan_Adı}");
                        foreach (var ilAdi in dequeued.İl_Adı)
                        {
                            Console.WriteLine($"\t\tŞehir ismi: {ilAdi}");
                        }
                        Console.WriteLine($"\t\tYıl: {dequeued.İlan_Yılı}\n");
                        Console.WriteLine("-----------------------------------------------------------------------------------------");
                    }
                }

            }

        }

        public static void umAlanlariPriorityQueue(List<UM_Alanı> umAlanları, Dictionary<string, string> sehirBolgeleri)
        {
            PriorityQueue<UM_Alanı> priorityQueue = new PriorityQueue<UM_Alanı>(); //priority queue nesnesi

            foreach (var umAlan in umAlanları)
            {
                priorityQueue.enqueue(umAlan); // elemanları ekleme
            }

            Console.WriteLine("Bölge adları\tAlan Bilgileri");
            Console.WriteLine("------------\t--------------");

            while (!priorityQueue.isEmpty()) //elemanları çıkarırken yazdırma
            {
                UM_Alanı dequeued = priorityQueue.dequeue(); 
                string bolgeAdi = "";

                foreach (var sehir in dequeued.İl_Adı)
                {
                    if (sehirBolgeleri.ContainsKey(sehir))
                    {
                        bolgeAdi = sehirBolgeleri[sehir];

                        Console.WriteLine($"{bolgeAdi}\t\t");
                        Console.WriteLine($"\t\tAlan ismi: {dequeued.Alan_Adı}");
                        foreach (var ilAdi in dequeued.İl_Adı)
                        {
                            Console.WriteLine($"\t\tŞehir ismi: {ilAdi}");
                        }
                        Console.WriteLine($"\t\tYıl: {dequeued.İlan_Yılı}\n");
                        Console.WriteLine("-----------------------------------------------------------------------------------------");
                    }
                }

            }
        }
        public static void musteriQueue()
        {
            MyQueue<int> myQueue = new MyQueue<int>(); // queue nesnesi
            int[] amountOfProducts = { 10, 4, 8, 6, 7, 1, 15, 9, 3, 2 }; // müşterilerin ürün sayısı

            for (int i = 0; i < amountOfProducts.Length; i++)
            {
                myQueue.enqueue(amountOfProducts[i]); // ürün sayılarını queue'ya ekleme
            }

            float second = 2.5f;
            int musteriSayisi = 0;
            float musteriSaniye = 0.0f;
            float secondSum = 0.0f;

            while (!myQueue.isEmpty()) //işlemler ve output
            {
                int dequeuedProduct = myQueue.dequeue();
                musteriSaniye += dequeuedProduct * second;
                secondSum += musteriSaniye;

                Console.WriteLine($"{musteriSayisi + 1}. müşterinin işlem tamamlanma süresi: {musteriSaniye} saniye.");

                musteriSayisi++;
                
            }
            Console.WriteLine();
            Console.WriteLine($"Toplam işlem süresi: {secondSum}");
            Console.WriteLine($"Ortalama işlem tamamlanma süresi: {secondSum / musteriSayisi} ");


        }

        public static void musteriPriorityQueue()
        {
            PriorityQueueMusteri<int> myQueue = new PriorityQueueMusteri<int>();  // priority queue nesnesi
            int[] amountOfProducts = { 10, 4, 8, 6, 7, 1, 15, 9, 3, 2 };  // ürün sayıları

            for (int i = 0; i < amountOfProducts.Length; i++)
            {
                myQueue.enqueue(amountOfProducts[i]); // ürün sayılarını ekleme 
            }

            float second = 2.5f;
            int musteriSayisi = 0;
            float musteriSaniye = 0.0f;
            float secondSum = 0.0f;

            while (!myQueue.isEmpty()) // işlemler ve artan sırayla çıkarma işlemiyle output
            {
                int dequeuedProduct = myQueue.dequeue();
                musteriSaniye += dequeuedProduct * second;
                secondSum += musteriSaniye;

                Console.WriteLine($"{musteriSayisi + 1}. müşterinin işlem tamamlanma süresi: {musteriSaniye} saniye.");

                musteriSayisi++;

            }
            Console.WriteLine();
            Console.WriteLine($"Toplam işlem süresi: {secondSum}");
            Console.WriteLine($"Ortalama işlem tamamlanma süresi: {secondSum / musteriSayisi} ");


        }

    }
    }
