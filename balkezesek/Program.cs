using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace balkezesek
{
    class Program
    {
        static List<balkezesek> balosak = new List<balkezesek>();

        static void Beolvas()
        {
            StreamReader sr = new StreamReader("balkezesek.csv");

            sr.ReadLine();

            while (!sr.EndOfStream)
            {
                balosak.Add(new balkezesek(sr.ReadLine()));

            }

            sr.Close();

        }
        static void Harmadik()
        {
            Console.WriteLine("3. feladat: {0}",balosak.Count);
        }

        static void Negyedik()
        {
            Console.WriteLine("4. feladat: ");

            foreach (var b in balosak)
            {
                if (b.Utolso.Contains("1999-10"))
                {
                    Console.WriteLine($"\t{b.Nev}  {Math.Round(b.Magassag*2.54, 1)} cm");
                }
            }
        }
        static void OtodikHatodik()
        {
            int evszam = 0;
            bool hibas;
            do
            {
                hibas = false;
                Console.WriteLine("Kérek egy 1990 és 1999 közötti évszámot: ");
                evszam = Convert.ToInt32(Console.ReadLine());
                if (evszam < 1990 || evszam > 1999)
                {
                    hibas = true;
                    Console.WriteLine("Hibás adat");
                }
            } while (hibas);
            var eves = from b in balosak
                       where Convert.ToInt32(b.Elso.Substring(0, 4)) <= evszam
                       &&
                       Convert.ToInt32(b.Utolso.Substring(0, 4)) >= evszam
                       select new { b.Suly };

            var evesList = eves.ToList();
            double szum = 0;
            foreach (var e in evesList)
            {
                szum += e.Suly;
            }
            double atlag = Math.Round(szum / evesList.Count(), 2);
            Console.WriteLine("6. feladat: {0:N2} font", atlag);
        }

        static void Hetedik()  //Group by nevekkel
        {

            var nevek = from b in balosak select b.Nev;

            var nevlista = nevek.ToList();

            var kezdoBetu = from n in nevlista orderby n group n by n[0] into tempNevek select tempNevek;

            Console.WriteLine("\nCsoportosítás kezdőbetű szerint");
            foreach (var csoport in kezdoBetu)
            {
                Console.WriteLine(csoport.Key);
                foreach (var csoportTag in csoport)
                {
                    Console.WriteLine($"\t{csoportTag}");
                }
            }

        }

        static void Main(string[] args)
        {
            Beolvas();
            Harmadik();
            Negyedik();
            OtodikHatodik();
            Hetedik();
            //foreach (var b in balosak)
            //{
            //    Console.WriteLine($"{b.Nev, 20}  {b.Elso}  {b.Utolso}  {b.Suly}  {b.Magassag}");
            //}

            Console.ReadLine();
        }
    }
}
