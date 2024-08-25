using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OfficeOpenXml;

namespace proje1
{
    //Gelinen ve gidilen şehirlerin ismini ve bu iki şehir arasındaki mesafeyi tutmak için bir class yazdık
    class CityDistances
    {
        public String FirstCity { get; set; }
        public String SecondCity { get; set; }
        public int Distance { get; set; }   
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //Excelden okumak için gerekli olan kütüphane lisans izni istiyormuş
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            //Dosya yolu
            Console.Write("Excel dosyasının yolunu giriniz: ");
            String excelPath = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("Excel dosyası okunuyor...");
            Thread.Sleep(2000);
            Console.WriteLine("Okuma başarılı.");
            Console.WriteLine("");

            //Şehirleri kendimiz girdik, plakaların uyması için 0. indekse null değeri atadık
            String[] cities = { "", "Adana", "Adıyaman", "Afyon", "Ağrı", "Amasya", "Ankara", "Antalya", "Artvin", "Aydın", "Balıkesir", "Bilecik", "Bingöl", "Bitlis", "Bolu", "Burdur", "Bursa", "Çanakkale", "Çankırı", "Çorum", "Denizli", "Diyarbakır", "Edirne", "Elazığ", "Erzincan", "Erzurum", "Eskişehir", "Gaziantep", "Giresun", "Gümüşhane", "Hakkari", "Hatay", "Isparta", "Mersin", "İstanbul", "İzmir", "Kars", "Kastamonu", "Kayseri", "Kırklareli", "Kırşehir", "Kocaeli", "Konya", "Kütahya", "Malatya", "Manisa", "Kahramanmaraş", "Mardin", "Muğla", "Muş", "Nevşehir", "Niğde", "Ordu", "Rize", "Sakarya", "Samsun", "Siirt", "Sinop", "Sivas", "Tekirdağ", "Tokat", "Trabzon", "Tunceli", "Şanlıurfa", "Uşak", "Van", "Yozgat", "Zonguldak", "Aksaray", "Bayburt", "Karaman", "Kırıkkale", "Batman", "Şırnak", "Bartın", "Ardahan", "Iğdır", "Yalova", "Karabük", "Kilis", "Osmaniye", "Düzce" };

            //Bellekte uygun yeri açtık, excel dosyasından mesafeleri okumak için listemizi oluşturduk
            String[][] distances = new String[81][];

            //Liste oluşturma kısmı
            FileInfo fileInfo = new FileInfo(excelPath); 
            using (ExcelPackage excelPackage = new ExcelPackage(fileInfo))
            {
                ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets[0];
                int row = excelWorksheet.Dimension.End.Row;
                int column = excelWorksheet.Dimension.End.Column;
                
                for (int rowNumber = 3; rowNumber <= row; rowNumber++)
                {
                    distances[rowNumber - 3] = new String[row - 2];
                    for (int columnNumber = 3; columnNumber <= column; columnNumber++)
                    {
                        if (excelWorksheet.Cells[rowNumber, columnNumber].Text == "")
                        {
                            distances[rowNumber - 3][columnNumber - 3] = "0";
                        }
                        else
                        {
                            distances[rowNumber - 3][columnNumber - 3] = excelWorksheet.Cells[rowNumber, columnNumber].Text;
                        }                      
                    }
                }
            }

            //Menu
            String menu = "***********HOŞGELDİNİZ***********\n" +  
                "\nİşlemler:\n" +
                "1 - Verilen ilden belli bir uzaklığa kadar olan illerin ve uzaklıklarının listelenmesi.\n" +
                "2 - En uzak ve en kısa mesafe.\n" +
                "3 - Verilen ilden verilen mesafe kullanılarak en fazla kaç il dolaşılabililir.\n" +
                "4 - Rastgele 5 farklı plaka üretilip bu şehirler arasındaki mesafeyi yazdırma.";
            Console.WriteLine(menu);

            //0 girilince giris false'a dönüşecek ve çıkış gerçekleşecek
            Boolean giris = true;

            //Switch case ile menuden işlem numaralarını kullanarak ilerleme ayarladık
            while (giris)
            {
                Console.Write("\nİşlem numarasını giriniz (çıkış için 0 giriniz): "); 
                int islem = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("");
                switch (islem)
                {
                    case 0:
                        Console.WriteLine("Çıkış yapılıyor...");
                        Thread.Sleep(2000);
                        Console.WriteLine("Yine bekleriz...");
                        giris = false; 
                        break;
                    case 1:
                        givenCityDistancesFromOthers(cities, distances);
                        break;
                    case 2:
                        maxAndMinDistanceBetweenCities(cities, distances);
                        break;
                    case 3:
                       mostCitiesTravelled(cities, distances);
                        break;
                    case 4:
                        randomFive(cities, distances);
                        break;
                    default:
                        break;
                }
            }      
        }

        static void givenCityDistancesFromOthers(String[] cities, String[][] distances)
        {
            //Kullanıcıdan bilgileri alıyoruz
            Console.Write("Şehir ismini veya plaka numarasını giriniz: ");
            String cityOrPlate = Console.ReadLine();
            Console.Write("Mesafeyi giriniz: ");
            int inputDistance = Convert.ToInt32(Console.ReadLine());

            int cityCount = 0;
            int plate;
            Console.WriteLine("");

            //Kullanıcının girdiği veri tipine göre if else bloklarına giriyor. Plaka girdiyse IsDigit true dönüyor ve indeksten şehri çekiyor. Şehir ismi girildiyse direkt
            //şehir ismini alıyoruz
            if (cityOrPlate.All(char.IsDigit))
            {
                plate = Convert.ToInt32(cityOrPlate);
                cityOrPlate = cities[plate];
            }
            else
            {
                cityOrPlate = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(cityOrPlate);
                plate = Array.IndexOf(cities, cityOrPlate);
            }

            //Girilen bilgiler doğrultusunda distances matrisinden o şehrin diğer şehirlere uzaklıkları değerlendiriliyor ve uygun olanları yazdırılıyor
            for (int i = 0; i <= distances.GetLength(0) - 1; i++)
            {
                if (int.Parse(distances[plate - 1][i]) <= inputDistance && int.Parse(distances[plate - 1][i]) != 0)
                {
                    cityCount++;
                    String otherCity = cities[i + 1];
                    Console.WriteLine($"{cityOrPlate} - {otherCity} arasındaki mesafe {distances[plate - 1][i]} km.");
                }
            }

            Console.WriteLine($"\nVerilen mesafedeki şehir sayısı: {cityCount}");
        }

        static void maxAndMinDistanceBetweenCities(String[] cities, String[][] distances)
        {
            //Değişkenleri oluşturduk
            int maxDist = 0; 
            int minDist = 99999;
            String maxCity1 = "";
            String maxCity2 = "";
            String minCity1 = "";
            String minCity2 = "";

            //81x81 şeklinde mesafeleri taradık, maxDist ve minDist değişkenlerini uygun koşullarda güncelledik
            for (int i = 0; i <= distances.GetLength(0) - 1; i++) 
            {
                for (int j = 0; j < distances.GetLength(0) - 1; j++)
                {
                    int dist = int.Parse(distances[i][j]);
                    
                    if(i != j)
                    {
                        if (maxDist < dist)
                        {
                            maxDist = dist;
                            maxCity1 = cities[i + 1];
                            maxCity2 = cities[j + 1];
                        }
                        if (minDist > dist)
                        {
                            minDist = dist;
                            minCity1 = cities[i + 1];
                            minCity2 = cities[j + 1];
                        }
                    }                              
                }
            }

            Console.WriteLine($"En uzun mesafe: {maxDist} km ile {maxCity1} - {maxCity2} şehirleri arasında.");
            Console.WriteLine($"En kısa mesafe: {minDist} km ile {minCity1} - {minCity2} şehirleri arasında.");
        }

        static void DFS(string[] cities, string[][] distances, int currentIndex, int totalDistance, List<string> currentPath, int maxDist, List<CityDistances> currentPathDistances, ref List<CityDistances> bestPathDistances, ref int maxCitiesTravelled, ref int bestTotalDistance)
        {
            //Girilen mesafe aşıldıysa mevcut değerlendirilmekte olan rota değerlendirilmiyor
            if (totalDistance > maxDist)
            {
                return;
            }

            //Gezilen şehir sayısı aynı maxDist karşılaştırılması gibi yapılarak en fazla sayıda gezilen rota güncelleniyor
            if (currentPath.Count > maxCitiesTravelled)
            {
                maxCitiesTravelled = currentPath.Count;
                bestPathDistances = new List<CityDistances>(currentPathDistances);
                bestTotalDistance = totalDistance;
            }

            //DFS metodumuzu tekrar çağırarak recursive şeklinde ilerleme kaydediyoruz. Bu şekilde olası tüm rotalar değerlendiriliyor ve amacımıza ulaşıyoruz
            for (int i = 0; i < distances[currentIndex].Length; i++)
            {
                int distance = int.Parse(distances[currentIndex][i]);
                if (distance > 0 && !currentPath.Contains(cities[i + 1]))
                {
                    currentPath.Add(cities[i + 1]);
                    currentPathDistances.Add(new CityDistances { FirstCity = cities[currentIndex + 1], SecondCity = cities[i + 1], Distance = distance });
                    totalDistance += distance;
                    DFS(cities, distances, i, totalDistance, currentPath, maxDist, currentPathDistances, ref bestPathDistances, ref maxCitiesTravelled, ref bestTotalDistance);

                    //Eklenen currentPath ve currentPathDistances recursive'den sonra tekrar kullanılabilmek için çıkarılıyor
                    currentPath.RemoveAt(currentPath.Count - 1);
                    currentPathDistances.RemoveAt(currentPathDistances.Count - 1);

                    //totalDistance'ı 0'da tutmak için
                    totalDistance -= distance; 
                }
            }
        }

        static void mostCitiesTravelled(string[] cities, string[][] distances)
        {
            //Kullanıcıdan istenilen bilgileri alıyoruz
            Console.Write("Başlanılacak şehri giriniz: ");
            string startPoint = Console.ReadLine();
            startPoint = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(startPoint);

            Console.Write("Maksimum mesafeyi giriniz: ");
            int maxDist = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("");

            //Başlangıç şehrinin indeksini alıyoruz
            int startPointIndex = Array.IndexOf(cities, startPoint);
            int maxCitiesTravelled = 0;
            int bestTotalDistance = 0;

            //bestPath listesi en fazla şehir gezilen rotayı takip ediyoruz
            List<string> bestPath = new List<string> { startPoint };

            //bestPathDistances listesi bestPath'ta bulunan şehirler arasındaki mesafeleri tutuyor. Tip olarak yazdığımız CityDistance classını vererek
            //FirstCity, SecondCity ve Distance değişkenlerini kullanıyoruz
            List<CityDistances> bestPathDistances = new List<CityDistances>();

            //Değerlendirilmekte olan rotadaki şehirler arasındaki mesafeleri ve şehirleri tutuyoruz
            List<CityDistances> currentPathDistances = new List<CityDistances>();

            //Yazdığımız DFS metodu en fazla şehir gezilen rotayı ve bu şehirler arasındaki mesafeleri buluyor
            DFS(cities, distances, startPointIndex - 1, 0, bestPath, maxDist, currentPathDistances, ref bestPathDistances, ref maxCitiesTravelled, ref bestTotalDistance);

            //En uygun rotadaki mesafeleri ve şehirleri ekrana yazdırıyoruz
            foreach (var distance in bestPathDistances)
            {
                Console.WriteLine($"{distance.FirstCity} -> {distance.SecondCity}: {distance.Distance} km");
            }

            // Toplam şehir sayısını ve alınan toplam mesafeyi ekrana yazdırıyoruz
            Console.WriteLine("");
            Console.WriteLine($"Toplam şehir sayısı: {maxCitiesTravelled}");
            Console.WriteLine($"Toplam alınan yol: {bestTotalDistance} km");
        }

        static void randomFive(String[] cities, String[][] distances)
        {
            //Random 5 tane plaka kodu üretiyoruz
            Random r = new Random();
            int[] indexes = new int[5];
            for (int i = 0;i < 5; i++)
            {
                int index = r.Next(1,cities.Length);
                indexes[i] = index;
            }
       
            //Random üretilen plakaları çekerek diğer 4 şehrin randomIndex'te bulunan diğer şehirle arasındaki mesafeyi buluyoruz
            foreach (int randomIndex in indexes)
            {
                //randomIndexten gelen şehri alıyoruz
                String city1 = cities[randomIndex];

                for (int j = 0; j < 5; j++)
                {
                    //Örneğin: İzmir - İzmir arasındaki mesafe 0 km. Gibi çıktılar almamak için kendisiyle çakışmamasını sağlıyoruz
                    if(randomIndex != indexes[j])
                    {
                        //Diğer şehirleri ve mesafeleri çekerek ekrana yazdırıyoruz
                        String city2 = cities[indexes[j]];
                        String distance = distances[randomIndex - 1][indexes[j] - 1];
                        Console.WriteLine($"{city1} - {city2} arasındaki mesafe {distance} km.");
                    }   
                }
                Console.WriteLine("");
            }
        }
    }
}
