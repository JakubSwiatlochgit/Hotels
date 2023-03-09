using System.Globalization;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;
using Hotels.Model;


namespace Hotels 
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                NewLine = Environment.NewLine,
                Delimiter = ";"  // ustawienie przecinka jako znaku oddzielającego
            };

            StreamReader streamReader = new StreamReader("C:\\Users\\mrmis\\source\\repos\\ProgramowanieIV\\Hotels\\hotele.csv");
            using var reader = streamReader;
            using CsvReader csvReader = new CsvReader(reader, config);

            // Wczytanie danych z pliku hotele.csv z użyciem biblioteki CsvHelper
            var hotele = csvReader.GetRecords<Hotel>().ToList();
            //foreach (var items in hotele) { Console.WriteLine(items.adres + " "); }

            // Wyszukanie wszystkich hoteli, których nazwa zaczyna się na literę 's'
            Console.WriteLine("Hotele ktorych nazwa zaczyna się na S");
            var hotelNazwaS = hotele.Where(h => h.nazwa_wlasna.ToLower().StartsWith("s"));
            foreach (var item in hotelNazwaS) { Console.WriteLine($"{item.nazwa_wlasna} "); };

            Console.WriteLine("Obliczenie ile hoteli ma charakter sezonowy: ");
            // Obliczenie ile hoteli ma charakter sezonowy
            var hotelSezonowy = hotele.Where(h => h.charakter_uslug == "sezonowy").Count();
            Console.WriteLine(hotelSezonowy);

            Console.WriteLine("Wyświetlenie wszystkich typow charakterow usług bez powtórzeń: ");
            // Wyświetlenie wszystkich typów charakterów usług bez powtórzeń
            var charakterUslug = hotele.Select(h => h.charakter_uslug).Distinct();
            foreach (var item in charakterUslug) { Console.WriteLine($"{item} "); };

            Console.WriteLine("Wyświetlenie wszystkich kategorii hoteli bez powtorzen");
            // Wyświetlenie wszystkich kategorii hoteli bez powtórzeń
            var kategoriaHoteli = hotele.Select(h => h.kategoria_obiektu).Distinct();
            foreach (var item in kategoriaHoteli) { Console.WriteLine($"{item} "); };

            Console.WriteLine("Wyswietlenie hoteli, które pochodzą z okolicy Bielska-Białej i numer telefonu zaczyna się na 33");
            // Wyświetlenie hoteli, które pochodzą z okolicy Bielska-Białej (numer telefonu zaczyna się 33)
            var hotelBielskoBiala = hotele.Where(h => h.telefon.StartsWith("33"));
            foreach (var item in hotelBielskoBiala) { Console.WriteLine($"{item.nazwa_wlasna} {item.adres}"); };

            Console.WriteLine("Grupowane hotele wg kategorii i zwrócenie ile hoteli występuje w każdej grupie");
            // Pogrupowanie hotele wg kategorii i zwrócenie ile hoteli występuje w każdej grupie
            var grupyKategorii = hotele.GroupBy(h => h.kategoria_obiektu).Select(h => new { Kategoria = h.Key, HotelCount = h.Count() });
            foreach (var item in grupyKategorii) { Console.WriteLine($"{item}"); };//te bez zadnego znaku tez zostały zliczone

            Console.WriteLine("Grupowane hotele wg charakteru uslug i zwrocenie ile hoteli wystepuje w kazdej grupie");
            // Pogrupowanie hotele wg charakteru usług i zwrócenie ile hoteli występuje w każdej grupie
            var grupyUslug = hotele.GroupBy(h => h.charakter_uslug).Select(h => new { Usluga = h.Key, HotelCount = h.Count() });
            foreach (var item in grupyUslug) { Console.WriteLine($"{item}"); };
        }
    }
}

/*1.Wczytać dane z pliku hotele.csv z użyciem biblioteki CsvHelper
2. Wyszukać wszystkie hotele, których nazwa zaczyna się na literę 's'
3. Obliczyć ile hoteli ma charakter sezonowy
4. Wyświetlić wszystkie typy charakterów usług bez powtórzeń
5. Wyświetlić wszystkie kategorie hoteli bez powtórzeń
6. Wyświetlić hotele, które pochodzą z okolicy Bielska-Białej (numer telefonu zaczyna się 33)
7.Pogrupować hotele wg kategorii i zwrócić ile hoteli występuje w każdej grupie
8. Pogrupować hotele wg charakteru usług i zwrócić ile hoteli występuje w każdej grupie*/

/*{ item.nazwa_wlasna}
{ item.id}
{ item.adres}
{ item.email}
{ item.telefon}*/