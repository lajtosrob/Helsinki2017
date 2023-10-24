using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helsinki2017.DataSource;

namespace Helsinki2017
{

    internal class Program
    {

        static List<Versenyzo> rovidprogram = new List<Versenyzo>();
        static List<Versenyzo> donto = new List<Versenyzo>();
        static void Main(string[] args)
        {
            // 1. feladat

            static void Fajlbeolvasas(string fajlnev, List<Versenyzo> listanev)
            {
                StreamReader sr = new StreamReader(fajlnev, Encoding.UTF8);

                sr.ReadLine(); // fejléc beolvasása

                while (!sr.EndOfStream)
                {
                    string[] lines = sr.ReadLine().Split(";");

                    lines[2] = lines[2].Replace(".", ",");
                    lines[3] = lines[3].Replace(".", ",");

                    Versenyzo line = new Versenyzo(
                        lines[0],
                        lines[1],
                        double.Parse(lines[2]),
                        double.Parse(lines[3]),
                        int.Parse(lines[4])
                        );

                    listanev.Add(line);
                }

            }

            Fajlbeolvasas(".\\DataSource\\rovidprogram.csv", rovidprogram);
            Fajlbeolvasas(".\\DataSource\\donto.csv", donto);

            // 2. feladat

            Console.WriteLine("2. feladat: ");

            Console.WriteLine($"\tA rövidprogramban {rovidprogram.Count()} versenyző volt");

            // 3. feladat 

            Console.WriteLine("3. feladat: ");

            bool isHun = false;

            foreach (var item in donto)
            {
                if (item.Orszagkod == "HUN")
                {
                    isHun = true;
                    break;
                }
            }

            if (isHun)
            {
                Console.WriteLine("\tA magyar versenyző bejutott a kűrbe");
            }
            else
            {
                Console.Write("\tA magyar versenyző nem jutott be a kűrbe");
            }

            // 4. feladat

            static double Összpontszam(string versenyzoNeve)
            {
                double osszpontszam = 0;

                foreach (var sportolo in donto)
                {
                    if (sportolo.Nev == versenyzoNeve)
                    {
                        osszpontszam = sportolo.KomponensPont + sportolo.TechnikaiPont - sportolo.Hibapont;
                    }
                }
                foreach (var sportolo in rovidprogram)
                {
                    if (sportolo.Nev == versenyzoNeve)
                    {
                        osszpontszam += sportolo.KomponensPont + sportolo.TechnikaiPont - sportolo.Hibapont;
                    }
                }

                return osszpontszam;
            }

            // 5. feladat

            Console.WriteLine("5. feladat");
            Console.WriteLine("\tKérem a versenyző nevét: ");

            string versenyzoNev = Console.ReadLine();

            bool letezikAVersenyzo = true;

            if (!rovidprogram.Any(x => x.Nev == versenyzoNev))
            {
                Console.WriteLine("Ilyen nevű induló nem volt");
                letezikAVersenyzo = false;
            }

            // 6. feladat 

            if (letezikAVersenyzo)
            {
                double osszPont = Összpontszam(versenyzoNev);

                Console.WriteLine("6. feladat");

                Console.WriteLine($"\t A versenyző összpontszáma: {osszPont}");
            }



            // 7. feladat 

            var countryCounts = rovidprogram.GroupBy(c => c.Orszagkod)
            .Where(group => group.Count() > 1)
            .Select(group => new { Orszagkod = group.Key, Versenyzoszam = group.Count() })
            .ToList();

            Console.WriteLine("7. feladat: ");
            foreach (var item in countryCounts)
            {
                Console.WriteLine($"\t{item.Orszagkod}: {item.Versenyzoszam} versenyző");
            }

            // 8. feladat

            StreamWriter sw = new StreamWriter("vegeredmeny.csv");

            int helyezes = 0;

            foreach (var sportolo in donto.OrderByDescending(x => Összpontszam(x.Nev)))
            {
                helyezes++;
                sw.WriteLine($"{helyezes}; {sportolo.Nev};{sportolo.Orszagkod};{Összpontszam(sportolo.Nev)}");
            }
            sw.Close();


        }
    }

}